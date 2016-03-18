using emsDALEF.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF
{
    public class ManagerDAFactory
    {
        private ManagerDA obj;

        public ManagerDAFactory()
        {
            obj = new ManagerDA();
        }
        public void updateCurrentLogin(table_Manager manager)
        {
            obj.updateCurrentLogin(manager);
        }
        public DateTime findMe(String name, String password)
        {
            return obj.findMe(name, password);
        }
        public table_Manager findMyObj(String name, String password)
        {
            return obj.findMyObj(name, password);
        }

        public void updateLastLogin(table_Manager manager)
        {
            obj.updateLastLogin(manager);
        }
        public bool addManager(String name, String password, long cell, String email)
        {
            return obj.addManager(name, password, cell, email);
        }

        public bool addEvent(table_Event rem)
        {
            return obj.addEvent(rem);
        }
        public DateTime checkCurrentLogin(table_Manager manager)
        {
            return obj.checkCurrentLogin(manager);
        }
        public bool addBus(table_Bus bus)
        {
            return obj.addBus(bus);
        }
        public List<table_Event> viewEvents()
        {
            return obj.viewEvents();
        }
        public bool removeEvent(table_Event rem)
        {
            return obj.removeEvent(rem);
        }
        public bool addDestination(table_Destination destination)
        {
            return obj.addDestination(destination);
        }
        public bool addRoute(table_Route route)
        {
            return obj.addRoute(route);
        }
        public bool addGuard(table_Guard guard)
        {
            return obj.addGuard(guard);
        }
        public bool logIn(String name, String password)
        {
            return obj.logIn(name, password);
        }
    }
}