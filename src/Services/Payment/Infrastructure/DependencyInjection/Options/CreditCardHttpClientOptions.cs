﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DependencyInjection.Options;

public record CreditCardHttpClientOptions
{
    [Required, Url]
    public string BaseAddress { get; init; }

    [Required, MinLength(5)]
    public string CancelEndpoint { get; init; }

    [Required, MinLength(5)]
    public string AuthorizeEndpoint { get; init; }

    [Required, MinLength(5)]
    public string RefundEndpoint { get; init; }

    [Required, MinLength(5)]
    public string CaptureEndpoint { get; init; }
    
    [Required, Range(5, 200)]
    public int OverallTimeout { get; init; }

    [Required, Range(2, 20)]
    public int RetryCount { get; init; }
    
    [Required, Range(2, 20)]
    public int SleepDurationPower { get; init; }
    
    [Required, Range(2, 20)]
    public int EachRetryTimeout { get; init; }

    [Required, Range(2, 20)]
    public int CircuitBreaking { get; init; }

    [Required, Range(2, 60)]
    public int DurationOfBreak { get; init; }
}