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
        
        <br /><br /><br />

        Would You Like To Rate The Product?<br />
        <asp:Button ID="RatePanelButt" runat="server" Text="Yes" OnClick="RatePanelButton_Click"/><br />
        <asp:Panel ID="RatePanel" runat="server" Visible="false">
            <asp:DropDownList ID="RatingList" runat="server"></asp:DropDownList><br /><br />
            <asp:TextBox ID="RateNotes" runat="server" Width="100px" Height="50px"></asp:TextBox><br /><br />
            <asp:Button ID="SubmitRating" runat="server" Text="Submit Rating" OnClick="SubmitRating_Click"/><br /><br />
        </asp:Panel>
        <asp:Label ID="Successmsg" runat="server" Text="Rating Added!" Visible="false"></asp:Label>

    </center>
</asp:Content>
