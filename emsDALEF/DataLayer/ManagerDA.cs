using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF.DataLayer
{
    class ManagerDA
    {
        emsDBContext _dbcontext;
        public ManagerDA()
        {
            _dbcontext = new emsDBContext();

        }
        public DateTime findMe(String name, String password)
        {
            var obj = _dbcontext.table_Manager.Where(x => x.manager_name == name).FirstOrDefault();
            if (obj != null)
                if (obj.manager_name == name && obj.manager_password == password)
                    return checkLastLogin(obj);
            return DateTime.Now;
        }
        public table_Manager findMyObj(String name, String password)
        {
            var obj = _dbcontext.table_Manager.Where(x => x.manager_name == name).FirstOrDefault();
            if (obj != null)
                if (obj.manager_name == name && obj.manager_password == password)
                    return obj;
            return null;
        }
        public DateTime checkCurrentLogin(table_Manager manager)
        {
            return (DateTime)manager.manager_current_login;
        }

        public DateTime checkLastLogin(table_Manager manager)
        {
            return (DateTime)manager.manager_last_login;
        }

        public void updateCurrentLogin(table_Manager manager)
        {
            System.DateTime curtime = new System.DateTime();
            curtime = System.DateTime.Now;
            try
            {
                manager.manager_current_login = curtime;
            }
            catch (Exception ex) { }
            _dbcontext.SaveChanges();
        }
        public void updateLastLogin(table_Manager manager)
        {
            try
            {
                manager.manager_last_login = manager.manager_current_login;
            }
            catch (Exception ex) { }
            _dbcontext.SaveChanges();
        }

        public bool addManager(String name, String password, long cell, String email)
        {
            table_Manager manager = new table_Manager();
            manager.manager_email = email;
            manager.manager_name = name;
            manager.manager_password = password;
            manager.manager_phone = cell;
            manager.manager_current_login = DateTime.Now;
            _dbcontext.table_Manager.Add(manager);
            return _dbcontext.SaveChanges() > 0;
        }
        public bool logIn(String name, String password)
        {
            var obj = _dbcontext.table_Manager.Where(x => x.manager_name == name).FirstOrDefault();
            if (obj != null)
                if (obj.manager_name == name && obj.manager_password == password)
                    return true;
            return false;
        }

        public bool addDestination(table_Destination destination)
        {
            _dbcontext.table_Destination.Add(destination);
            return _dbcontext.SaveChanges() > 0;
        }
        public bool addRoute(table_Route route)
        {
            _dbcontext.table_Route.Add(route);
            return _dbcontext.SaveChanges() > 0;
        }
        public List<table_Event> viewEvents()
        {
            var obj = _dbcontext.table_Event.ToList();
            return obj;
        }
        public bool addGuard(table_Guard guard)
        {
            _dbcontext.table_Guard.Add(guard);
            return _dbcontext.SaveChanges() > 0;
        }
        public bool addEvent(table_Event rem)
        {
            _dbcontext.table_Event.Add(rem);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool addBus(table_Bus bus)
        {
            _dbcontext.table_Bus.Add(bus);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool removeEvent(table_Event rem)
        {
            _dbcontext.table_Event.Remove(rem);
            return _dbcontext.SaveChanges() > 0;
        }

    }
}
