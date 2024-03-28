namespace lab2_7.Interfaces
{
  public interface IBooking
  {
    int id { get; set; }
    string ticketClass { get; set; }
    string bookingType { get; set; }

    int getPrice();
  }
}
