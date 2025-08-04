using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniTrello_Hahn.Application.Common.EventBus;
using MiniTrello_Hahn.Domain.Common;
using MiniTrello_Hahn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Infrastructure.Data
{ 
    public class AppDbContext:DbContext
    {
        private readonly IMediator? _mediator;

        public AppDbContext(IMediator mediator, DbContextOptions<AppDbContext> options) : base(options)
        {
            _mediator = mediator;
        }
        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator? mediator = null)
        : base(options)
        {
            _mediator = mediator;
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Dispatch domain events BEFORE saving to DB
            await DispatchDomainEventsAsync();

            return await base.SaveChangesAsync(cancellationToken);
        }
        private async Task DispatchDomainEventsAsync()
        {
            var domainEntities = ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents?.Any() == true)
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            foreach (var entity in domainEntities)
                entity.Entity.ClearDomainEvents();

            foreach (var domainEvent in domainEvents)
            {
                var notificationType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
                var notification = Activator.CreateInstance(notificationType, domainEvent);

                await _mediator.Publish((INotification)notification!);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardList>()
                .HasOne(i => i.Board)
                .WithMany(i => i.Lists)
                .HasForeignKey(i=>i.BoardId)
                .HasPrincipalKey(i=>i.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Card>()
                .HasOne(i => i.BoardList)
                .WithMany(i => i.Cards)
                .HasForeignKey(i => i.ListId)
                .HasPrincipalKey(i => i.Id);



            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardList> BoardLists { get; set; }
        public DbSet<Card> Cards { get; set; }
         
    }
}
