using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDOReport.Styles
{
    public partial class fromPHP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //foreach (string name in Request.Form)
            //{
            //    Response.Write(Request.Form[name]);
            //}
            Response.Write("utente: " + Request.Form["user"] + "<br>");
            Response.Write("password: " + Request.Form["pwd"] + "<br>");
            Response.Write("report: " + Request.Form["report"] + "<br>");

        }   
    }
}