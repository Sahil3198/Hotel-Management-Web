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
    public partial class forgotpassword : System.Web.UI.Page
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

        }
        public static void SendEmail(string clientid,string password, string email)
        {
            MailMessage mailMessage = new MailMessage("continentalhotelsahil@gmail.com", email);
            mailMessage.Body = "Dear User"+ Environment.NewLine +
                                "Your Registartion Client Id: "+clientid+ Environment.NewLine +
                                "Your Password: " + password +"";
            mailMessage.Subject = "Hotel Continental";
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
            string clientid = "";
            string password="";
            int flag = 0;
            conn.Open();
            cmd = new SqlCommand("select email_id from client", conn);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr["email_id"].ToString() == TextBox1.Text)
                {
                    flag = 1;
                    break;
                }
                else
                {
                    flag = 0;
                }
            }
            conn.Close();

            if (flag == 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Email Address not Register..');", true);
            }
            else
            {
                conn.Open();
                string email = TextBox1.Text;
                cmd = new SqlCommand("select * from client where email_id='"+email+"'", conn);
                sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    clientid = sdr["client_id"].ToString();
                    password = sdr["password"].ToString();
                }
                conn.Close();
                string sendEmail = ConfigurationManager.AppSettings["SendEmail"];
                if (sendEmail.ToLower() == "true")
                {
                    SendEmail(clientid,password,email);
                }
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your Password sent your Email Address.Check Your Email.'); window.location = 'login.aspx';", true);
            }
        }
    }
}