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
    public bool? Temporary { get; set; }
    /// <summary>
    /// type of the room to find and book
    /// </summary>
    public string? RoomType { get; set; }
    /// <summary>
    /// Hotel name the room should be looked for
    /// </summary>
    public string? HotelName { get; set; }
    /// <summary>
    /// date to book the hotel from
    /// </summary>
    public DateTime? BookFrom { get; set; }
    /// <summary>
    /// date to book the hotel to
    /// </summary>
    public DateTime? BookTo { get; set; }
    /// <summary>
    /// What datetime the temporary request was executed
    /// </summary>
    public DateTime? TemporaryDateTime { get; set; }
    /// <summary>
    /// How many adults in the booking request
    /// </summary>
    public int? AdultCount { get; set; }
    /// <summary>
    /// How many children under 18yo in the booking request
    /// </summary>
    public int? OldChildren { get; set; }
    
    /// <summary>
    /// How many children under 10yo in the booking request
    /// </summary>
    public int? MidChildren { get; set; }
    
    /// <summary>
    /// How many children under 3yo in the booking request
    /// </summary>
    public int? LesserChildren { get; set; }
}