using CefSharp;
using CefSharp.WinForms;
using CefSharp.JavascriptBinding;
using CefSharp.DevTools.Database;
using lab2_7.Data;
using lab2_7.Model;

using System.Runtime.InteropServices;
using System.Web;

namespace lab2_7
{
  public partial class Form1 : Form
  {
    public static ChromiumWebBrowser browser;
    public static TourAgency[] TourAgencyArray =
      [
        new TourAgency(),
        new TourAgency()
      ];

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      //AllocConsole();

      CefSettings settings = new CefSettings();
      Cef.Initialize(settings);

      string path = "http://localhost:5173/";
      //string path = "C:\\Users\\sway3\\OneDrive\\Desktop\\oop\\OOP-Labs-2\\lab2_7\\cef\\build\\index.html";
      Form1.browser = new ChromiumWebBrowser(path);
  
      Form1.browser.Dock = DockStyle.Fill;
      Controls.Add(Form1.browser);

      Form1.browser.JavascriptObjectRepository.Register("boundAsync", new BoundObject(), BindingOptions.DefaultBinder);

      Form1.browser.LoadingStateChanged += (sender, args) =>
      {
        if (!Form1.browser.IsLoading)
        {
          //Form1.browser.ShowDevTools();
          
        }
      };
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
  }

  public class BoundObject
  {
    public void showMessage(string msg)
    {
      try
      {
        MessageBox.Show(msg);

        if (Form1.browser != null)
        {
          //Form1.browser.ExecuteScriptAsync("console.log('Loaded 1221')");
        }
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    public void registerUser(string name, string lastName, string email, string phoneNumber, string password)
    {
      try
      {
        new Register(new UserVm { Email = email, Password = password, Name = name, Surname = lastName, PhoneNumber = phoneNumber });
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }
    
    public void loginUser(string email, string password)
    {
      new Login(email, password);
    }

    public void addFlight(string AirLines, string[] FromTo, string[] DepartureDateTime, string[] ArrivalDateTime, string[] TicketsPrices)
    {
      FlightsVm flight = new FlightsVm();
      flight.AirLines = AirLines;
      flight.DepartureFrom = FromTo[0];
      flight.ArrivalTo = FromTo[1];

      string[] departureDateArray = DepartureDateTime[0].Split('-');
      string[] departureTimeArray = DepartureDateTime[1].Split(':');

      flight.DepartureDate = new DateOnly(int.Parse(departureDateArray[0]), int.Parse(departureDateArray[1]), int.Parse(departureDateArray[2]));
      flight.DepartureTime = new TimeOnly(int.Parse(departureTimeArray[0]), int.Parse(departureTimeArray[1]));

      string[] arrivalDateArray = ArrivalDateTime[0].Split('-');
      string[] arrivalTimeArray = ArrivalDateTime[1].Split(':');

      flight.ArrivalDate = new DateOnly(int.Parse(arrivalDateArray[0]), int.Parse(arrivalDateArray[1]), int.Parse(arrivalDateArray[2]));
      flight.ArrivalTime = new TimeOnly(int.Parse(arrivalTimeArray[0]), int.Parse(arrivalTimeArray[1]));

      flight.EconomyPrice = int.Parse(TicketsPrices[0]);
      flight.EconomyClass = int.Parse(TicketsPrices[1]);
      flight.BusinessPrice = int.Parse(TicketsPrices[2]);
      flight.BusinessClass = int.Parse(TicketsPrices[3]);
      flight.FirstPrice = int.Parse(TicketsPrices[4]);
      flight.FirstClass = int.Parse(TicketsPrices[5]);

      new TourAgency().addNewFlight(flight);
    }

    public void getFlights(string from, string to, string[] date, string passengerClass, int ticketCount)
    {

      DateOnly dateOnly = new DateOnly(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));


      List<FlightsVm> tickets = Form1.TourAgencyArray[0].getListOfFlights(from, to, dateOnly, passengerClass, ticketCount);

      if (tickets.Count > 0)
      {

        foreach (FlightsVm ticket in tickets)
        {
          var rand = new Random();

          int ticketClassPrice = 0;
          switch (passengerClass) 
          {
            case "Economy":
              ticketClassPrice = ticket.EconomyPrice;
              break;
            case "Business":
              ticketClassPrice = ticket.BusinessPrice;
              break;
            case "First":
              ticketClassPrice = ticket.FirstPrice;
              break;
          }

          string rating = $"{rand.Next(1, 5)}.{rand.Next(1, 9)}";

          string script = $"window.loadTicketsToListening({ticket.Id}, {rating}, '{ticket.AirLines}', {ticketClassPrice}, '{passengerClass}', '{ticket.DepartureTime}', '{ticket.ArrivalTime}');";


          Form1.browser.ExecuteScriptAsync(script);
        }
      }
      else
      {
        Form1.browser.ExecuteScriptAsync("alert('No tickets found')");
      }
    }
    public void buyFlightTicket(int id, string userEmail, string ticketType, int countTicket)
    {
      TouristVm touristInfo = new TourAgency().GetTouristInfo(userEmail);

      if (touristInfo == null)
      {
        Form1.browser.ExecuteScriptAsync("alert('Wrong user')");
        return;
      }

      BookingFlight tourist = new BookingFlight();
      tourist.setTouristInfo(touristInfo);

      bool isTicketBuyed = tourist.buyTicket(id, ticketType, countTicket);

      if (isTicketBuyed)
      {
        Form1.browser.ExecuteScriptAsync("alert('Ticket purchased')");
      }
      else
      {
        Form1.browser.ExecuteScriptAsync("alert('Ticket not purchased, error')");
      }

    }

    public void getPurchasedTickets(string email)
    {
      Tourist tourist = new Tourist();
      tourist.getPurchasedFlightsTicket(email);
    }
  }
}
