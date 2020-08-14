using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagement
{
    public partial class feedback1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(Database.ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        SqlDataReader sdr;
        DataTable dt;
        DataRow dr;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String name = TextBox1.Text;
                String email = TextBox2.Text;
                String mobile = TextBox3.Text;
                String comment = TextBox4.Text;
                conn.Open();
                cmd = new SqlCommand("insert into feedback values('" + name + "','" + email + "','" + mobile + "','" + comment + "');", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Label1.Text = "Thank You for your Feedback!";
                Label1.Visible = true;
            }
            catch(Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}