using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymStore
{
    public partial class PreviewItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                Item item = (Item)Session["selecteditem"];

                ShowItemImage.ImageUrl = item.ItemImage;
                ShowItemName.Text = item.ItemName;
                ShowItemPrice.Text = item.ItemPrice.ToString();
                ShowItemStock.Text = item.ItemStock.ToString();
                ShowItemDescription.Text = item.ItemDescription;
                //לטפל בתצוגה בהתאם לאם המוצר בעגלה או לא

                if (item.ItemStock < 1)
                {
                    AddToCart.Enabled = false;
                }

                int num = item.ItemStock;

                for (int i = 1; i <= num; i++)
                {
                    AmountDDL.Items.Add(new ListItem(i.ToString(),i.ToString()));
                }

                for (int i = 1; i <= 5; i++)
                {
                    RatingList.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                OrderItemList cart = (OrderItemList)Session["cart"];
                if (cart != null)
                {
                    OrderItem itemincart = cart.Find(x => x.Item.ItemID == item.ItemID);
                    if (itemincart != null)
                    {
                        AmountDDL.SelectedValue = itemincart.Amount.ToString();
                        AddToCart.Text = "Update";
                    }
                    else
                    {

                    }
                }
                else
                {

                }

            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            Item item = (Item)Session["selecteditem"];

            if (Session["cart"]== null)
            {
                Session["cart"] = new OrderItemList();
            }
            if(Session["CurrentOrder"]==null)
            {
                Session["CurrentOrder"] = new Order();
            }
            Order o = (Order)Session["CurrentOrder"];
            OrderItemList cart = (OrderItemList)Session["cart"];
            int prevamount = 0;
            if (cart != null)
            {
                OrderItem itemincart = cart.Find(x => x.Item.ItemID == item.ItemID);
                if (itemincart != null)
                {
                    prevamount = itemincart.Amount;
                }
            }

            int num = int.Parse(AmountDDL.Text) - prevamount;

            if (num > 0)
            {
                cart.AddToCart(item, num, o);
                Response.Redirect("HomePage.aspx");
            }

        }

        protected void RatePanelButton_Click(object sender, EventArgs e)
        {
            if (RatePanel.Visible == false)
            {
                RatePanelButt.Text = "No";
                RatePanel.Visible = true;
            }
            else
            {
                RatePanelButt.Text = "Yes";
                RatePanel.Visible = false;
            }
            

        }

        protected void SubmitRating_Click(object sender, EventArgs e)
        {
            int rate = int.Parse(RatingList.SelectedValue.ToString());
            Customer c = (Customer)Session["customer"];
            Item item = (Item)Session["selecteditem"];
            string text = RateNotes.Text;

            c.AddRating(rate, item, text);

            RatePanel.Visible = false;
            Successmsg.Visible = true;
        }
    }
}