<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="IA.Pages.ArticlePages.Details" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Content/themes/base/images/closebutton.png" CausesValidation="False" CssClass="closebutton" />
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validation-summary-errors" ValidationGroup="EditValidation" ShowModelStateErrors="false"/>

    <asp:ListView ID="ArticleListView" runat="server"
        ItemType="IA.Model.Article"
        SelectMethod="ArticleListView_GetData"
        DeleteMethod="ArticleListView_DeleteItem"
        DataKeyNames="ArticleID">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            
    <asp:ListView ID="ArticleTypeListView" runat="server"
        ItemType="IA.Model.ArticleType"
        SelectMethod="ArticleTypeListView_GetData"
        DataKeyNames="ArticleTypeID, ArticleID, CategoryID"
        OnItemDataBound="ArticleTypeListView_ItemDataBound">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <div id="Articletype-field">
             <asp:Label ID="CategoryLabel" runat="server" Text="{0}" CssClass="italic-text" />
            </div>
            <br/>
        </ItemTemplate>
        <EmptyDataTemplate>
            <span id ="articletype-saknas">Artikeltyp saknas.</span>
        </EmptyDataTemplate>
    </asp:ListView>

            <h1><%#: Item.Header %></h1>

            <p><%#: Item.Content %></p>

            <span id="date"><%# Item.CreatedDate.ToString("yyyy/MM/dd") %></span>

            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" OnClientClick='<%# String.Format("return confirm (\"Är du säker att du vill ta bort artikeln?\")") %>' CausesValidation="false" CssClass="button-style" />
           <asp:HyperLink ID="HyperLink1" runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("EditArticle", new { id = Item.ArticleID }) %>' CssClass="button-style"/>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Artikeln saknas.
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
