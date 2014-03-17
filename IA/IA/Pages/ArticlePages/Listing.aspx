<%@ Page Title="    " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="IA.Pages.ArticlePages.Listing" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Content/themes/base/images/closebutton.png" CausesValidation="False" CssClass="closebutton" />
    </asp:Panel>
    <h1>Artiklar
    </h1>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:ListView ID="ArticleListView" runat="server"
        ItemType="IA.Model.Article"
        SelectMethod="ArticleListView_GetData"
        DataKeyNames="ArticleID">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("ArticleDetails", new { id = Item.ArticleID })  %>' Text='<%# Item.Header %>' />
                </dt>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Artiklar saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
