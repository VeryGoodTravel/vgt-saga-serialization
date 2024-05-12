namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// request from the backend 
/// contains the data that is needed for the saga transaction order
/// </summary>
public record struct BackendRequest() : IMessageBody
{
    // TODO: add available data eg. time from, time to
        
    // /// <summary>
    // /// Amount to pay
    // /// </summary>
    // public long Amount { get; }
    
}