using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymStore
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Customer c = (Customer)Session["customer"];
                if (c == null) Response.Redirect("Login.aspx");
                name.Text = c.CustomerName;
                phone.Text = c.CustomerPhone;
                email.Text = c.CustomerEmail;
                address.Text = c.CustomerAddress;
                password.Text = c.CustomerPassword;
                image.ImageUrl = c.defCustomerPFP;

                c.LoadOrders();
                OrderList.DataSource= c.Orders;
                OrderList.DataBind();

                ((Label)Master.FindControl("Title")).Text = "Profile";
            }
        }

        protected void updatebutton_Click(object sender, EventArgs e)
        {
            updatepanel.Visible = true;

            Customer c = (Customer)Session["customer"];

            nameupdate.Text = c.CustomerName;
            phoneupdate.Text = c.CustomerPhone;
            emailupdate.Text = c.CustomerEmail;
            addressupdate.Text = c.CustomerAddress;
            passwordupdate.Text = c.CustomerPassword;
            
        }

        protected void updatesubmit_Click(object sender, EventArgs e)
        {
            Customer c = (Customer)Session["customer"];
            string filename = "";
            if (uploadImg.HasFiles)
            {
                string extention = uploadImg.FileName.Substring(uploadImg.FileName.IndexOf("."));
                 filename = "photos/cust" + c.CustomerID + extention;
                uploadImg.SaveAs(Server.MapPath("~/" + filename));
            }
            else
            {
                filename = c.CustomerPFP;
            }
            bool status = c.Update(nameupdate.Text, phoneupdate.Text, emailupdate.Text, addressupdate.Text, passwordupdate.Text, filename, c.IsAdmin);
            if (status==false)
            {
                ErrorMessaage.Visible = true;
            }
            else
            {
                updatepanel.Visible = false;
                Response.Redirect("Profile.aspx");
            }

        }


        protected void OrderList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Customer c = (Customer)Session["customer"];
            if (e.CommandName == "ShowDetails")
            {
                DetailsPanel.Visible = true;
                c.Orders[e.Item.ItemIndex].LoadOrderItems();
                DetailsGridview.DataSource = c.Orders[e.Item.ItemIndex].ItemList;
                DetailsGridview.DataBind();

            }
        }
    }
}