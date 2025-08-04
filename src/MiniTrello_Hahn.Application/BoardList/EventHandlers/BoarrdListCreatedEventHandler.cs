using MediatR;
using Microsoft.Extensions.Logging;
using MiniTrello_Hahn.Application.Common.EventBus;
using MiniTrello_Hahn.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTrello_Hahn.Application.BoardList.EventHandlers
{
    public class BoardListCreatedEventHandler : INotificationHandler<DomainEventNotification<BoardListCreatedEvent>>
    {
        private readonly ILogger<BoardListCreatedEventHandler> _logger;

        public BoardListCreatedEventHandler(ILogger<BoardListCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<BoardListCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var boardList = notification.DomainEvent.BoardList;
            _logger.LogInformation($"Board list created: {boardList.Title}");

            return Task.CompletedTask;
        }
    }
}
