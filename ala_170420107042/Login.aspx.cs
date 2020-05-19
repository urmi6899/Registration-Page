using MySql.Data.MySqlClient;
using System;
using System.Web;

namespace ala_170420107042
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        MySqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            server = "localhost";
            database = "ala";
            uid = "root";
            password = "sql6899";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            connection.Open();
            HttpCookie userinfo = new HttpCookie("userinfo");
            userinfo.Values.Add("username", txtUserName.Text);
            userinfo.Values.Add("password", txtPassword.Text);
            userinfo.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(userinfo);

            //userinfo.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(userinfo);

            MySqlCommand cmd = new MySqlCommand("select * from login where username = @p1 and password = @p2", connection);
            cmd.Parameters.AddWithValue("@p1", txtUserName.Text);
            cmd.Parameters.AddWithValue("@p2", txtPassword.Text);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Session["user"] = dr[1].ToString();
                dr.Close();
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblErrorMessage.Visible = true;
            }
        }
    }
}