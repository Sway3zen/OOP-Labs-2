using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_7.Model
{
  public class FlightsVm
  {
    public int Id { get; set; }
    public string AirLines { get; set; }
    public DateOnly DepartureDate { get; set; }
    public TimeOnly DepartureTime { get; set; }

    public DateOnly ArrivalDate { get; set; }
    public TimeOnly ArrivalTime { get; set; }

    public string DepartureFrom { get; set; }
    public string ArrivalTo { get; set; }

    public int EconomyClass { get; set; }
    public int EconomyPrice { get; set; }
    public int BusinessClass { get; set; }
    public int BusinessPrice { get; set; }
    public int FirstClass { get; set; }
    public int FirstPrice { get; set; }
  }
}
