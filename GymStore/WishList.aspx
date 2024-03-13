<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WishList.aspx.cs" Inherits="GymStore.WishList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DataList ID="WishListDL" runat="server"  RepeatColumns="3" CellSpacing="50" OnItemCommand="WishListDL_ItemCommand">
    <ItemTemplate>
    
    <asp:Image ID="ShowItemImage" runat="server" ImageUrl='<%# Bind("ItemImage") %>' Width="300px" Height="300px"/><br />
    Name: <asp:Label ID="ShowItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label><br />
    Price: <asp:Label ID="ShowItemPrice" runat="server" Text='<%# Bind("ItemPrice") %>'></asp:Label><br />
    Stock: <asp:Label ID="ShowItemStock" runat="server" Text='<%# Bind("ItemStock") %>'></asp:Label><br />
    Description: <asp:Label ID="ShowItemDescription" runat="server" Text='<%# Bind("ItemDescription") %>'></asp:Label><br />

    
</ItemTemplate>
</asp:DataList>

</asp:Content>
