using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF.DataLayer
{
    class EventDA
    {
        emsDBContext _dbContext;

        public EventDA()
        {
            _dbContext = new emsDBContext();
        }

        public bool addEvent(table_Event evet)
        {
            _dbContext.table_Event.Add(evet);
            return _dbContext.SaveChanges() > 0;
        }

        public bool deleteEvent(String name)
        {
            var evet = _dbContext.table_Event.Where(x => x.event_name == name).FirstOrDefault();
            if (evet != null)
                _dbContext.table_Event.Remove(evet);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
