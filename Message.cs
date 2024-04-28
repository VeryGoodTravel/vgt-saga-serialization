using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace vgt_saga_serialization;

/// <summary>
/// Main message template of the SAGA messages
/// </summary>
public record struct Message
{
    /// <summary>
    /// A unique identifier that spans the whole transaction
    /// </summary>
    public string TransactionId { get; }

    /// <summary>
    /// A unique identifier per message
    /// </summary>
    public string MessageId { get; }
    
    /// <summary>
    /// The name of the service that is sending the message
    /// </summary>
    public string Source { get; }

    /// <summary>
    /// The creation date of the message
    /// </summary>
    public DateTime CreationDate { get; }
    
    /// <summary>
    /// A message type used by producers/consumers to identify events and commands
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public MessageType MessageType { get; }
    
    /// <summary>
    /// Body of the command of type specified in MessageType
    /// </summary>
    public IMessageBody Body { get; }
}

/// <summary>
/// Implemented message type bodies 
/// </summary>
public enum MessageType
{
    /// <summary>
    /// body type of the requests incoming to the Order microservice
    /// </summary>
    OrderRequest,
    /// <summary>
    /// body type of the replies incoming from the Order microservice
    /// </summary>
    OrderReply,
    /// <summary>
    /// body type of the requests incoming to the Payment microservice
    /// </summary>
    PaymentRequest,
    /// <summary>
    /// body type of the requests incoming from the Payment microservice
    /// </summary>
    PaymentReply,
    /// <summary>
    /// body type of the requests incoming to the Hotel microservice
    /// </summary>
    HotelRequest,
    /// <summary>
    /// body type of the requests incoming from the Hotel microservice
    /// </summary>
    HotelReply,
    /// <summary>
    /// body type of the requests incoming to the Flight microservice
    /// </summary>
    FlightRequest,
    /// <summary>
    /// body type of the requests incoming from the Flight microservice
    /// </summary>
    FlightReply,
    /// <summary>
    /// specifies that the message is invalid
    /// </summary>
    Invalid
}