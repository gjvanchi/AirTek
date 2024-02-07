using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek.Model
{
    class Flight
    {
        public int Id { get; set; }
        public string IATASource { get; set; }
        public string IATADestination { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Day { get; set; }
    }
}
