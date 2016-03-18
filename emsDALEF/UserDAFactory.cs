using emsDALEF.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsDALEF
{
    public class UserDAFactory
    {
        UserDA obj;

        public UserDAFactory()
        {
            obj = new UserDA();
        }
        public bool signUp(table_User obj)
        {

            return this.obj.signUp(obj);
        }

        public DateTime checkCurrentLogin(table_User user)
        {
            return obj.checkCurrentLogin(user);
        }
        public DateTime checkLastLogin(table_User user)
        {
            return obj.checkLastLogin(user);
        }
        public bool removeCurrentEvent(table_User user)
        {
            return obj.removeCurrentEvent(user);
        }
        public table_Event currentEvent(table_User user)
        {
            return obj.currentEvent(user);
        }
        public bool registerEvent(table_Event evet, int id)
        {
            return obj.registerEvent(evet, id);

        }
        public void updateCurrentLogin(table_User user)
        {
            obj.updateCurrentLogin(user);
        }

        public void updateLastLogin(table_User user)
        {
            obj.updateLastLogin(user);
        }
        public table_User findMe(String name, String password)
        {
            return obj.findMe(name, password);
        }
        public table_User findMyObj(String name, String password)
        {
            return obj.findMyObj(name, password);
        }

        public List<table_Event> viewEvents()
        {
            return obj.viewEvents();
        }

        public bool logIn(String name, String password)
        {
            return obj.logIn(name, password);
        }

    }
}
