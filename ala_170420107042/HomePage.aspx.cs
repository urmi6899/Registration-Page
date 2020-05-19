using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ala_170420107042
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*string username = Response.Cookies["userinfo"]["txtUserName"];
            string password = Response.Cookies["userinfo"]["txtPassword"];*/
            //Label1.Text = Response.Cookies["userinfo"].Value;
            HttpCookie cookie = Request.Cookies["userinfo"];
            Label1.Text = cookie["username"] ;
        }
    }
}