using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using MiniTrello_Hahn.Application.BoardList.Commands;
using MiniTrello_Hahn.Application.BoardList.Queries;
using MiniTrello_Hahn.Application.Boards.Commands;
using MiniTrello_Hahn.Application.Cards.Commands;
using MiniTrello_Hahn.Application.Mapping;
using MiniTrello_Hahn.Domain.Interfaces;
using MiniTrello_Hahn.Infrastructure.Data;
using MiniTrello_Hahn.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// container services.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
// Program.cs
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateBoardCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateBoardListCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateCardCommand).Assembly);
});
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddValidatorsFromAssembly(typeof(CreateCardCommandValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateBoardCommandValidator).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateBoardListCommandValidator).Assembly);
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniTrello API V1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
