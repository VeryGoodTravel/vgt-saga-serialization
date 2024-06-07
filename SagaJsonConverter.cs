using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using vgt_saga_serialization.MessageBodies;

namespace vgt_saga_serialization;

/// <summary>
/// Converter class used to differentiate between implemented types of the message body.
/// Serializes and deserializes json to and from the targeted record structs.
/// </summary>
public class SagaJsonConverter : JsonConverter 
{
    /// <inheritdoc/>
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        //((IMessageBody)value).field = ...
        var o = JObject.FromObject(value, serializer);
        
        o.WriteTo(writer);
    }

    /// <summary>
    /// Deserializes json to targeted MessageBody
    /// </summary>
    /// <inheritdoc/>
    /// <returns> IMessageBody of the appropriate type </returns>
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var jToken = JToken.ReadFrom(reader);
        var jObj = jToken["MessageType"];
        object? bodyType = null;
        
        // convert type to enum
        if (jObj != null) Enum.TryParse(typeof(MessageType), jObj.ToString(), out bodyType);
        else bodyType = MessageType.Invalid;

        // read appropriate type of the message
        MessageBody? result = (MessageType?)bodyType switch
        {
            MessageType.OrderRequest => new OrderRequest(),
            MessageType.OrderReply => new OrderReply(),
            MessageType.PaymentRequest => new PaymentRequest(),
            MessageType.PaymentReply => new PaymentReply(),
            MessageType.HotelRequest => new HotelRequest(),
            MessageType.HotelReply => new HotelReply(),
            MessageType.FlightRequest => new FlightRequest(),
            MessageType.FlightReply => new FlightReply(),
            MessageType.BackendRequest => new BackendRequest(),
            MessageType.BackendReply => new BackendReply(),
            null => null,
            _ => null
        };
        
        if(result != null) serializer.Populate(jToken.CreateReader(), result);

        return result;
    }
    
    /// <inheritdoc/>
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(MessageBody);
    }
}