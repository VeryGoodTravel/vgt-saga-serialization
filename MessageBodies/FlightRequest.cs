namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// request to the hotel service
/// contains definition if the reservation is temporary (wait for payment)
/// and all the data service needs
/// </summary>
public record struct FlightRequest() : IMessageBody
{
    /// <summary>
    /// If the flight needs to be reserved for a limited time waiting for a payment
    /// </summary>
    public bool Temporary { get; }
    /// <summary>
    /// City the flight takes off
    /// </summary>
    public string CityFrom { get; }
    /// <summary>
    /// city the flight lands in
    /// </summary>
    public string CityTo { get; }
    /// <summary>
    /// date the flight to the hotel takes place
    /// </summary>
    public DateTime BookFrom { get; }
    /// <summary>
    /// date the return flight takes place
    /// </summary>
    public DateTime BookTo { get; }
    /// <summary>
    /// amount of the passengers to take
    /// </summary>
    public int PassangerCount { get; }
    
    /// <summary>
    /// Flight ID to book on full book
    /// </summary>
    public long? FlightId { get; }
    /// <summary>
    /// Seats on the flight to fully book
    /// </summary>
    public List<long>? SeatNr { get; }
}