namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// all the saga order transaction data that needs to be returned? 
/// </summary>
public class OrderReply : MessageBody
{
    /// <summary>
    /// all the saga order transaction data that needs to be returned? 
    /// </summary>
    public OrderReply()
    {
        MessageType = MessageType.OrderReply;
    }
}