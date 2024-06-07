namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// request to the hotel service
/// contains definition if the reservation is temporary (wait for payment)
/// and all the data service needs
/// </summary>
public class FlightRequest : MessageBody
{
    
    public FlightRequest()
    {
        MessageType = MessageType.FlightRequest;
    }
    /// <summary>
    /// If the flight needs to be reserved for a limited time waiting for a payment
    /// </summary>
    public bool? Temporary { get; set; }
    /// <summary>
    /// City the flight takes off
    /// </summary>
    public string? CityFrom { get; set; }
    /// <summary>
    /// city the flight lands in
    /// </summary>
    public string? CityTo { get; set; }
    /// <summary>
    /// date the flight to the hotel takes place
    /// </summary>
    public DateTime? BookFrom { get; set; }
    /// <summary>
    /// date the return flight takes place
    /// </summary>
    public DateTime? BookTo { get; set; }
    /// <summary>
    /// What datetime the temporary request was executed
    /// </summary>
    public DateTime? TemporaryDateTime { get; set; }
    /// <summary>
    /// amount of the passengers to take
    /// </summary>
    public int? PassangerCount { get; set; }
    
    /// <summary>
    /// Flight ID to book on full book
    /// </summary>
    public long? FlightId { get; set; }
    
}