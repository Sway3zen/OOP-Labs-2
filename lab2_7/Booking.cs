using lab2_7.Model;

namespace lab2_7
{
  public abstract class Booking : Tourist
  {
    protected TouristVm tourist = new TouristVm();
    public Booking() 
    {

    }

    public Booking(TouristVm tourist)
    {
      this.tourist = tourist;
    }

    public abstract int getPrice();

    public abstract bool buyTicket(int id, string type, int count);

    private void getPurchasedFlightsTicket(string email)
    {

    }

    private void getPurchasedTickets(string email)
    {

    }

    private void buyFlightTicket(int id, string userEmail, string ticketType, int countTicket)
    {

    }
  }
}
