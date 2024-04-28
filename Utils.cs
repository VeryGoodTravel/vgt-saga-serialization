using System.Text;
using Newtonsoft.Json;
using NLog;

namespace vgt_saga_serialization;

/// <summary>
/// Util class for the SAGA messages serialization handling.
/// Util offers deserialization and serialization of the JSON messages to the appropriate types of the messages.
/// Uses custom JsonConverter.
/// </summary>
public class Utils
{
    private readonly Logger _logger;
    private readonly JsonSerializerSettings _serializer;

    /// <summary>
    /// Default constructor for the Utils class.
    /// Utils object specifies the appropriate logger for the operations.
    /// </summary>
    /// <param name="log"></param>
    public Utils(Logger log)
    {
        _logger = log;
        _serializer = GetJsonSerializerSettings();
    }

    /// <summary>
    /// Deserializes JSON written in bytes from the RabbitMQ to the Saga Message struct
    /// with targeted and appropriate MessageBody of the specified Type.
    /// </summary>
    /// <param name="body"> Json in bytes to deserialize </param>
    /// <returns> null if invalid otherwise deserialized Saga Message</returns>
    public Message? Deserialize(byte[] body)
    {
        Message? message = JsonConvert.DeserializeObject<Message>(Encoding.UTF8.GetString(body), _serializer);

        if (message == null)
        {
            _logger.Warn("Couldn't deserialize SAGA message - Invalid");
            return null;
        }
        
        _logger.Debug("Deserialized SAGA message | TransactionID: {id} | Type: {type} | MessageID {guid}", 
            message.Value.TransactionId, message.Value.MessageType, message.Value.MessageId);
        
        return message;
    }

    /// <summary>
    /// Serializes SAGA Message struct to a string JSON
    /// </summary>
    /// <param name="message"> Saga Message struct to serialize </param>
    /// <returns> string containing JSON </returns>
    public string Serialize(Message message) => JsonConvert.SerializeObject(message, _serializer);

    private JsonSerializerSettings GetJsonSerializerSettings() => new()
    {
        Error = delegate(object? sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
        {
            _logger.Warn("Json serializer error occurred in SAGA messages handling. {e}", args.ErrorContext.Error.Message);
            args.ErrorContext.Handled = true;
        },
        Converters = { new SagaJsonConverter() }
    };
}