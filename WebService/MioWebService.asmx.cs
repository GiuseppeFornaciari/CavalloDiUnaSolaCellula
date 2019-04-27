using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyWebServer
{
    /// <summary>
    /// Summary description for MioWebService
    /// </summary>
    [WebService(Namespace = "http://www.cavallodiunasolacellula.org/WebService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MioWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string TestWS()
        {
            return "utente,passord";
        }
    }
}
