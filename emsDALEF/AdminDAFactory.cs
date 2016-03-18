using emsDALEF.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF
{
    public class AdminDAFactory
    {
        private AdminDA obj;

        public AdminDAFactory()
        {
            obj = new AdminDA();
        }


        public void updateCurrentLogin(table_Admin admin)
        {
            obj.updateCurrentLogin(admin);
        }

        public void updateLastLogin(table_Admin admin)
        {
            obj.updateLastLogin(admin);
        }

        public bool addAdmin(String name, String password, long cell, String email)
        {
            return obj.addAdmin(name, password, cell, email);
        }

        public List<table_Admin> getAdmins()
        {
            return obj.getAdmins();
        }

        public bool deleteAdminByName(String adminName)
        {
            return obj.deleteAdminByName(adminName);
        }

        public bool deleteAdminByID(String adminID)
        {
            return obj.deleteAdminByID(adminID);
        }

        public List<table_Admin> getAdminByName(String adminName)
        {
            return obj.getAdminByName(adminName);
        }

        public bool addManager(table_Manager manager)
        {
            return obj.addManager(manager);
        }

        public List<table_User> searchUser(String name)
        {
            return obj.searchUser(name);
        }

        public bool makeUserAdmin(table_User user)
        {
            return obj.makeUserAdmin(user);
        }
        public bool removeUser(table_User user)
        {
            return obj.removeUser(user);
        }

        public bool removeUser(String user)
        {
            return obj.removeUser(user);
        }

        public bool addGuard(String name, long cell)
        {
            return obj.addGuard(name, cell);
        }

        public bool addBus(table_Bus bus)
        {
            return obj.addBus(bus);
        }
        public bool addDestination(table_Destination destination)
        {
            return obj.addDestination(destination);
        }
        public DateTime checkLastLogin(table_Admin admin)
        {
            return obj.checkLastLogin(admin);
        }
        public bool addRoute(String route)
        {
            return obj.addRoute(route);
        }

        public bool removeGuard(String rem)
        {
            return obj.removeGuard(rem);
        }

        public bool removeBus(String rem)
        {
            return obj.removeBus(rem);
        }


        public bool removeDestination(int rem)
        {
            return obj.removeDestination(rem);
        }

        public bool removeRoute(int rem)
        {
            return obj.removeRoute(rem);
        }

        public List<table_Event> viewEvent()
        {
            return obj.viewEvents();
        }
        public List<table_User> viewUsers()
        {
            return obj.viewUsers();
        }
        public bool removeEvent(table_Event rem)
        {
            return obj.removeEvent(rem);
        }

        public DateTime checkCurrentLogin(table_Admin admin)
        {
            return obj.checkCurrentLogin(admin);
        }

        public bool logIn(String name, String password)
        {
            return obj.logIn(name, password);
        }

        public DateTime findMe(String name, String password)
        {
            return obj.findMe(name, password);
        }

        public table_Admin findMyObj(String name, String password)
        {
            return obj.findMyObj(name, password);
        }

        public bool addDriver(String name, long cell)
        {
            return obj.addDriver(name, cell);
        }
    }
}
