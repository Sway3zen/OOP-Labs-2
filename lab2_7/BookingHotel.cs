using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_7
{
  public sealed class BookingHotel : Booking
  {
    public string HotelName { get; set; }
    public DateOnly DateStart { get; set; }
    public DateOnly DateEnd { get; set; }

    public override int getPrice()
    {
      throw new NotImplementedException();
    }

    public override bool buyTicket(int id, string type, int count)
    {
      throw new NotImplementedException();
    }

  }
}
