using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace GymStore
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
                CategoryList.DataSource = Helper.AllCategories();
                CategoryList.DataTextField = "CategoryName";
                CategoryList.DataValueField = "CategoryID";
                CategoryList.DataBind();


                Customer c = (Customer)Session["customer"];
                //if (c == null) Response.Redirect("Login.aspx");

                ItemList list = Helper.AllItems();
                Session["itemlist"] = list;

                ItemListShop.DataSource = Helper.AllItems();
                ItemListShop.DataBind();

                ((Label)Master.FindControl("Title")).Text = "Store";
            }
        }

        protected void SearchClick_Click(object sender, EventArgs e)
        {
            string text = SearchBox.Text;
            ItemList list = (ItemList)Session["itemlist"];
            List<Item> searched = list.FindAll(x => x.ItemDescription.ToLower().Contains(text.ToLower()) || x.ItemName.ToLower().Contains(text.ToLower()));

            if (searched.Count == 0)
            {
                error.Visible = true;
                error.Text = "No Such Item.";
            }
            else
            {
                Session["searched"] = searched;
                ItemListShop.DataSource = Session["searched"];
                ItemListShop.DataBind();
            }
        }

        protected void ItemListShop_ItemCommand(object source, DataListCommandEventArgs e)
        {
            ItemList list = (ItemList)Session["itemlist"];
            Item item = list[e.Item.ItemIndex];
            Customer c = (Customer)Session["customer"];

            if (e.CommandName=="ImageClick")
            {
                Session["selecteditem"] = item;

                if (c != null)
                {
                    Response.Redirect("PreviewItem.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (c != null)
            {
                if (e.CommandName == "AddWishlist")
                {
                    ImageButton btn = (ImageButton)(e.Item.FindControl("WishlistButt"));

                    
                    if (btn.ImageUrl == "~/photos/heart1.png")
                    {
                        btn.ImageUrl = "~/photos/heart2.png";
                        c.AddToWishList(item);
                    }
                    else
                    {
                        btn.ImageUrl = "~/photos/heart1.png";
                        c.DeleteFromWishList(item);
                    }

                }
            }
        }

        protected void Cleartextboxbutt_Click(object sender, EventArgs e)
        {

            ItemListShop.DataSource = Helper.AllItems();
            ItemListShop.DataBind();
            SearchBox.Text = "";
            error.Visible = false;
        }

        protected void ItemListShop_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Customer c = (Customer)Session["customer"];
            Item item = (Item)(e.Item.DataItem);
            if (c != null)
            {
                c.LoadWishList();
                if (c.Wishlist.Exists(x=>item.ItemID == x.ItemID))
                {
                    ImageButton btn = (ImageButton)(e.Item.FindControl("WishlistButt"));
                    btn.ImageUrl = "~/photos/heart2.png";
                }
            }
        }

        protected void CategoryFilterButt_Click(object sender, EventArgs e)
        {
            ItemList list = (ItemList)Session["itemlist"];
            int cat = int.Parse(CategoryList.SelectedValue);
            list = new ItemList(list.FindAll(x => x.Categories.Exists(y => y.CategoryID == cat)));

            if (list.Count == 0)
            {
                error.Visible = true;
                error.Text = "No Such Item.";
            }
            else
            {

                ItemListShop.DataSource = list;
                ItemListShop.DataBind();
            }
        }



        //protected void ShowCartButt_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Cart.aspx");
        //}
    }
}