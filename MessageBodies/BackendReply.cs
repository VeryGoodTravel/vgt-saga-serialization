using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
public class BackendReply : MessageBody
{
    /// <summary>
    /// reply from the OrderService to all the backends
    /// notifies the backends of the finished saga transaction
    /// It is sent to all instances of the backend
    /// </summary>
    public BackendReply()
    {
        MessageType = MessageType.BackendReply;
    }

    /// <summary>
    /// Guid of the SAGA transaction
    /// </summary>
    public Guid TransactionId { get; set; }
    
    /// <summary>
    /// ID of the offer as specified by the backend
    /// </summary>
    public string OfferId { get; set; }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public SagaAnswer Answer { get; set; }
    
}