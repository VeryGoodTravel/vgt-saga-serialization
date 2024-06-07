namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// reply of the payment gate, current no additional data needed
/// </summary>
public class PaymentReply : MessageBody
{
    /// <summary>
    /// reply of the payment gate, current no additional data needed
    /// </summary>
    public PaymentReply()
    {
        MessageType = MessageType.PaymentReply;
    }
}