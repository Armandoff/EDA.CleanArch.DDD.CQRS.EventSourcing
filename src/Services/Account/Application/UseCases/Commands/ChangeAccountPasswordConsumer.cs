﻿using System.Threading.Tasks;
using Application.EventSourcing.EventStore;
using MassTransit;
using Messages.Accounts.Commands;

namespace Application.UseCases.Commands
{
    public class ChangeAccountPasswordConsumer : IConsumer<ChangeAccountPassword>
    {
        private readonly IAccountEventStoreService _eventStoreService;

        public ChangeAccountPasswordConsumer(IAccountEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        public async Task Consume(ConsumeContext<ChangeAccountPassword> context)
        {
            var account = await _eventStoreService.LoadAggregateFromStreamAsync(context.Message.AccountId, context.CancellationToken);

            if (account.User.Id != context.Message.UserId)
            {
                // TODO - Notification
                return;
            }

            account.ChangePassword(
                account.Id,
                account.User.Id,
                context.Message.NewPassword,
                context.Message.NewPasswordConfirmation);

            await _eventStoreService.AppendEventsToStreamAsync(account, context.CancellationToken);
        }
    }
}