using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using vgt_saga_serialization.MessageBodies;

namespace vgt_saga_serialization;

public class SagaJsonConverter : JsonConverter 
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        ArgumentNullException.ThrowIfNull(value);
        
        //((IMessageBody)value).field = ...
        var o = JObject.FromObject(value, serializer);
        
        o.WriteTo(writer);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var jToken = JToken.ReadFrom(reader);
        var jObj = jToken["MessageType"];
        object? bodyType = null;
        
        // convert type to enum
        if (jObj != null) Enum.TryParse(typeof(MessageType), jObj.ToString(), out bodyType);
        else bodyType = MessageType.Invalid;

        // read appropriate type of the message
        IMessageBody result = (MessageType?)bodyType switch
        {
            MessageType.OrderRequest => new OrderRequest(),
            MessageType.OrderReply => new OrderReply(),
            MessageType.PaymentRequest => new PaymentRequest(),
            MessageType.PaymentReply => new PaymentReply(),
            MessageType.HotelRequest => new HotelRequest(),
            MessageType.HotelReply => new HotelReply(),
            MessageType.FlightRequest => new FlightRequest(),
            MessageType.FlightReply => new FlightReply(),
            MessageType.Invalid => new Invalid(),
            null => new Invalid(),
            _ => new Invalid()
        };
        
        serializer.Populate(jToken.CreateReader(), result);

        return result;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(IMessageBody);
    }
}