<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="GymStore.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <center>
     
    <br />
    <br />
    <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="error" runat="server" Text="" Visible="false"></asp:Label>
    <br />

    <asp:Button ID="SearchClick" runat="server" Text="Search" OnClick="SearchClick_Click"/>
    <asp:Button ID="Cleartextboxbutt" runat="server" Text="Clear" OnClick="Cleartextboxbutt_Click"/><br /><br />

         <asp:DropDownList ID="CategoryList" runat="server">
          
         </asp:DropDownList>
         <asp:Button ID="CategoryFilterButt" runat="server" Text="Filter" OnClick="CategoryFilterButt_Click"/>
         <asp:Label ID="errormsgcat" runat="server" Text=""></asp:Label>

    <br />
    <br />
     <%--<asp:Button ID="ShowCartButt" runat="server" Text="Show cart" OnClick="ShowCartButt_Click"/>--%>

<asp:DataList ID="ItemListShop" runat="server" RepeatColumns="3" CellSpacing="50" OnItemCommand="ItemListShop_ItemCommand" OnItemDataBound="ItemListShop_ItemDataBound">
     <ItemTemplate>
         <div style="margin:30px; text-align:center;">
             <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Bind("ItemImage") %>' Width="300px" Height="300px" CommandName="ImageClick" CssClass="imagestyle"/><br /><br />
         Name: <asp:Label ID="ShowItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label><br /><br />
         Price: <asp:Label ID="ShowItemPrice" runat="server" Text='<%# Bind("ItemPrice") %>'></asp:Label><br /><br />
         Stock: <asp:Label ID="ShowItemStock" runat="server" Text='<%# Bind("ItemStock") %>'></asp:Label><br /><br />
         Description: <asp:Label ID="ShowItemDescription" runat="server" Text='<%# Bind("ItemDescription") %>'></asp:Label><br /><br />
             <asp:ImageButton ID="WishlistButt" runat="server" CommandName="AddWishlist" CssClass="heart" ImageUrl="~/photos/heart1.png"/>
            </div>
     </ItemTemplate>
 </asp:DataList>

</center>
</asp:Content>
