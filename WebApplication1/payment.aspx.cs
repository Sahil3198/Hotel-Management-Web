using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace HotelManagement
{
    public partial class payment : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(Database.ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        SqlDataReader sdr;
        DataTable dt;
        DataRow dr;
        DataSet ds;
        int amount, rooms, total;
        string hotel;
        string checkin, checkout, roomtype;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("homepage.aspx");
            }
            Label1.Text = Request.QueryString["Name"];
            amount = Convert.ToInt32(Request.QueryString["name1"]);
            rooms  = Convert.ToInt32(Request.QueryString["name2"]);
            hotel = Request.QueryString["hotel"];
            total = amount * rooms;
            Label2.Text = total.ToString();
            roomtype = (string)(Session["roomtype"]);
            checkin= (string)(Session["checkin"]);
            checkout = (string)(Session["checkout"]);
        }
        public static void SendEmail(string emailid,string bookingid,string client,string amount,string roomtype,string checkin,string hotel,string checkout)
        {
            string email = emailid;
            MailMessage mailMessage = new MailMessage("continentalhotelsahil@gmail.com", email);
            mailMessage.IsBodyHtml=true;
            mailMessage.Body= "Welcome To Our Hotel Continental." +
                "<table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + ">" +
                "<tr bgcolor='#1a53ff'>" +
               "<th text-align='center' colspan='7'><h1>Booking Information</h1></th>" +
               "</tr>" +
              "<tr bgcolor='#668cff'>" +
               "<th><h2>Hotel Name</h2></th>" +
               "<th><h2>Room Type</h2></td>" +
               "<th><h2>Booking ID</h2></td>" +
               "<th><h2>Check In Date</h2></th>" +
               "<th><h2>Check Out Date</h2></th>" +
               "<th><h2>Total amount</h2></th>" +
               "</tr>" +

               "<tr>" +
               "<th><h3>" + hotel + "</h3></th>" +
               "<th><h3>" + roomtype + "</h3></th>" +
               "<th><h3>" + bookingid + "</h3></th>" +
               "<th><h3>" + checkin + "</h3></th>" +
               "<th><h3>" + checkout + "</h3></th>" +
               "<th><h3>" + amount + "</h3></th>" +
               "</tr>" +
              
             "</table>";
            /*mailMessage.Body = "Welcome To Our Hotel Continental." +Environment.NewLine+
                                "Your Rooms are Booked in " +hotel+"." + Environment.NewLine +
                                "You Select " + roomtype + " room." + Environment.NewLine +
                                "Your Booking id is " +bookingid+ "." + Environment.NewLine +
                                "Your Checkin Date is " + checkin + " and Checkout Date is " +checkout+"." + Environment.NewLine +
                                "You paid " +amount+" rs for room booking. " + Environment.NewLine +
                                "Thank You for Booking.";*/
            mailMessage.Subject = "Hotel Continental Booking";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "continentalhotelsahil@gmail.com",
                Password = "%TGB6yhn^YHN5tgb"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
        protected void payonline_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Update booking SET Client_name='" + TextBox1.Text + "',Email_id='" + TextBox2.Text + "',Total_amount='" + Label2.Text + "' where booking_Id='"+Label1.Text+"'", conn);
            sdr = cmd.ExecuteReader();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("Update bookingsecret SET Client_name='" + TextBox1.Text + "',Email_id='" + TextBox2.Text + "',Total_amount='" + Label2.Text + "' where booking_Id='" + Label1.Text + "'", conn);
            sdr = cmd.ExecuteReader();
            conn.Close();
            string emailid = TextBox2.Text;
            string bookingid = Label1.Text;
            string client = TextBox1.Text;
            string amount = Label2.Text;
            string sendEmail = ConfigurationManager.AppSettings["SendEmail"];
            if (sendEmail.ToLower() == "true")
            {
                SendEmail(emailid,bookingid,client,amount,roomtype,checkin,hotel,checkout);
            }
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your Rooms are Booked.Check Your Mail for all Booking information.'); window.location = 'homepage.aspx';", true);
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("delete from "+hotel+"_status where booking_id='"+Label1.Text+"'", conn);
            sdr = cmd.ExecuteReader();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand("delete from booking where booking_Id='" + Label1.Text + "'", conn);
            sdr = cmd.ExecuteReader();
            Response.Redirect("booking.aspx");
            conn.Close();
        }
    }
}