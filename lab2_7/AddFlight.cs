using CefSharp;
using lab2_7.Data;
using lab2_7.Model;


namespace lab2_7
{
  public class AddFlight
  {
    public AddFlight(FlightsVm flight)
    {
      using (AppDbContext db = new AppDbContext())
      {
        db.Flights.Add(flight);
        db.SaveChanges();

        Form1.browser.ExecuteScriptAsync("alert('Flight are added.')");
      }
    }
  }
}
