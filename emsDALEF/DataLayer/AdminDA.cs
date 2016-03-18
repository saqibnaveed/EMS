using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF.DataLayer
{
    class AdminDA
    {
        emsDBContext _dbcontext;

        public AdminDA()
        {
            _dbcontext = new emsDBContext();

        }

        public bool addAdmin(String name, String password, long cell, String email) {
            table_Admin admin = new table_Admin();
            admin.admin_email = email;
            admin.admin_name = name;
            admin.admin_password = password;
            admin.admin_phone = cell;
            admin.admin_current_login = DateTime.Now;
            _dbcontext.table_Admin.Add(admin);
            return _dbcontext.SaveChanges() > 0;
        }


        public List<table_Admin> getAdmins()
        {
            return _dbcontext.table_Admin.ToList();
        }

        public bool deleteAdminByName(String adminName)
        {
            var obj = _dbcontext.table_Admin.Where(x => x.admin_name == adminName).FirstOrDefault();
            if (obj != null)
                _dbcontext.table_Admin.Remove(obj);
            return _dbcontext.SaveChanges() > 0;
        }
        public bool deleteAdminByID(String adminID)
        {
            var obj = _dbcontext.table_Admin.Where(x => x.C_Admin_id == int.Parse(adminID)).FirstOrDefault();
            if (obj != null)
                _dbcontext.table_Admin.Remove(obj);
            return _dbcontext.SaveChanges() > 0;
        }

        public List<table_Admin> getAdminByName(String adminName)
        {
            List<table_Admin> admin = _dbcontext.table_Admin.Where(x => x.admin_name == adminName).ToList();
            if (admin != null)
                return admin;
            return null;
        }

        public bool addManager(table_Manager manager)
        {
            _dbcontext.table_Manager.Add(manager);
            return _dbcontext.SaveChanges() > 0;
        }

        public List<table_User>searchUser(String name)
        {
            var usr = _dbcontext.table_User.Where(x => x.user_name == name).ToList();
            return usr.ToList<table_User>();
        }

        public bool makeUserAdmin(table_User user)
        {
            _dbcontext.table_User.Remove(user);
            table_Admin adminUser = new table_Admin();
            adminUser.admin_current_login = user.user_current_login;
            adminUser.admin_email = user.user_email;
            adminUser.admin_last_login = user.user_last_login;
            adminUser.admin_name = user.user_name;
            adminUser.admin_password = user.user_password;
            adminUser.admin_phone = user.user_phone;

            _dbcontext.table_Admin.Add(adminUser);
            return _dbcontext.SaveChanges()>0;
        }



        public bool removeUser(String name)
        {
            var user = _dbcontext.table_User.Where(x => x.user_name == name).FirstOrDefault();
            if (user != null)
                _dbcontext.table_User.Remove(user);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool removeUser(table_User user)
        {
            try
            {
                _dbcontext.table_User.Remove(user);
            }
            catch (Exception ex) { }
            return _dbcontext.SaveChanges() > 0;
        }

        public bool addGuard(String name, long cell)
        {
            table_Guard guard= new table_Guard();
            guard.guard_name = name;
            guard.guard_cell = (int)cell;
            _dbcontext.table_Guard.Add(guard);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool addBus(table_Bus bus)
        {
            _dbcontext.table_Bus.Add(bus);
            return _dbcontext.SaveChanges() > 0;
        }


        public bool addDestination(table_Destination destination)
        {
            _dbcontext.table_Destination.Add(destination);
            return _dbcontext.SaveChanges() > 0;
        }
        public bool addRoute(String name)
        {
            table_Route route = new table_Route();
            route.route_path = name;
            _dbcontext.table_Route.Add(route);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool removeGuard(String rem)
        {
            var obj = _dbcontext.table_Guard.Where(x=>x.guard_name==rem).FirstOrDefault();
            if (obj != null)
                _dbcontext.table_Guard.Remove(obj);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool removeBus(String rem)
        {
            var obj = _dbcontext.table_Bus.Where(x => x.bus_driver_name == rem).FirstOrDefault();
            if (obj != null)
                _dbcontext.table_Bus.Remove(obj);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool addDriver(String name, long cell)
        {
            table_Bus driver = new table_Bus();
            driver.bus_driver_name = name;
            driver.bus_driver_cell = (int)cell;
            _dbcontext.table_Bus.Add(driver);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool removeDestination(int rem)
        {
            var obj = _dbcontext.table_Destination.Where(x => x.C_Destination_id == rem).FirstOrDefault();
            if (obj != null)
                _dbcontext.table_Destination.Remove(obj);
            return _dbcontext.SaveChanges() > 0;
        }

        public bool removeRoute(int rem)
        {
            var obj = _dbcontext.table_Route.Where(x => x.C_Route_id == rem).FirstOrDefault();
            if (obj != null)
                _dbcontext.table_Route.Remove(obj);
            return _dbcontext.SaveChanges() > 0;
        }

        public List<table_Event> viewEvents()
        {
            var obj = _dbcontext.table_Event.ToList();
            return obj;
        }

        public bool removeEvent(table_Event rem)
        {
            _dbcontext.table_Event.Remove(rem);
            return _dbcontext.SaveChanges() > 0;
        }

        public DateTime checkCurrentLogin(table_Admin admin)
        {
            return (DateTime)admin.admin_current_login;
        }

        public List<table_User> viewUsers()
        {
            var obj = _dbcontext.table_User.ToList();
            return obj;
        }

        public DateTime checkLastLogin(table_Admin admin)
        {
            return (DateTime)admin.admin_last_login;
        }

        public void updateCurrentLogin(table_Admin admin)
        {
            System.DateTime curtime = new System.DateTime();
            curtime = System.DateTime.Now;
            try
            {
                admin.admin_current_login = curtime;
            }
            catch (Exception ex) { }
            _dbcontext.SaveChanges();
        }
        public void updateLastLogin(table_Admin admin)
        {
            try
            {
                admin.admin_last_login = admin.admin_current_login;
            }
            catch (Exception ex) { }
            _dbcontext.SaveChanges();
        }

        public bool logIn(String name, String password)
        {
            var obj = _dbcontext.table_Admin.Where(x => x.admin_name == name).FirstOrDefault();
            if (obj != null)
                if (obj.admin_name == name && obj.admin_password == password)
                    return true;
            return false;
        }
        public DateTime findMe(String name, String password)
        {
            var obj = _dbcontext.table_Admin.Where(x => x.admin_name == name).FirstOrDefault();
            if (obj != null)
                if (obj.admin_name == name && obj.admin_password == password)
                    return checkLastLogin(obj);
            return DateTime.Now;
        }

        public table_Admin findMyObj(String name, String password)
        {
            var obj = _dbcontext.table_Admin.Where(x => x.admin_name == name).FirstOrDefault();
            if (obj != null)
                if (obj.admin_name == name && obj.admin_password == password)
                    return obj;
            return null;
        }
    }
}
