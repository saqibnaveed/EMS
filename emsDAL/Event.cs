using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDAL
{
    class Event
    {
        public int id { get; set; }
        public String name { get; set; }
        public int destination_id { get; set; }
        public int picture_id { get; set; }
        public int guard_id { get; set; }
        public int bus_id { get; set; }
        public int manager_id { get; set; }
        public int duration { get; set; }

    }
}
