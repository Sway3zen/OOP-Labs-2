using lab2_7.Data;
using lab2_7.Model;
using lab2_7.Interfaces;
using CefSharp.DevTools.Debugger;

namespace lab2_7
{
  public sealed class BookingFlight : Booking, IBooking
  {
    public string Company { get; set; }
    public string FlightId { get; set; }
    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }

    public int id { get; set; }
    public string ticketClass { get; set; }
    public string bookingType { get; set; }

    public BookingFlight() { }

    public BookingFlight(TouristVm tourist, string Company, string FlightId, string DepartureFrom, string ArrivalTo) : base(tourist)
    {
      this.setTouristInfo(tourist);
      this.Company = Company;
      this.FlightId = FlightId;
      this.DepartureFrom = DepartureFrom;
      this.ArrivalTo = ArrivalTo;
    }

    public override int getPrice()
    {
      if (this.bookingType == "flight")
      {
        using (AppDbContext db = new AppDbContext())
        {
          FlightsVm flight = db.Flights.Where(f => f.Id == this.id).FirstOrDefault();

          if (flight == null) return 0;

          int ticketPrice = -1;

          switch (this.ticketClass) {
            case "Economy":
              ticketPrice = flight.EconomyPrice;
              break;
            case "Business":
              ticketPrice = flight.BusinessPrice;
              break;
            case "First":
              ticketPrice = flight.FirstPrice;
              break;
          }

          return ticketPrice;
        }
      }

      return 0;
    }

    public override bool buyTicket(int FlightId, string TicketType, int TicketCount)
    {
      using (AppDbContext db = new AppDbContext())
      {
        FlightsVm flight = null;
        try
        {
          flight = db.Flights.Where(f => f.Id == FlightId).FirstOrDefault();
        }
        catch (Exception e)
        {
          return false;
        }

        if (flight == null) return false;

        int ticketClass = 0;

        switch (TicketType)
        {
          case "Economy":
            ticketClass = flight.EconomyClass;
            break;
          case "Business":
            ticketClass = flight.BusinessClass;
            break;
          case "First":
            ticketClass = flight.FirstClass;
            break;
          default:
            return false;
        }

        if (ticketClass >= TicketCount)
        {
          try
          {
            ticketClass -= TicketCount;

            switch (TicketType)
            {
              case "Economy":
                flight.EconomyClass = ticketClass;
                break;
              case "Business":
                flight.BusinessClass = ticketClass;
                break;
              case "First":
                flight.FirstClass = ticketClass;
                break;
              default:
                return false;
            }

            db.Flights.Update(flight);
            db.SaveChanges();
          }
          catch (Exception e)
          {
            return false;
          }

          bool isAdd = TourAgency.addTouristFlight(flight.Id, this.tourist.Id, TicketType, TicketCount);

          return isAdd;
        }
      }

      return false;
    }

    private bool addTouristFlight(int FlightId, int TouristId, string TicketType, int TicketCount)
    {
      throw new NotImplementedException();
    }

    private bool cancelTouristFlight(int FlightId, int TouristId, string TicketType, int TicketCount)
    {
      throw new NotImplementedException();
    }

    private void addNewFlight(FlightsVm flight)
    {
      throw new NotImplementedException();
    }
  }
}
