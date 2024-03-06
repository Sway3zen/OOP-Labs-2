using lab2_7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_7
{
  public class Tourist
  {
    private readonly TouristVm touristVm = new TouristVm();
    public Tourist(TouristVm touristVm) {
      this.touristVm = touristVm;
    }


  }
}
