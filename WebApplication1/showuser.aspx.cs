using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;

namespace HotelManagement
{
    public partial class showuser : System.Web.UI.Page
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
            if (Session["id"] == null)
            {
                Response.Redirect("homepage.aspx");
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("n2");
            navDiv.Visible = false;
            Label2.Text = Session["id"].ToString();
            Label3.Text = Session["id"].ToString();
            showprofile();
            conn.Open();
            cmd = new SqlCommand("select * from booking where client_id='"+Label2.Text+"'", conn);
            sdr = cmd.ExecuteReader();
            GridView1.DataSource = sdr;
            GridView1.DataBind();
            conn.Close();
        }
        public void showprofile()
        {
            conn.Open();
            cmd = new SqlCommand("select * from client where client_id='" + Label2.Text + "'", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Label5.Text = sdr["client_id"].ToString();
                Label6.Text = sdr["First_name"].ToString();
                Label7.Text = sdr["Last_name"].ToString();
                Label8.Text = sdr["email_id"].ToString();
                Label9.Text = sdr["mobile"].ToString();
            }
            conn.Close();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            Panel2.Visible = false;
            Panel4.Visible = false;
            Panel1.Visible = true;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = false;
            Panel3.Visible = true;
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            Panel2.Visible = false;
            Panel1.Visible = false;
            Panel4.Visible = true;
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel2.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string s = TextBox1.Text.ToString();
                string hotelname="";
                conn.Open();
                cmd = new SqlCommand("select hotelname from booking where booking_Id='" + s + "'", conn);
                sdr=cmd.ExecuteReader();
                if(sdr.Read())
                {
                    hotelname = sdr["hotelname"].ToString();
                }
                conn.Close();
                conn.Open();
                cmd = new SqlCommand("delete from booking where booking_Id='"+s+"'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                cmd = new SqlCommand("delete from "+hotelname+"_status where booking_id='" + s + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cancellation of Booking is Successfully.');", true);
                TextBox1.Text = "";
            }
            catch(Exception)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No Data Found.');", true);
                TextBox1.Text = "";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string old = TextBox6.Text.ToString();
                string newone = TextBox7.Text.ToString();
                string s = "";
                conn.Open();
                cmd = new SqlCommand("select password from client where client_id='" + Label2.Text + "'", conn);
                sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    s = sdr["password"].ToString();
                }
                conn.Close();
                if (old == s)
                {
                    conn.Open();
                    cmd = new SqlCommand("UPDATE client SET password='" + newone + "' where client_id='" + Label2.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Password Successfully Changed.');", true);
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your Old Password is wrong.');", true);
                }
                conn.Close();
            }
            catch(Exception)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your Old Password is wrong.');", true);
            }
        }
    }
}