using CefSharp;
using lab2_7.Data;
using lab2_7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

    //public List<string> getListOfFlights()
    //{
    //}

    //public List<string> getListOfStays()
    //{
    //}

    public void addTouristFlight()
    {

    }

    public void addTouristStays()
    {

    }
  }
}
