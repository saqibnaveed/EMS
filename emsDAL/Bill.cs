using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDAL
{
    class Bill
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public Double bill_paid { get; set; }
        public Double bill_return { get; set; }

    }
}
