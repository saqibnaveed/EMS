using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emsModels
{
    public class adminViewModel : IDataErrorInfo
    {
        #region Variables
       
        #region Admin
        private String _nameAdmin = "Enter Name";

        public String nameAdmin
        {
            get { return _nameAdmin; }
            set { _nameAdmin = value; }
        }
        private String _passwordAdmin = "Enter Password";
        public String passwordAdmin
        {
            get { return _passwordAdmin; }
            set { _passwordAdmin = value; }
        }
        private String _cellAdmin = "Enter Cell";
        public String cellAdmin
        {
            get { return _cellAdmin; }
            set { _cellAdmin = value; }
        }
        private String _emailAdmin = "Enter Email";
        public String emailAdmin
        {
            get { return _emailAdmin; }
            set { _emailAdmin = value; }
        }
        #endregion

        #region Manager
        private String _nameManager = "Enter Name";

        public String nameManager
        {
            get { return _nameManager; }
            set { _nameManager = value; }
        }
        private String _passwordManager = "Enter Password";
        public String passwordManager
        {
            get { return _passwordManager; }
            set { _passwordManager = value; }
        }
        private String _cellManager = "Enter Cell";
        public String cellManager
        {
            get { return _cellManager; }
            set { _cellManager = value; }
        }
        private String _emailManager = "Enter Email";
        public String emailManager
        {
            get { return _emailManager; }
            set { _emailManager = value; }
        }
        #endregion

        #region Bus
        private String _nameDriver = "Enter Name";

        public String nameDriver
        {
            get { return _nameDriver; }
            set { _nameDriver = value; }
        }
        private String _cellDriver = "Enter Cell";
        public String cellDriver
        {
            get { return _cellDriver; }
            set { _cellDriver = value; }
        }

        #endregion

        #region Guard
        private String _nameGuard = "Enter Name";

        private String _cellGuard = "Enter Cell";

        public String nameGuard
        {
            get { return _nameGuard; }
            set { _nameGuard = value; }
        }

        public String cellGuard
        {
            get { return _cellGuard; }
            set { _cellGuard = value; }
        }

        #endregion

        #region Route

        private String _namePath = "Enter Path";
        public String namePath
        {
            get
            { return _namePath; }
            set
            { _namePath = value; }
        }
        #endregion

        #region change
        private String _nameChange = "Enter Name";

        public String nameChange
        {
            get { return _nameChange; }
            set { _nameChange = value; }
        }
        #endregion

        #endregion

        public string this[string columnName]
        {
            get
            {
                String result = "";

                #region Check Admin Values
                if (columnName == "nameAdmin")
                {
                    if (string.IsNullOrEmpty(this._nameAdmin))
                        result = "Please enter name";

                }
                if (columnName == "passwordAdmin")
                {
                    if (string.IsNullOrEmpty(this._passwordAdmin))
                        result = "Please enter password";

                }
                if (columnName == "emailAdmin")
                {
                    if (string.IsNullOrEmpty(this._emailAdmin))
                        result = "Please enter email";

                }
                if (columnName == "cellAdmin")
                {
                    int ignore;
                    bool successfullyParsed = int.TryParse(this._cellAdmin, out ignore);

                    if (string.IsNullOrEmpty(this._cellAdmin))
                        result = "Please enter cell";
                    else if (!successfullyParsed && (this._cellAdmin != "Enter Cell"))
                        result = "Please enter numbers only";
                }
                #endregion

                #region Check Manager Values
                if (columnName == "nameManager")
                {
                    if (string.IsNullOrEmpty(this._nameManager))
                        result = "Please enter name";

                }
                if (columnName == "passwordManager")
                {
                    if (string.IsNullOrEmpty(this._passwordManager))
                        result = "Please enter password";

                }
                if (columnName == "emailManager")
                {
                    if (string.IsNullOrEmpty(this._emailManager))
                        result = "Please enter email";

                }
                if (columnName == "cellManager")
                {
                    int ignore;
                    bool successfullyParsed = int.TryParse(this._cellManager, out ignore);

                    if (string.IsNullOrEmpty(this._cellManager))
                        result = "Please enter cell";
                    else if (!successfullyParsed && (this._cellManager != "Enter Cell"))
                        result = "Please enter numbers only";
                }
                #endregion

                #region Check Bus
                if (columnName == "nameDriver")
                {
                    if (string.IsNullOrEmpty(this._nameDriver))
                        result = "Please enter name";

                }
                if (columnName == "cellDriver")
                {
                    int ignore;
                    bool successfullyParsed = int.TryParse(this._cellDriver, out ignore);

                    if (string.IsNullOrEmpty(this._cellDriver))
                        result = "Please enter cell";
                    else if (!successfullyParsed && (this._cellDriver != "Enter Cell"))
                        result = "Please enter numbers only";
                }
                #endregion

                #region Check Guard
                if (columnName == "nameGuard")
                {
                    if (string.IsNullOrEmpty(this._nameGuard))
                        result = "Please enter name";

                }
                if (columnName == "cellGuard")
                {
                    int ignore;
                    bool successfullyParsed = int.TryParse(this._cellGuard, out ignore);

                    if (string.IsNullOrEmpty(this._cellGuard))
                        result = "Please enter cell";
                    else if (!successfullyParsed && (this._cellGuard != "Enter Cell"))
                        result = "Please enter numbers only";
                }
                #endregion

                #region Check Route
                if (columnName == "pathName")
                {
                    if (string.IsNullOrEmpty(this._namePath))
                        result = "Please enter path";

                }
                #endregion

                #region Check Change
                if (columnName == "nameChange")
                {
                    if (string.IsNullOrEmpty(this._nameChange))
                        result = "Please enter name";

                }

                #endregion
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
