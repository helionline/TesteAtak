<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proj270618_TesteAtak_AP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <fieldset>
        <table>
            <tr>
                <td>Pesquisa Google:</td>
                <td><asp:TextBox ID="iptBusca" runat="server"/></td>
                <td><asp:Button Text="Pesquisar" runat="server" OnClick="pesquisar" /></td>
            </tr>
        </table>
    </fieldset>
    <br />
    <br />
    <div>
        <asp:GridView ID="gvResultados" Width="100%" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Titulo" DataField="titulo"/>
                <asp:HyperLinkField HeaderText="Link" DataNavigateUrlFields="link" DataNavigateUrlFormatString="{0}" DataTextField="link" Target="_blank" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
