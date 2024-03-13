using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymStore
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cart"] == null)
                {
                    itemsamountincart.Text = "(0)";
                }
                else
                {
                    OrderItemList cart = (OrderItemList)Session["cart"];
                    itemsamountincart.Text = "(" + cart.amount.ToString() +")";
                }
            }
        }

        protected void cartbutt_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void wishlistbutt_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WishList.aspx");
        }

        protected void loginbutt_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void signupbutt_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void storebutt_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void itemsbutt_Click(object sender, EventArgs e)
        {
            Response.Redirect("Items.aspx");
        }

        protected void profilebutt_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void logoutbutt_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}