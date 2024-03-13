using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GymStore
{
    public partial class WishList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer c = (Customer)Session["customer"];
                if (c == null) Response.Redirect("Login.aspx");
                c.LoadWishList();
                WishListDL.DataSource = c.Wishlist;
                WishListDL.DataBind();

                ((Label)Master.FindControl("Title")).Text = "WishList";
            }
        }

        protected void WishListDL_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }
    }
}