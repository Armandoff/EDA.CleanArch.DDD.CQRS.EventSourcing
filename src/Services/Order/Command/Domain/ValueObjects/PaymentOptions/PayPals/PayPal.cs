﻿using Contracts.DataTransferObjects;

namespace Domain.ValueObjects.PaymentOptions.PayPals;

public record PayPal(string Email, string Password) : IPaymentOption
{
    public static implicit operator PayPal(Dto.PayPal creditCard)
        => new(creditCard.Email, creditCard.Password);

    public static implicit operator Dto.PayPal(PayPal creditCard)
        => new(creditCard.Email, creditCard.Password);
}