<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="EditarCadastroEmpresas.aspx.cs" Inherits="Ziown_ext.EditarCadastroEmpresas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <ext:FieldSet ID="FieldSet1" runat="server" Title="User Info" DefaultWidth="300">
        <Items>
            <ext:TextField ID="TextField1" runat="server" AllowBlank="false" FieldLabel="User ID"
                Name="user" EmptyText="user id" />
            <ext:TextField ID="TextField2" runat="server" AllowBlank="false" FieldLabel="Password"
                Name="pass" EmptyText="password" InputType="password" />
            <ext:TextField ID="TextField3" runat="server" AllowBlank="false" FieldLabel="Verify"
                Name="pass" EmptyText="password" InputType="password" />
        </Items>
    </ext:FieldSet>
    <ext:FieldSet ID="FieldSet2" runat="server" Title="Contact Information" DefaultWidth="300">
        <Items>
            <ext:TextField ID="TextField4" runat="server" FieldLabel="First Name" Name="first"
                EmptyText="First Name" />
            <ext:TextField ID="TextField5" runat="server" FieldLabel="Last Name" Name="last"
                EmptyText="Last Name" />
            <ext:TextField ID="TextField6" runat="server" FieldLabel="Company" Name="company" />
            <ext:TextField ID="TextField7" runat="server" FieldLabel="Email" Name="email" Vtype="email" />
            <ext:ComboBox ID="ComboBox1" runat="server" FieldLabel="State" Name="state" DisplayField="name"
                ValueField="abbr" QueryMode="Local" TypeAhead="true" EmptyText="Select a state...">
            </ext:ComboBox>
            <ext:DateField ID="DateField1" runat="server" FieldLabel="Date of birth" Name="dob"
                AllowBlank="false" MaxDate="<%# DateTime.Today %>" AutoDataBind="true" />
        </Items>
    </ext:FieldSet>
    </Items>
    <buttons>
                    <ext:Button ID="Button1" 
                        runat="server" 
                        Text="Register" 
                        Disabled="true" 
                        FormBind="true" />
                </buttons>
</asp:Content>
