using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace GymStore
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            Customer c=Helper.Login(TextEmail.Text, TextPassword.Text);
            if (c==null)
            {
                Label1.Visible = true;
            }
            else
            {

                if (c.IsAdmin == true)
                {
                    Session["admin"] = c;
                }

                Session["customer"] = c;
                Response.Redirect("Profile.aspx");
            }
        }
    }
}