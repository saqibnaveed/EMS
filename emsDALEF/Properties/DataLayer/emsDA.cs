using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF.DataLayer
{
    public class emsDA
    {
        emsDBContext dbContext;

        public emsDA()
        {
            dbContext = new emsDBContext();
        }


    }
}
