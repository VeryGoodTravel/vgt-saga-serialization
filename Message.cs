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
    /// The creation date of the message
    /// </summary>
    public DateTime CreationDate { get; }
    
    /// <summary>
    /// A message type used by producers/consumers to identify events and commands
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public MessageType MessageType { get; }
    
    /// <summary>
    /// Saga transaction state of the message
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public SagaState State { get; }
    
    /// <summary>
    /// Body of the command of type specified in MessageType
    /// </summary>
    public IMessageBody? Body { get; }
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

/// <summary>
/// Implemented Saga states the transaction could be on
/// </summary>
public enum SagaState
{
    /// <summary>
    /// saga transaction has started
    /// </summary>
    Begin,
    /// <summary>
    /// saga hotel timed reservation passed successfully
    /// </summary>
    HotelTimedAccept,
    /// <summary>
    /// saga hotel timed reservation failed
    /// </summary>
    HotelTimedFail,
    /// <summary>
    /// saga hotel timed reservation rollback
    /// </summary>
    HotelTimedRollback,
    /// <summary>
    /// saga hotel full reservation passed successfully
    /// </summary>
    HotelFullAccept,
    /// <summary>
    /// saga hotel full reservation failed
    /// </summary>
    HotelFullFail,
    /// <summary>
    /// saga hotel full reservation rollback
    /// </summary>
    HotelFullRollback,
    /// <summary>
    /// saga flight timed reservation passed successfully
    /// </summary>
    FlightTimedAccept,
    /// <summary>
    /// saga flight timed reservation failed
    /// </summary>
    FlightTimedFail,
    /// <summary>
    /// saga flight timed reservation rollback
    /// </summary>
    FlightTimedRollback,
    /// <summary>
    /// saga flight full reservation passed successfully
    /// </summary>
    FlightFullAccept,
    /// <summary>
    /// saga flight full reservation failed
    /// </summary>
    FlightFullFail,
    /// <summary>
    /// saga flight full reservation rollback
    /// </summary>
    FlightFullRollback,
    /// <summary>
    /// saga payment passed successfully
    /// </summary>
    PaymentAccept,
    /// <summary>
    /// saga payment failed
    /// </summary>
    PaymentFailed,
    /// <summary>
    /// saga transaction passed successfully
    /// </summary>
    SagaSuccess,
    /// <summary>
    /// saga transaction failed
    /// </summary>
    SagaFail
}