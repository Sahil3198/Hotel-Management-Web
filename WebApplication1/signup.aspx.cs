using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;

namespace HotelManagement
{
    public partial class signup : System.Web.UI.Page
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
        public static void SendEmail(string client, string email, string firstname, string Lastname, string mobile)
        {
            MailMessage mailMessage = new MailMessage("continentalhotelsahil@gmail.com", email);
            mailMessage.Body = "Welcome " + firstname + " " + Lastname + Environment.NewLine +
                                "Your Registartion is Successfully done." + Environment.NewLine +
                                "Your client ID is " + client +".";
            mailMessage.Subject = "Welcome to Hotel Continental";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "continentalhotelsahil@gmail.com",
                Password = "%TGB6yhn^YHN5tgb"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String client = TextBox1.Text;
                String firstname = TextBox3.Text;
                String Lastname = TextBox4.Text;
                String email = TextBox6.Text;
                String mobile = TextBox7.Text;
                String password = TextBox2.Text;
                int flag = 0;
                conn.Open();
                cmd = new SqlCommand("select * from client", conn);
                sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    if(sdr["email_id"].ToString()==email)
                    {
                        flag=1;
                        break;
                    }
                    else if(sdr["client_id"].ToString() == client)
                    {
                        flag = 2;
                        break;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
                conn.Close();

                if (flag==1)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Email id already registered.');", true);
                }
                else if(flag==2)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Client Id not available.Client Id already useable');", true);
                }
                else
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into client values('" + client + "','" + firstname + "','" + Lastname + "','" + email + "','" + mobile + "','" + password + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    string sendEmail = ConfigurationManager.AppSettings["SendEmail"];
                    if (sendEmail.ToLower() == "true")
                    {
                        SendEmail(client, email, firstname, Lastname, mobile);
                    }
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your Registration Successfully done.'); window.location = 'login.aspx';" , true);
                }
            }
            catch (Exception)
            {
                Label1.Visible = true;
                Label1.Text = "Please Fill All The Details";
            }
        } 
    }
}