﻿using System.Threading.Tasks;
using Application.EventSourcing.EventStore;
using MassTransit;
using DiscardCartCommand = ECommerce.Contracts.ShoppingCart.Commands.DiscardCart;

namespace Application.UseCases.Commands;

public class DiscardCartConsumer : IConsumer<DiscardCartCommand>
{
    private readonly IShoppingCartEventStoreService _eventStoreService;

    public DiscardCartConsumer(IShoppingCartEventStoreService eventStoreService)
    {
        _eventStoreService = eventStoreService;
    }

    public async Task Consume(ConsumeContext<DiscardCartCommand> context)
    {
        var shoppingCart = await _eventStoreService.LoadAggregateFromStreamAsync(context.Message.CartId, context.CancellationToken);
        shoppingCart.Handle(context.Message);
        await _eventStoreService.AppendEventsToStreamAsync(shoppingCart, context.CancellationToken);
    }
}