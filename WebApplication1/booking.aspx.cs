using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
namespace HotelManagement
{
    public partial class booking : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(Database.ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        SqlDataReader sdr;
        DataTable dt;
        DataRow dr;
        DataSet ds;
        public void HotelsBindComboBox()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select Hotel_name from Hotels", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DropDownList1.Items.Add(sdr["Hotel_name"].ToString());
                }
                conn.Close();
            }
            catch
            {
                Response.Write("Error");
            }
        }
        public void RoomsTypeBindComboBox()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select room_type from Type_of_room", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DropDownList2.Items.Add(sdr["room_type"].ToString());
                }
                conn.Close();
            }
            catch
            {
                Response.Write("Error");
            }
        }
        public void calllogout()
        {
            Session.Abandon();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"]==null)
            {
                Response.Redirect("homepage.aspx");
            }
            HtmlContainerControl navDiv = (HtmlContainerControl)this.Master.FindControl("n1");
            navDiv.Visible = false;
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["id"] != null)
            {
                Label5.Text = Session["id"].ToString();
            }
            
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                HotelsBindComboBox();
                RoomsTypeBindComboBox();
            }
        }
        private string Random()
        {
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000);
            string s = random.ToString();
            return s;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                try
                {
                    String hotelname = DropDownList1.SelectedItem.ToString();
                    hotelname = hotelname.Replace(" ", "_");
                    String roomtype = DropDownList2.SelectedItem.ToString();
                    String rooms = DropDownList3.SelectedItem.ToString();
                    int room = Convert.ToInt32(rooms);
                    int available = Convert.ToInt32(Label2.Text);
                    String client = Label5.Text.ToString();
                    String booking_id = "con" + client.Substring(0, 2) + Random();
                    String price = Label1.Text;

                    conn.Open();
                    sda = new SqlDataAdapter("select * from " + hotelname + " where roomtype='" + roomtype + "'", conn);
                    dt = new DataTable();
                    sda.Fill(dt);
                    int no = dt.Rows.Count;
                    conn.Close();

                    conn.Open();
                    sda = new SqlDataAdapter("select * from " + hotelname + "_status", conn);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dr = dt.NewRow();
                    dt.Dispose();
                    conn.Close();
                    if (dt.Rows.Count == 0)
                    {
                        conn.Open();
                        cmd = new SqlCommand("insert into " + hotelname + "_status values('" + roomtype + "','" + Label1.Text + "','" + rooms + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + client + "','" + booking_id + "');", conn);
                        sdr = cmd.ExecuteReader();
                        conn.Close();
                        conn.Open();
                        cmd = new SqlCommand("insert into booking (booking_Id,client_id,hotelname,room_type,Check_In_date,Check_out_date,rooms) values('" + booking_id + "','" + client + "','"+hotelname+"','" + roomtype + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + rooms + "');", conn);
                        sdr = cmd.ExecuteReader();
                        conn.Close();
                        conn.Open();
                        cmd = new SqlCommand("insert into bookingsecret (booking_Id,client_id,hotelname,room_type,Check_In_date,Check_out_date,rooms) values('" + booking_id + "','" + client + "','"+hotelname+"','" + roomtype + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + rooms + "');", conn);
                        sdr = cmd.ExecuteReader();
                        conn.Close();
                        Session["roomtype"] = roomtype;
                        Session["checkin"] = TextBox1.Text;
                        Session["checkout"] = TextBox2.Text;
                        Response.Redirect("payment.aspx?Name=" + booking_id + "&name1=" + price + "&name2=" + rooms + "&hotel=" + hotelname + "");
                    }
                    else if (room <= available)
                    {
                        conn.Open();
                        cmd = new SqlCommand("insert into " + hotelname + "_status values('" + roomtype + "','" + Label1.Text + "','" + rooms + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + client + "','" + booking_id + "');", conn);
                        sdr = cmd.ExecuteReader();
                        conn.Close();
                        conn.Open();
                        cmd = new SqlCommand("insert into booking (booking_Id,client_id,hotelname,room_type,Check_In_date,Check_out_date,rooms) values('" + booking_id + "','" + client + "','" + hotelname + "','" + roomtype + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + rooms + "');", conn);
                        sdr = cmd.ExecuteReader();
                        conn.Close();
                        conn.Open();
                        cmd = new SqlCommand("insert into bookingsecret (booking_Id,client_id,hotelname,room_type,Check_In_date,Check_out_date,rooms) values('" + booking_id + "','" + client + "','"+hotelname+"','" + roomtype + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + rooms + "');", conn);
                        sdr = cmd.ExecuteReader();
                        conn.Close();
                        Session["roomtype"] = roomtype;
                        Session["checkin"] = TextBox1.Text;
                        Session["checkout"] = TextBox2.Text;
                        Response.Redirect("payment.aspx?Name=" + booking_id + "&name1=" + price + "&name2=" + rooms + "&hotel=" + hotelname + "");
                    }
                    else
                    {
                        Label4.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;
            }
            else
            {
                Calendar1.Visible = false;
            }

        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible == false)
            {
                Calendar2.Visible = true;
            }
            else
            {
                Calendar2.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string hotelname = DropDownList1.SelectedItem.ToString();
                hotelname = hotelname.Replace(" ", "_");
                string roomtype = DropDownList2.SelectedItem.ToString();
                cmd = new SqlCommand("select price from " + hotelname + " where roomtype='" + roomtype + "'", conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Label1.Text = sdr["price"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Please select Proper Hotel Name & RoomType");
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.CompareTo(DateTime.Today) < 0)
            {
                e.Day.IsSelectable = false;
            }
        }
        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.CompareTo(Calendar1.SelectedDate) <= 0)
            {
                e.Day.IsSelectable = false;
            }
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
            try
            {
                conn.Open();
                string hotelname = DropDownList1.SelectedItem.ToString();
                hotelname = hotelname.Replace(" ", "_");
                string roomtype = DropDownList2.SelectedItem.ToString();
                DateTime dt1 = Convert.ToDateTime(TextBox1.Text);
                DateTime dt2 = Convert.ToDateTime(TextBox2.Text);
                sda = new SqlDataAdapter("select check_in,check_out from " + hotelname + "_status where roomtype='" + roomtype + "'", conn);
                dt = new DataTable();
                sda.Fill(dt);
                int no = dt.Rows.Count;
                conn.Close();

                conn.Open();
                sda = new SqlDataAdapter("select * from " + hotelname + " where roomtype='" + roomtype + "'", conn);
                dt = new DataTable();
                sda.Fill(dt);
                int totalroom = dt.Rows.Count;
                conn.Close();

                conn.Open();
                DateTime chin, chout;
                String checki, checko;
                int room;
                sda = new SqlDataAdapter("select * from " + hotelname + "_status where roomtype='" + roomtype + "'", conn);
                ds = new DataSet();
                sda.Fill(ds);
                for (int i = 0; i < no; i++)
                {
                    checki = ds.Tables[0].Rows[i]["check_in"].ToString();
                    checko = ds.Tables[0].Rows[i]["check_out"].ToString();
                    room = Convert.ToInt32(ds.Tables[0].Rows[i]["rooms"]);
                    chin = Convert.ToDateTime(checki);
                    chout = Convert.ToDateTime(checko);
                    if (dt1 >= chin && dt1 < chout)
                    {
                        totalroom = totalroom - room;
                        Label2.Text = totalroom.ToString();
                    }
                    else if (dt2 > chin && dt2 <= chout)
                    {
                        totalroom = totalroom - room;
                        Label2.Text = totalroom.ToString();
                    }
                }
                Label2.Text = totalroom.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error");
            }
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int available = Convert.ToInt32(Label2.Text);
                int room = Convert.ToInt32(DropDownList3.SelectedValue.ToString());
                if (room > available)
                {
                    Label4.Visible = true;
                }
                else
                {
                    Label4.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }



        }
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Calendar1.SelectedDate == null || Calendar1.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Calendar2.SelectedDate == null || Calendar2.SelectedDate == new DateTime(0001, 1, 1, 0, 0, 0))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {

            if (DropDownList3.SelectedValue == null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("homepage.aspx");
        }
    }
}