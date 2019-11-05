using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.Model
{
    public class TruckModel
    {
        public string Number { get; set; }

        public string Type { get; set; }


        public DateTime BuyDate { get; set; }
        
        public DateTime CheckInTime { get; set; }
    }
}
