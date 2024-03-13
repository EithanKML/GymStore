<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GymStore.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>

    <h3> Profile 

        <br />
        <br />
        <br />

    Name: <asp:Label ID="name" runat="server" Text=""></asp:Label><br />
    Phone: <asp:Label ID="phone" runat="server" Text=""></asp:Label><br />
    Email: <asp:Label ID="email" runat="server" Text=""></asp:Label><br />
    Address: <asp:Label ID="address" runat="server" Text=""></asp:Label><br />
    Password: <asp:Label ID="password" runat="server" Text=""></asp:Label><br />
    Profile Picture: <asp:Image ID="image" runat="server" Height="100px" Width="100px"/>
    
    </h3>

    <br />
    <br />
    <br />

    <asp:Button ID="updatebutton" runat="server" Text="Update" OnClick="updatebutton_Click"/>

    <br />
    <br />

    <asp:Panel ID="updatepanel" runat="server" Visible="false">

        Name: <asp:TextBox ID="nameupdate" runat="server"></asp:TextBox><br />
        <h1><asp:RequiredFieldValidator ID="FNameFilled" runat="server" ErrorMessage="You Forgot The Name" ControlToValidate="nameupdate"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="FirstNameValidation" runat="server" ControlToValidate="nameupdate" ErrorMessage="Only letters. Between 2-10 letters." ValidationExpression="[a-z A-Z]{2,10}"></asp:RegularExpressionValidator></h1>
        <br />
        Phone: <asp:TextBox ID="phoneupdate" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="PhoneFilled" runat="server" ErrorMessage="You Forgot The Email" ControlToValidate="phoneupdate"></asp:RequiredFieldValidator>
        Email: <asp:TextBox ID="emailupdate" runat="server"></asp:TextBox><br />
        <h1><asp:RequiredFieldValidator ID="EmailFilled" runat="server" ErrorMessage="You Forgot The Email" ControlToValidate="emailupdate"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="EmailValidation" runat="server" ControlToValidate="emailupdate" ErrorMessage="Has to be proper E-mail. xxx@xxx.com" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"></asp:RegularExpressionValidator></h1>
<br />
        Address: <asp:TextBox ID="addressupdate" runat="server"></asp:TextBox><br />
        Password: <asp:TextBox ID="passwordupdate" runat="server"></asp:TextBox><br />
        <h1><asp:RequiredFieldValidator ID="PasswordFilled" runat="server" ErrorMessage="You Forgot The Password" ControlToValidate="passwordupdate"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="PasswordValidation" runat="server" ControlToValidate="passwordupdate" ErrorMessage="The password must be between 2 and 20 characters, contain at least one digit and one alphabetic character, and must not contain special characters." ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,20})$"></asp:RegularExpressionValidator></h1>

        Profile Picture: <asp:FileUpload ID="uploadImg" runat="server" /><br />
        <asp:Button ID="updatesubmit" runat="server" Text="Submit" OnClick="updatesubmit_Click"/>

    </asp:Panel>

    <br />
    <br />
    <asp:Label ID="ErrorMessaage" runat="server" Text="Couldn't Update Profile." Visible="false"></asp:Label>


    <asp:DataList ID="OrderList" runat="server"  RepeatColumns="3" CellSpacing="50" OnItemCommand="OrderList_ItemCommand">
        <ItemTemplate>
            <div style="margin:30px; text-align:center;">
            Order Address: <asp:Label ID="OrderAddress" runat="server" Text='<%#Bind("OrderAddress") %>'></asp:Label><br />
            Order Notes: <asp:Label ID="OrderNotes" runat="server" Text='<%#Bind("OrderNotes") %>'></asp:Label><br />
            Order Date: <asp:Label ID="OrderDate" runat="server" Text='<%#Bind("OrderDate") %>'></asp:Label><br />
            Order Status: <asp:Label ID="OrderStatus" runat="server" Text='<%#Bind("OrderStatus") %>'></asp:Label><br />
                <asp:Button ID="DetailsButt" runat="server" Text="Details" CommandName="ShowDetails"/>
              
            </div>
        </ItemTemplate>
    </asp:DataList>
      <asp:Panel ID="DetailsPanel" runat="server" Visible="false">

          <asp:GridView ID="DetailsGridview" runat="server" BackColor="#0099FF" BorderColor="#006699" BorderWidth="5px" Width="1000px" Height="300px" AutoGenerateColumns="False">

              <Columns>
                  <asp:ImageField DataImageUrlField="ItemImage" HeaderText="Item Image">
                      <ControlStyle BorderStyle="Outset" CssClass="imagestyle" Height="100px" Width="100px" />
                      <FooterStyle CssClass="imagestyle" Height="20px" Width="20px" />
                      <HeaderStyle CssClass="imagestyle" Height="20px" Width="20px" />
                      <ItemStyle CssClass="imagestyle" Height="50px" Width="50px" />
                  </asp:ImageField>
                  <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                  <asp:BoundField DataField="Amount" HeaderText="Item Amount" />
                  <asp:BoundField DataField="CurrentPrice" HeaderText="Item Price" />
                  <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
              </Columns>

          </asp:GridView>

  </asp:Panel>
</center>


</asp:Content>
