namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// All the saga order transaction data
/// </summary>
public class OrderRequest : MessageBody
{
    /// <summary>
    /// All the saga order transaction data
    /// </summary>
    public OrderRequest()
    {
        MessageType = MessageType.OrderRequest;
    }
}