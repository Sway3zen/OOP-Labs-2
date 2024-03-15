using CefSharp;
using lab2_7.Data;
using lab2_7.Migrations;
using lab2_7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lab2_7
{
  public class TourAgency
  {
    private readonly string Name = "Golobe";
    private readonly string Address = "Piccadilly Circus, London, UK";
    private readonly string ContactPerson = "John Smith";

    public void addNewFlight(FlightsVm flight)
    {
      using (AppDbContext db = new AppDbContext())
      {
        db.Flights.Add(flight);
        db.SaveChanges();

        Form1.browser.ExecuteScriptAsync("alert('Flight are added.')");
      }
    }

    public void addNewStays()
    {

    }

    public List<FlightsVm> getListOfFlights(string departureFrom, string arrivalTo, DateOnly date, string passengerClass, int ticketCount)
    {
      using (AppDbContext db = new AppDbContext())
      {
        List<FlightsVm> flights = new List<FlightsVm>();

        switch (passengerClass)
        {
          case "Economy":
            flights = db.Flights.Where(f => f.DepartureFrom == departureFrom && f.ArrivalTo == arrivalTo && f.DepartureDate == date && f.EconomyClass >= ticketCount).ToList();
            break;
          case "Business":
            flights = db.Flights.Where(f => f.DepartureFrom == departureFrom && f.ArrivalTo == arrivalTo && f.DepartureDate == date && f.BusinessClass >= ticketCount).ToList();
            break;
          case "First":
            flights = db.Flights.Where(f => f.DepartureFrom == departureFrom && f.ArrivalTo == arrivalTo && f.DepartureDate == date && f.FirstClass >= ticketCount).ToList();
            break;
        }

        return flights;
      }
    }

    //public List<string> getListOfStays()
    //{
    //}

    public static bool addTouristFlight(int flightId, int touristId, string ticketType, int ticketCount)
    {
      using (AppDbContext db = new AppDbContext())
      {
        PurchasedFlightVm ticket = new PurchasedFlightVm { FlightId = flightId, UserId = touristId, TicketType = ticketType, TicketsCount = ticketCount };
        try
        {
          db.PurchasedFlights.Add(ticket);
          db.SaveChanges();

          return true;
        }
        catch (Exception e)
        {
          return false;
        }
      }
    }

    public void addTouristStays()
    {

    }

    public TouristVm GetTouristInfo(string email)
    {
      using (AppDbContext db = new AppDbContext()) 
      {
        UserVm user = db.Users.Where(u => u.Email == email).FirstOrDefault();
        if (user != null)
        {
          TouristVm tourist = new TouristVm { Id = user.Id, Name = user.Name, Surname = user.Surname, Email = user.Email };
          return tourist;
        }

        return null;
      }
    }
  }
}
