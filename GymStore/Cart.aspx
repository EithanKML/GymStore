<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="GymStore.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>

        Total Items In Cart:<asp:Label ID="CountItems" runat="server" Text=""></asp:Label><br />
        Total Price:<asp:Label ID="TotalPrice" runat="server" Text=""></asp:Label><br /><br />
        <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" OnClick="CheckoutButton_Click" Enabled="true"/><br /><br />
        <asp:Panel ID="OrderPanel" runat="server" Visible="false">

            Address:<asp:TextBox ID="AddressText" runat="server" Text=""></asp:TextBox><br /><br />
            Notes:<asp:TextBox ID="NotesText" runat="server" Text=""></asp:TextBox><br /><br />

        <asp:Button ID="SubmitOrder" runat="server" Text="Submit" OnClick="SubmitOrder_Click"/><br />

            <asp:Label ID="errormsg" runat="server" Text="Cart is EMPTY!!!" Visible="false"></asp:Label>
         </asp:Panel>

   <asp:DataList ID="CartItems" runat="server" RepeatColumns="3" CellSpacing="50" OnItemCommand="CartItems_ItemCommand" OnItemDataBound="CartItems_ItemDataBound">
     <ItemTemplate>
         <div style="margin:30px; text-align:center;">
             <asp:Image ID="ItemImage" runat="server" ImageUrl='<%# Bind("ItemImage") %>'  Width="300px" Height="300px" CssClass="imagestyle"/><br /><br />
         Name: <asp:Label ID="ShowItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label><br /><br />
         Price: <asp:Label ID="ShowItemPrice" runat="server" Text='<%# Bind("CurrentPrice") %>'></asp:Label><br /><br />
             Amount:<asp:DropDownList ID="AmountDDL" runat="server"></asp:DropDownList>
             <asp:Button ID="UpdateAmount" runat="server" Text="Update" CommandName="updateamountbutt"/><br />
             <asp:Button ID="Removebutt" runat="server" Text="Remove" CommandName="removeitem"/>
         <%--Amount: <asp:Label ID="ShowItemAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>--%><br /><br />
            </div>
     </ItemTemplate>
 </asp:DataList>
        </center>
</asp:Content>
