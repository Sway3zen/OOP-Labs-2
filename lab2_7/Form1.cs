using CefSharp;
using CefSharp.WinForms;
using CefSharp.JavascriptBinding;
using CefSharp.DevTools.Database;
using lab2_7.Data;
using lab2_7.Model;

using System.Runtime.InteropServices;

namespace lab2_7
{
  public partial class Form1 : Form
  {
    public static ChromiumWebBrowser browser;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      //AllocConsole();

      CefSettings settings = new CefSettings();
      Cef.Initialize(settings);

      string path = "http://localhost:5173/";
      //string path = "C:\\Users\\Swayze\\source\\repos\\Labs\\lab2_7\\cef\\build\\index.html";
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

      new AddFlight(flight);
    }
  }
}
