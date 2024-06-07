namespace vgt_saga_serialization.MessageBodies;

/// <summary>
/// reply of the hotel service
/// </summary>
public class FlightReply() : MessageBody
{
    /// <summary>
    /// ID number of the flight that got selected
    /// </summary>
    public long FlightId { get; }
    /// <summary>
    /// ID number of the return flight that got selected
    /// </summary>
    public long ReturnFlightId { get; }
    /// <summary>
    /// List of seats selected
    /// </summary>
    public List<long> SeatNr { get; }
}