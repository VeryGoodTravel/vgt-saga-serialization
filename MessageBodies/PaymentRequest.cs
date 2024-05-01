namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// request to the payment gate with the amount to pay and currency specified
/// </summary>
public record struct PaymentRequest() : IMessageBody
{
    /// <summary>
    /// Amount to pay
    /// </summary>
    public long Amount { get; }
    /// <summary>
    /// Currency of the payment
    /// </summary>
    public string Currency { get; }
}