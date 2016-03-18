using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsModels
{
  public  class mainWindowViewModel : IDataErrorInfo
    {
        #region Variables
        private String _name = "Enter Name";
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }
        private String _password = "Enter Password";
        public String password
        {
            get { return _password; }
            set { _password = value; }
        }
        private String _cell = "Enter Cell";
        public String cell
        {
            get { return _cell; }
            set { _cell = value; }
        }
        private String _email = "Enter Email";
        public String email
        {
            get { return _email; }
            set { _email = value; }
        }

#endregion

        public string this[string columnName]
        {
            get
            {
                String result = "";
                if(columnName=="name")
                {
                    if (string.IsNullOrEmpty(this._name))
                        result = "Please enter name";

                }
                if (columnName == "password")
                {
                    if (string.IsNullOrEmpty(this._password))
                        result = "Please enter password";
                }
                if (columnName == "email")
                {
                    if (string.IsNullOrEmpty(this._email))
                        result = "Please enter email";
                }
                if (columnName == "cell")
                {
                    int ignore;
                    bool successfullyParsed = int.TryParse(this._cell, out ignore);
                    if (string.IsNullOrEmpty(this._cell))
                        result = "Please enter cell";
                    if(!successfullyParsed && this._cell != "Enter Cell")
                        result = "Please enter numbers only";
                }

                return result;
                throw new NotImplementedException();
               
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
