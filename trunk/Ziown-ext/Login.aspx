<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ziown_ext.Login" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Ziown - Licitação</title>
    <link href="Styles/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Label ID="lblMessage" runat="server" />
    <ext:Window ID="Window1" runat="server" Closable="false" Resizable="false" Height="150"
        Icon="Lock" Title="Login" Draggable="false" Width="350" Modal="true" BodyPadding="5"
        Layout="FormLayout">
        <Items>
            <ext:TextField ID="txtUsername" runat="server" FieldLabel="Usuário" AllowBlank="false"
                BlankText="Login é obrigatório." Text="" />
            <ext:TextField ID="txtPassword" runat="server" InputType="Password" FieldLabel="Senha"
                AllowBlank="false" BlankText="Senha é obrigatória." Text="" />
        </Items>
        <Buttons>
            <ext:Button ID="btnLogin" runat="server" Text="Entrar" Icon="Accept">
                <Listeners>
                    <Click Handler="
                            if (!#{txtUsername}.validate() || !#{txtPassword}.validate()) {
                                Ext.Msg.show({ icon: Ext.MessageBox.ERROR, msg: 'Usuário e senha devem ser informados', buttons: Ext.Msg.OK, title: 'Erro' });                                
                                return false; 
                            }" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnLogin_Click">
                        <EventMask ShowMask="true" Msg="Verifying..." MinDelay="100" />
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
    </form>
</body>
</html>
