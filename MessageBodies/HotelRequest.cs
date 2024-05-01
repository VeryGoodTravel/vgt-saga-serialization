namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// request to the hotel service
/// contains definition if the reservation is temporary (wait for payment)
/// and all the data service needs
/// </summary>
public record struct HotelRequest() : IMessageBody
{
    /// <summary>
    /// If the hotel needs to be reserved for a limited time waiting for a payment
    /// </summary>
    public bool Temporary { get; }
    /// <summary>
    /// type of the room to find and book
    /// </summary>
    public int RoomType { get; }
    /// <summary>
    /// Hotel name the room should be looked for
    /// </summary>
    public string HotelName { get; }
    /// <summary>
    /// City of the airport the hotel uses
    /// </summary>
    public string AirportCity { get; }
    /// <summary>
    /// date to book the hotel from
    /// </summary>
    public DateTime BookFrom { get; }
    /// <summary>
    /// date to book the hotel to
    /// </summary>
    public DateTime BookTo { get; }
    
    /// <summary>
    /// RoomId to fully book
    /// </summary>
    public int? RoomId { get; }
}