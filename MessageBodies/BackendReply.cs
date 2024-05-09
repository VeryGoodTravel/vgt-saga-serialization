namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// reply from the OrderService to all the backends
/// notifies the backends of the finished saga transaction
/// It is sent to all instances of the backend
/// </summary>
public record struct BackendReply() : IMessageBody
{
    // TODO: add data needed by the backend to have everthing that need to be send to the frontend
    
    // /// <summary>
    // /// Amount to pay
    // /// </summary>
    // public long Amount { get; }
    
}