using MediatR;
using Microsoft.Extensions.Logging;
using MiniTrello_Hahn.Application.Common.EventBus;
using MiniTrello_Hahn.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.Boards.EventHandlers
{
    // Application/Boards/EventHandlers/BoardCreatedEventHandler.cs
    public class BoardCreatedEventHandler : INotificationHandler<DomainEventNotification<BoardCreatedEvent>>
    {
        private readonly ILogger<BoardCreatedEventHandler> _logger;

        public BoardCreatedEventHandler(ILogger<BoardCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<BoardCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var board = notification.DomainEvent.Board;
            _logger.LogInformation($"Board created: {board.Name}");

            return Task.CompletedTask;
        }
    }

}
