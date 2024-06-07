using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace vgt_saga_serialization;

/// <summary>
/// Message body of the request or reply
/// contains data needed by the microservice for the transaction
/// </summary>
public class MessageBody
{
    /// <summary>
    /// A message type used by producers/consumers to identify events and commands
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public MessageType MessageType { get; set; }
}