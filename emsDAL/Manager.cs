using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDAL
{
    class Manager
    {
        public int id { get; set; }
        public String name { get; set; }
        public int phone { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public DateTime last_login { get; set; }
        public DateTime current_login { get; set; }

    }
}
