using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GymStore
{
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer c = (Customer)Session["admin"];
                if (c == null) Response.Redirect("Login.aspx");

                ItemList list = Helper.AllItems();
                Session["itemlist"] = list;
                ItemList.DataSource = Helper.AllItems();
                ItemList.DataBind();

                ((Label)Master.FindControl("Title")).Text = "Items";

               CategoryList catlist = Helper.AllCategories();
                Session["Categories"] = catlist;
                CategoriesPicks.DataSource = catlist;
                CategoriesPicks.DataTextField = "CategoryName";
                CategoriesPicks.DataValueField = "CategoryID";
                CategoriesPicks.DataBind();
            }
        }

        protected void AddItem_Click(object sender, EventArgs e)
        {

            if (PanelAddItem.Visible == false)
            {
            PanelAddItem.Visible = true;
            AddItem.Text = "Hide";
            }
            else
            {
                PanelAddItem.Visible = false;
                AddItem.Text = "Add Item";
            }
            
        }

        protected void SubmitAddItem_Click(object sender, EventArgs e)
        {
            PanelAddItem.Visible = false;
            

            Item c = Helper.AddItem(ItemName.Text, int.Parse(ItemPrice.Text), ItemDescription.Text, "", int.Parse(ItemStock.Text));
            if (c == null)
            {
                ErrorMessage.Visible = true;
            }
            else
            {
                string filename = "";
                if (uploadImg.HasFiles)
                {
                    string extention = uploadImg.FileName.Substring(uploadImg.FileName.IndexOf("."));
                    filename = "photos/item" + c.ItemID + extention;
                    uploadImg.SaveAs(Server.MapPath("~/" + filename));
                    c.ItemImage = filename;
                    c.Update(c.ItemName, c.ItemPrice, c.ItemStock, c.ItemImage, c.ItemDescription);
                }

                foreach (ListItem item in CategoriesPicks.Items)
                {
                    if (item.Selected )
                    {
                        Category cat= new Category(int.Parse(item.Value), item.Text);
                        c.AddCategory(cat);
                    }
                }



                SuccessMessage.Visible = true;
                Response.Redirect("Items.aspx");
            }
        }

        protected void ItemList_ItemCommand(object source, DataListCommandEventArgs e)
        {

            ItemList list = (ItemList)Session["itemlist"];
            Item item = list[e.Item.ItemIndex];

            if (e.CommandName == "updatepanelbut")
            {
                e.Item.FindControl("ItemStats").Visible = false;
                e.Item.FindControl("UpdateItemStats").Visible = true;

                CheckBoxList ucb = ((CheckBoxList)e.Item.FindControl("UpdateCategoriesPicks"));

                CategoryList catlist = Helper.AllCategories();
                Session["Categories"] = catlist;
                ucb.DataSource = catlist;
                ucb.DataTextField = "CategoryName";
                ucb.DataValueField = "CategoryID";
                ucb.DataBind();



                foreach (ListItem item2 in ucb.Items)
                {

                    if (item.Categories.Exists(x => int.Parse(item2.Value) == x.CategoryID))
                    {
                        item2.Selected = true;
                    }
                }
            }

            if (e.CommandName == "submitupdate")
            {
                

               // string itemname = item.;
                string filename = "";
                FileUpload upload = ((FileUpload)e.Item.FindControl("UpdateuploadImg"));
                if (upload.HasFiles)
                {
                    string extention = upload.FileName.Substring(upload.FileName.IndexOf("."));
                    filename = "photos/item" + item.ItemID + extention;
                    upload.SaveAs(Server.MapPath("~/" + filename));
                }
                else
                {
                    filename = item.ItemImage;
                }

                CheckBoxList ucb = ((CheckBoxList)e.Item.FindControl("UpdateCategoriesPicks"));
                CategoryList catlist = Helper.AllCategories();
                Session["Categories"] = catlist;

                foreach (ListItem item2 in ucb.Items)
                {
                    if (!item2.Selected)
                    {
                        Category cat = new Category(int.Parse(item2.Value), item2.Text);
                        item.RemoveCategory(cat);
                    }
                    else
                    {
                        if (!(item.Categories.Exists(x => int.Parse(item2.Value) == x.CategoryID)))
                        {
                            Category cat = new Category(int.Parse(item2.Value), item2.Text);
                            item.AddCategory(cat);
                        }
                    }
                }

                bool status = item.Update(((TextBox)e.Item.FindControl("UpdateItemName")).Text, int.Parse(((TextBox)e.Item.FindControl("UpdateItemPrice")).Text), int.Parse(((TextBox)e.Item.FindControl("UpdateItemStock")).Text), filename, ((TextBox)e.Item.FindControl("UpdateItemDescription")).Text);
                if (status == false)
                {
                    e.Item.FindControl("ErrorMessage").Visible = true;
                }
                else
                {
                    e.Item.FindControl("UpdateItemStats").Visible = true;
                    Response.Redirect("Items.aspx");
                }
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
                ItemList.DataSource = Session["searched"];
                ItemList.DataBind();
            }
        }

 
    }
}