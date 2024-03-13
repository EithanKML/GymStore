using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymStore
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Customer c = Helper.Register(Name.Text, Email.Text, Password.Text);
            if(c==null)
            {
                ErrorMessage.Visible = true;
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