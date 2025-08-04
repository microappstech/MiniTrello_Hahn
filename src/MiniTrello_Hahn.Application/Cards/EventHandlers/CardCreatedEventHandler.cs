using MediatR;
using Microsoft.Extensions.Logging;
using MiniTrello_Hahn.Application.Common.EventBus;
using MiniTrello_Hahn.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.Cards.EventHandlers
{
    // Application/Boards/EventHandlers/BoardCreatedEventHandler.cs
    public class CardCreatedEventHandler : INotificationHandler<DomainEventNotification<CardCreatedEvent>>
    {
        private readonly ILogger<CardCreatedEventHandler> _logger;

        public CardCreatedEventHandler(ILogger<CardCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CardCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var board = notification.DomainEvent.Card;
            _logger.LogInformation($"Board created: {board.Title}");

            return Task.CompletedTask;
        }
    }

}
