<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PreviewItem.aspx.cs" Inherits="GymStore.PreviewItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center>



    <asp:Image ID="ShowItemImage" runat="server" Width="300px" Height="300px" ImageUrl=""/><br />
    Name: <asp:Label ID="ShowItemName" runat="server" Text=""></asp:Label><br />
    Price: <asp:Label ID="ShowItemPrice" runat="server" Text=""></asp:Label><br />
    Stock: <asp:Label ID="ShowItemStock" runat="server" Text=""></asp:Label><br />
    Description: <asp:Label ID="ShowItemDescription" runat="server" Text=""></asp:Label><br />
        <asp:DropDownList ID="AmountDDL" runat="server"></asp:DropDownList>
        <asp:Button ID="AddToCart" runat="server" Text="Add To Cart" OnClick="AddToCart_Click"/>


    </center>
</asp:Content>
