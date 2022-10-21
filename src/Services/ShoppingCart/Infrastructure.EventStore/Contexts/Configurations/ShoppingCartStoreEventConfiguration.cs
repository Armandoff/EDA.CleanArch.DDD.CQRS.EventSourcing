﻿using Domain.StoreEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EventStore.Contexts.Configurations;

public class ShoppingCartStoreEventConfiguration : IEntityTypeConfiguration<ShoppingCartStoreEvent>
{
    public void Configure(EntityTypeBuilder<ShoppingCartStoreEvent> builder)
    {
        builder.HasKey(storeEvent => new {storeEvent.Version, storeEvent.AggregateId});

        builder
            .Property(storeEvent => storeEvent.Version)
            .IsRequired();

        builder
            .Property(storeEvent => storeEvent.AggregateId)
            .IsRequired();

        builder
            .Property(storeEvent => storeEvent.AggregateName)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .Property(storeEvent => storeEvent.DomainEventName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .OwnsOne(storeEvent => storeEvent.DomainEvent, navigationBuilder => navigationBuilder.ToJson());
    }
}