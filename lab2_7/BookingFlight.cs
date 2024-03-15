using lab2_7.Data;
using lab2_7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_7
{
  public sealed class BookingFlight : Booking
  {
    public string Company { get; set; }
    public string FlightId { get; set; }
    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }

    public BookingFlight() { }

    public BookingFlight(TouristVm tourist, string Company, string FlightId, string DepartureFrom, string ArrivalTo) : base(tourist)
    {
      this.Company = Company;
      this.FlightId = FlightId;
      this.DepartureFrom = DepartureFrom;
      this.ArrivalTo = ArrivalTo;
    }

    public override int getPrice()
    {
      throw new NotImplementedException();
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
