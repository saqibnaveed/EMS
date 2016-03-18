using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF.DataLayer
{
    class UserDA
    {

        emsDBContext _dbcontext;

        public UserDA()
        {
            _dbcontext = new emsDBContext();

        }


        public DateTime checkCurrentLogin(table_User user)
        {
            return (DateTime)user.user_current_login;
        }

        public DateTime checkLastLogin(table_User user)
        {
            return (DateTime)user.user_last_login;
        }

        public void updateCurrentLogin(table_User user)
        {
            System.DateTime curtime = new System.DateTime();
            curtime = System.DateTime.Now;
            try
            {
                user.user_current_login = curtime;
            }
            catch (Exception ex) { }
            _dbcontext.SaveChanges();
        }
        public void updateLastLogin(table_User user)
        {
            try
            {
                user.user_last_login = user.user_current_login;
            }
            catch (Exception ex) { }
            _dbcontext.SaveChanges();
        }
        public table_User findMe(String name, String password)
        {
            var obj = _dbcontext.table_User.Where(x => x.user_name == name).FirstOrDefault();
            if (obj != null)
                if (obj.user_name == name && obj.user_password == password)
                    return obj;
            return null;
        }
        public table_User findMyObj(String name, String password)
        {
            var obj = _dbcontext.table_User.Where(x => x.user_name == name).FirstOrDefault();
            if (obj != null)
                if (obj.user_name == name && obj.user_password == password)
                    return obj;
            return null;
        }
        public bool signUp(table_User obj)
        {
            _dbcontext.table_User.Add(obj);
            return _dbcontext.SaveChanges() > 0;
        }

        //public bool logIn(table_User obj)
        //{
        //    _dbcontext.table_User.s
        //}

        public void registerEvent(String name, int eventID)
        {
            var user = _dbcontext.table_User.Where(x => x.user_name == name).FirstOrDefault();
            var evet = _dbcontext.table_Event.Where(x => x.C_Event_id == eventID).FirstOrDefault();

        }

        public DateTime lastLogin(String name)
        {
            var user = _dbcontext.table_User.Where(x => x.user_name == name).FirstOrDefault();
            return (DateTime)user.user_current_login;
        }
        public bool logIn(String name, String password)
        {
            var obj = _dbcontext.table_User.Where(x => x.user_name == name).FirstOrDefault();
            if(obj!=null)
            if (obj.user_name == name && obj.user_password == password)
                return true;
            return false;
        }
        public List<table_Event> viewEvents()
        {
            var obj = _dbcontext.table_Event.ToList();
            return obj;
        }

        public bool registerEvent(table_Event evet, int id)
        {
            var obj = _dbcontext.table_User.Where(x => x.C_User_id == id).FirstOrDefault();
            if (obj != null)
            {
                obj.f_event_id = evet.C_Event_id;
            }
            return _dbcontext.SaveChanges() > 0;
        }

        public table_Event currentEvent(table_User user)
        {

            if (user.f_event_id != null)
            {
                var obj = _dbcontext.table_Event.Where(x => x.C_Event_id == user.f_event_id).FirstOrDefault();

                return obj;
            }
            else return null;
        }

        public bool removeCurrentEvent(table_User user)
        {
            if (user.f_event_id != null)
            {
                user.f_event_id = null;
            }
            return _dbcontext.SaveChanges() > 0;
        }



    }
}
