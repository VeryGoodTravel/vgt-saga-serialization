namespace vgt_saga_serialization.MessageBodies;

public enum SagaAnswer
{
    Success,
    HotelFailure,
    FlightFailure,
    PaymentFailure,
    HotelAndFlightFailure
}

/// <summary>
/// reply from the OrderService to all the backends
/// notifies the backends of the finished saga transaction
/// It is sent to all instances of the backend
/// </summary>
public record struct BackendReply() : IMessageBody
{
    /// <summary>
    /// Guid of the SAGA transaction
    /// </summary>
    public Guid TransactionId { get; set; }
    
    /// <summary>
    /// ID of the offer as specified by the backend
    /// </summary>
    public string OfferId { get; set; }
    
    public SagaAnswer Answer { get; set; }
    
}