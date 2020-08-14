using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace hotelmanagement
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(Database.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from client where client_id=@username and password=@password ", con);
            cmd.Parameters.AddWithValue("@username", TxtLogin.Text);
            cmd.Parameters.AddWithValue("@password", TxtPassword.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Session["id"] = TxtLogin.Text;
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                lblMsg.Text = "UserId & Password Is not correct Try again..!!";
            }
        }

        protected void TxtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgotpassword.aspx");
        }
    }
}