namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// reply of the hotel service
/// </summary>
public record struct HotelReply() : IMessageBody
{
    /// <summary>
    /// RoomId booked
    /// </summary>
    public int RoomId { get; }
}