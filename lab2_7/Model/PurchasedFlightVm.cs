namespace lab2_7.Model
{
  public class PurchasedFlightVm
  {
    public int Id { get; set; }
    public int FlightId{ get; set; }
    public int UserId { get; set; }
    public int TicketsCount { get; set; }
    public string TicketType { get; set; }
  }
}
