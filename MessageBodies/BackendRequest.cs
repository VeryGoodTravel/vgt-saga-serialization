namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// request from the backend 
/// contains the data that is needed for the saga transaction order
/// </summary>
public class BackendRequest : MessageBody
{
    // TODO: add available data eg. time from, time to
    public BackendRequest()
    {
        MessageType = MessageType.BackendRequest;
    }
    // /// <summary>
    // /// Amount to pay
    // /// </summary>
    // public long Amount { get; }
    
}