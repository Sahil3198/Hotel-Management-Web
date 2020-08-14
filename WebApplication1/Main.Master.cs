using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagement
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            if (Session["id"]==null)
            {
                Button1.Text = "";
            }
            else
            {
                Button1.Text = Session["id"].ToString();
            }
        }
        public string userid
        {
            get
            {
                return Session["ID"].ToString();
            }
        }
        protected void Button1_Click2(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("homepage.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("showuser.aspx");
        }
    }
}