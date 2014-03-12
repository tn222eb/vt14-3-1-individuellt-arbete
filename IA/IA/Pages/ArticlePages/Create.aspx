<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IA.Pages.ArticlePages.Create" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <h1>
        Ny artikel
    </h1>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:FormView ID="ArticleFormView" runat="server"
        ItemType="IA.Model.Article"
        DefaultMode="Insert"
        RenderOuterTable="false"
        InsertMethod="ArticleFormView_InsertItem">
        <InsertItemTemplate>
            <div class="editor-label">
                <label for="Header">Rubrik</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Header" runat="server" Text='<%# BindItem.Header %>' MaxLength="255" />
            </div>
            <div class="editor-label">
                <label for="Content">Innehåll</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Content" runat="server" Text='<%# BindItem.Content %>' TextMode="MultiLine" CssClass="contentcss" MaxLength="8000" />
            </div>

            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Lägg till" CommandName="Insert" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Tillbaka" NavigateUrl='<%$ RouteUrl:routename=Default %>' />
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
