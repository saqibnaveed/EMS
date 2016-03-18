using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF.DataLayer
{
    class User
    {
        public int id { get; set; }
        public String name { get; set; }
        public String password { get; set; }
        public int phone { get; set; }
        public String email { get; set; }
        public DateTime last_login { get; set; }
        public DateTime current_login { get; set; }
        public int event_id { get; set; }

    }
}
