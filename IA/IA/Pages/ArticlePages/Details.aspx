<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="IA.Pages.ArticlePages.Details" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="MessagePanel" Visible="false" CssClass="success">
        <asp:Literal runat="server" ID="MessageLiteral" />
        <asp:ImageButton ID="ImageCloseButton" runat="server" ImageUrl="~/Content/themes/base/images/closebutton.png" CausesValidation="False" CssClass="closebutton"/>
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:ListView ID="ArticleListView" runat="server"
        ItemType="IA.Model.Article"
        SelectMethod="ArticleListView_GetData"
        UpdateMethod="ArticleListView_UpdateItem"
        DeleteMethod="ArticleListView_DeleteItem"
        DataKeyNames="ArticleID">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <h1><%#: Item.Header %></h1>

            <p><%#: Item.Content %></p>

            <span id="date"><%#: Item.CreatedDate %></span>

            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" Text="Ta bort" OnClientClick='<%# String.Format("return confirm (\"Är du säker att du vill ta bort artikeln?\")") %>' CausesValidation="false" />
            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Artikeluppgifter saknas.
            </p>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <div class="editor-field">
                <asp:TextBox ID="Header" runat="server" Text='<%# BindItem.Header %>' MaxLength="255" />
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Content" runat="server" Text='<%# BindItem.Content %>' TextMode="MultiLine" CssClass="contentcss" MaxLength="8000" />
            </div>
            <div>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" Text="Spara" />
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
            </div>
        </EditItemTemplate>
    </asp:ListView>

</asp:Content>
