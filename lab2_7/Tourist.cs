using lab2_7.Model;
using lab2_7.Data;
using CefSharp;

namespace lab2_7
{
  public class Tourist : TourAgency
  {
    protected TouristVm tourist = new TouristVm();

    public Tourist() { }
    public Tourist(TouristVm tourist)
    {
      this.tourist = tourist;
    }

    public void setTouristInfo(TouristVm tourist)
    {
      this.tourist = tourist;
    }

    public void getPurchasedFlightsTicket(string email)
    {
      int userId = -1;

      using (AppDbContext db = new AppDbContext())
      {
        userId = db.Users.Where(u => u.Email == email).FirstOrDefault().Id;
      }

      if (userId == -1)
      {
        Form1.browser.ExecuteScriptAsync("alert('User not found')");
        return;
      }

      List<PurchasedFlightVm> tickets = new List<PurchasedFlightVm>();

      using (AppDbContext db = new AppDbContext())
      {
        tickets = db.PurchasedFlights.Where(f => f.UserId == userId).ToList();
      }

      if (tickets.Count == 0) return;

      using (AppDbContext db = new AppDbContext())
      {
        foreach (PurchasedFlightVm ticket in tickets)
        {
          FlightsVm flight = db.Flights.Where(f => f.Id == ticket.FlightId).FirstOrDefault();
          if (flight == null) return;

          string flightInfo = $"'{flight.AirLines}', '{flight.DepartureFrom}', '{flight.DepartureTime}', '{flight.ArrivalTo}', '{flight.ArrivalTime}', '{flight.DepartureDate}'";

          Form1.browser.ExecuteScriptAsync($"window.loadFlightsTickets({flightInfo});");
        }
      }
    }
  }
}
