using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataHelper
{
    public static class DbHelper
    {
        #region Get Setup Config Data
        public static string get_configuration(string key)
        {
            JObject ConnectionJson = null;
            string ConnectionString = string.Empty;
            try
            {
                ConnectionJson = JObject.Parse(File.ReadAllText("appsettings.json"));
                return ConnectionJson[key].ToString();
            }
            catch (Exception ex)
            {
                //ErrorHandler objErrorHandler = new ErrorHandler();
                //return objErrorHandler.backend_error("DB helper error", ex);
                throw ex.GetBaseException();
            }
        }
        #endregion
    }
}
