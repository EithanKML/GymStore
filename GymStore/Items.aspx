<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="GymStore.Items" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center>
    <br />
    <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox><br /><br />


<asp:Button ID="SearchClick" runat="server" Text="Search" OnClick="SearchClick_Click"/><br /><br />
<asp:Button ID="AddItem" runat="server" Text="Add Items" OnClick="AddItem_Click" CausesValidation="false"/><br /><br />
<asp:Label ID="error" runat="server" Text="" Visible="false"></asp:Label><br /><br />


<asp:Panel ID="PanelAddItem" runat="server" Visible="false">

Item Name:<asp:TextBox ID="ItemName" runat="server"></asp:TextBox><br />

<h1>
<asp:RequiredFieldValidator ID="ItemNameFilled" runat="server" ErrorMessage="You Forgot The Name" ControlToValidate="ItemName"></asp:RequiredFieldValidator>
<%--<asp:RegularExpressionValidator ID="ItemNameValidation" runat="server" ControlToValidate="ItemName" ErrorMessage="Only letters. Between 2-50 letters." ValidationExpression="[a-z A-Z 0-9]{1,50}{.}"></asp:RegularExpressionValidator>--%>
</h1>

Item Price:<asp:TextBox ID="ItemPrice" runat="server"></asp:TextBox><br />

<h1>
<asp:RequiredFieldValidator ID="ItemPriceFilled" runat="server" ErrorMessage="You Forgot The Price" ControlToValidate="ItemPrice"></asp:RequiredFieldValidator>
<asp:RangeValidator runat="server" id="wspXformat" ControlToValidate="ItemPrice"
MinimumValue="0" MaximumValue="10000" Type="Double"
Text="The value must be from 0 to 10000!"  />  
</h1>

Item Description:<asp:TextBox ID="ItemDescription" runat="server"></asp:TextBox><br />

<h1>
<asp:RequiredFieldValidator ID="ItemDescriptionFilled" runat="server" ErrorMessage="You Forgot The Description" ControlToValidate="ItemDescription"></asp:RequiredFieldValidator>
</h1>

Item Stock:<asp:TextBox ID="ItemStock" runat="server"></asp:TextBox><br />

<h1>
<asp:RequiredFieldValidator ID="ItemStockFilled" runat="server" ErrorMessage="You Forgot The Stock" ControlToValidate="ItemStock"></asp:RequiredFieldValidator>
<asp:RangeValidator runat="server" id="RangeValidator1" ControlToValidate="ItemStock"
MinimumValue="0" MaximumValue="1000" Type="Double"
Text="The value must be from 0 to 1000!"  />
</h1>

<br />
<asp:CheckBoxList ID="CategoriesPicks" runat="server">
</asp:CheckBoxList>
<br />

Item Image:<asp:FileUpload ID="uploadImg" runat="server" /><br /><br />

<asp:Button ID="SubmitAddItem" runat="server" Text="Submit" OnClick="SubmitAddItem_Click"/><br />

    

 </asp:Panel>
 <asp:Label ID="ErrorMessage" runat="server" Text="Failed To Add." Visible="false"></asp:Label><br />
 <asp:Label ID="SuccessMessage" runat="server" Text="Item Added Successfully" Visible="false"></asp:Label>

        <asp:DataList ID="ItemList" runat="server" RepeatColumns="5" CellSpacing="50" OnItemCommand="ItemList_ItemCommand">
            <ItemTemplate>
                <asp:Panel ID="ItemStats" runat="server">
                <asp:Image ID="ShowItemImage" runat="server" ImageUrl='<%# Bind("ItemImage") %>' Width="300px" Height="300px"/><br />
                Name: <asp:Label ID="ShowItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label><br />
                Price: <asp:Label ID="ShowItemPrice" runat="server" Text='<%# Bind("ItemPrice") %>'></asp:Label><br />
                Stock: <asp:Label ID="ShowItemStock" runat="server" Text='<%# Bind("ItemStock") %>'></asp:Label><br />
                Description: <asp:Label ID="ShowItemDescription" runat="server" Text='<%# Bind("ItemDescription") %>'></asp:Label><br />
                Categories: <asp:Label ID="ShowItemCategories" runat="server" Text='<%# Bind("CategoriesNames") %>'></asp:Label><br />
                    <asp:Button ID="UpdatePanelButton" runat="server" Text="Update Item" CommandName="updatepanelbut"/><br />
                    </asp:Panel>
                <asp:Panel ID="UpdateItemStats" runat="server" Visible="false">
                Item Name:<asp:TextBox ID="UpdateItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:TextBox><br />
                Item Price:<asp:TextBox ID="UpdateItemPrice" runat="server" Text='<%# Bind("ItemPrice") %>'></asp:TextBox><br />
                Item Description:<asp:TextBox ID="UpdateItemDescription" runat="server" Text='<%# Bind("ItemDescription") %>'></asp:TextBox><br />
                Item Stock:<asp:TextBox ID="UpdateItemStock" runat="server" Text='<%# Bind("ItemStock") %>'></asp:TextBox><br />
                Item Image:<asp:FileUpload ID="UpdateuploadImg" runat="server" /><br />
                <asp:CheckBoxList ID="UpdateCategoriesPicks" runat="server">
                </asp:CheckBoxList>
                <br />
                <asp:Button ID="UpdateButton" runat="server" Text="Submit" CommandName="submitupdate"/>
                    <asp:Label ID="ErrorMessaage" runat="server" Text="Couldn't Update Profile." Visible="false"></asp:Label>
                </asp:Panel>
            </ItemTemplate>
        </asp:DataList>

    </center>
</asp:Content>
