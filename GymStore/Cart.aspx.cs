using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymStore
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Customer c = (Customer)Session["customer"];
                if (c == null) Response.Redirect("Login.aspx");


                OrderItemList cart = (OrderItemList)Session["cart"];
                CartItems.DataSource = cart;
                CartItems.DataBind();

                

                ((Label)Master.FindControl("Title")).Text = "Cart";

                AddressText.Text = c.CustomerAddress.ToString();

                if (cart == null || cart.Count == 0)
                {
                    CheckoutButton.Enabled = false;
                    TotalPrice.Text = "0";
                    CountItems.Text = "0";
                }
                else
                {
                    CheckoutButton.Enabled = true;
                    TotalPrice.Text = cart.Total.ToString();
                    CountItems.Text = cart.Count.ToString();
                }
            }
        }

        protected void CartItems_ItemCommand(object source, DataListCommandEventArgs e)
        {
            DropDownList d = (DropDownList)(e.Item.FindControl("AmountDDL"));
            OrderItemList cart = (OrderItemList)Session["cart"];
            if (e.CommandName == "updateamountbutt")
            {
                int newamount = int.Parse(d.SelectedValue);
                
                OrderItem item = cart[e.Item.ItemIndex];
                item.Amount = newamount;
                Response.Redirect("Cart.aspx");
            }

            if (e.CommandName == "removeitem")
            {
                OrderItem item = cart[e.Item.ItemIndex];
                cart.Remove(item);
                Session["cart"] = cart;
                CartItems.DataSource = cart;
                CartItems.DataBind();
                Response.Redirect("Cart.aspx");
            }
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            OrderPanel.Visible = true;
            
        }

        protected void SubmitOrder_Click(object sender, EventArgs e)
        {
            OrderItemList cart = (OrderItemList)Session["cart"];

            Customer c = (Customer)Session["customer"];
            Order o = c.AddOrder(AddressText.Text, NotesText.Text);
            if (o != null)
            {
                o.ItemList = new OrderItemList(cart);
                o.SaveItemsToDB();
                Session["cart"] = null;
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                errormsg.Visible = true;
            }
            

        }

        protected void CartItems_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
            DropDownList d = (DropDownList)(e.Item.FindControl("AmountDDL"));
            OrderItemList cart = (OrderItemList)Session["cart"];
            OrderItem item = cart[e.Item.ItemIndex];

            

            for (int i = 1; i <= item.Item.ItemStock; i++)
            {
                d.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            d.SelectedValue=item.Amount.ToString();
            
        }
    }
}