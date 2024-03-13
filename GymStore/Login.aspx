<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GymStore.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        
    <h3>Email:
    <asp:TextBox ID="TextEmail" runat="server"></asp:TextBox>
    
    <br />
    <br />
    
    
    Password:
    <asp:TextBox ID="TextPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />


    <asp:Button ID="ButtonLogin" runat="server" Text="Submit" OnClick="ButtonLogin_Click" />
    <br />

    <asp:Label ID="Label1" runat="server" Text="Incorrect username or password." Visible="false"></asp:Label>

    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="SignUp.aspx">Sign Up</asp:HyperLink>

        </h3>
    </center>
</asp:Content>
