<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="PesquisarCadastroEmpresas.aspx.cs" Inherits="Ziown_ext.PesquisarCadastroEmpresas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <ext:Panel ID="Panel1" runat="server" Frame="true" Title="Label Style and Separator"
        Width="400" Layout="FormLayout">
        <Defaults>
            <ext:Parameter Name="LabelStyle" Mode="Value" />
        </Defaults>
        <Items>
            <ext:TextField ID="txtCNPJ" runat="server" FieldLabel="CNPJ" LabelSeparator=":" />
            <ext:TextField ID="txtRazaoSocial" runat="server" FieldLabel="Razão Social" LabelSeparator=":" />
            <ext:ButtonGroup>
                <Buttons>
                    <ext:Button ID="btnPesquisar" runat="server" Text="Entrar" Icon="Accept">
                        <DirectEvents>
                            <Click OnEvent="btnPesquisar_Click">
                                <EventMask ShowMask="true" Msg="Carregando..." MinDelay="100" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:ButtonGroup>
        </Items>
    </ext:Panel>
    <div class="x-panel x-panel-default-framed x-border-box" style="width: 400px; height: 87px;">
        <asp:GridView ID="grdPesquisa" runat="server" AutoGenerateColumns="False" Width="100%"
            PageSize="20" OnRowCreated="grd_RowCreated" GridLines="Vertical" CssClass="x-panel-header x-header x-header-horizontal x-docked x-unselectable x-panel-header-default-framed x-horizontal x-panel-header-horizontal x-panel-header-default-framed-horizontal x-top x-panel-header-top x-panel-header-default-framed-top x-docked-top x-panel-header-docked-top x-panel-header-default-framed-docked-top"
            OnRowDataBound="grdPesquisa_RowDataBound" DataKeyNames="">
            <Columns>
                <asp:BoundField HeaderText="Razão Social" DataField="RazaoSocial" ItemStyle-Width="100px">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle CssClass="x-grid-cell x-grid-td x-grid-cell-gridcolumn-1012 x-grid-cell-first x-unselectable"
                        Width="400px"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <Columns>
                <asp:BoundField HeaderText="Situação" DataField="Situacao" ItemStyle-Width="100px">
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    <ItemStyle CssClass="x-grid-cell x-grid-td x-grid-cell-gridcolumn-1012 x-grid-cell-first x-unselectable"
                        Width="400px"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <HeaderStyle CssClass="grid-view-header" />
        </asp:GridView>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtCNPJ").mask("99.999.999/9999-99");
        });
    </script>
</asp:Content>
