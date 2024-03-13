<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="GymStore.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <center>

        <h3>Name: <asp:TextBox ID="Name" runat="server"></asp:TextBox></h3>
        <h1><asp:RequiredFieldValidator ID="FNameFilled" runat="server" ErrorMessage="You Forgot The First Name" ControlToValidate="Name"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="FirstNameValidation" runat="server" ControlToValidate="Name" ErrorMessage="Only letters. Between 2-10 letters." ValidationExpression="[a-z A-Z]{2,10}"></asp:RegularExpressionValidator></h1>
        <br />
        <br />

        <h3>Email: <asp:TextBox ID="Email" runat="server"></asp:TextBox></h3>
        <h1><asp:RequiredFieldValidator ID="EmailFilled" runat="server" ErrorMessage="You Forgot The Email" ControlToValidate="Email"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="EmailValidation" runat="server" ControlToValidate="Email" ErrorMessage="Has to be proper E-mail. xxx@xxx.com" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"></asp:RegularExpressionValidator></h1>
        <br />
        <br />


        <h3>Password: <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></h3>
        <h1><asp:RequiredFieldValidator ID="PasswordFilled" runat="server" ErrorMessage="You Forgot The Password" ControlToValidate="Password"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="PasswordValidation" runat="server" ControlToValidate="Password" ErrorMessage="The password must be between 2 and 20 characters, contain at least one digit and one alphabetic character, and must not contain special characters." ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,20})$"></asp:RegularExpressionValidator></h1>

        <br />
        <br />
        <br />
        <br />
        <h3>
        <asp:Button ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click"/>

        <br />
        <br />

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Login.aspx">Log in</asp:HyperLink>
        
        <asp:Label ID="ErrorMessage" runat="server" Text="Sign Up Failed." Visible="false"></asp:Label>
            
            </h3>
            
        </center>
</asp:Content>
