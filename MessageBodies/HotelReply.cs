namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// reply of the hotel service
/// </summary>
public class HotelReply : MessageBody
{
    
    public HotelReply()
    {
        MessageType = MessageType.HotelReply;
    }
}