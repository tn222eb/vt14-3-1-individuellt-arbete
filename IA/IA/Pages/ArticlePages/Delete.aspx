<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="IA.Pages.ArticlePages.Delete" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Ta bort kategori
    </h1>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:PlaceHolder runat="server" ID="ConfirmationPlaceHolder">
        <p>
            Är du säker på att du vill ta bort kategorin från artikeln?</p>
    </asp:PlaceHolder>
    <div>
        <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ja, Ta bort"
            OnCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id2 %>' CssClass="button-style"/>
        <asp:LinkButton runat="server" ID="LinkButton1" Text="Nej, Tillbaka"
            OnCommand="LinkButton1_Command" CssClass="button-style"/>
    </div>
</asp:Content>
