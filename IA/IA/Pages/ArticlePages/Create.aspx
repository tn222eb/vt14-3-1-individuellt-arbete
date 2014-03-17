<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IA.Pages.ArticlePages.Create" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Ny artikel
    </h1>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validation-summary-errors" ValidationGroup="CreateValidation" ShowModelStateErrors="false"/>
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
                <asp:RequiredFieldValidator ID="HeaderRequiredFieldValidator" runat="server" ErrorMessage="Rubrik måste anges." ControlToValidate="Header" Display="None" ValidationGroup="CreateValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="editor-label">
                <label for="Content">Innehåll</label>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Content" runat="server" Text='<%# BindItem.Content %>' TextMode="MultiLine" CssClass="contentcss" MaxLength="8000" />
                <asp:RequiredFieldValidator ID="ContentRequiredFieldValidator" runat="server" ErrorMessage="Innehåll måste anges." ControlToValidate="Content" Display="None" ValidationGroup="CreateValidation"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:CheckBoxList ID="CategoryCheckBoxList" runat="server" SelectMethod="CategoryCheckBoxList_GetCategorys" DataTextField="Category" DataValueField="CategoryID" TextAlign="Left" RepeatDirection="Horizontal"></asp:CheckBoxList>
            </div>
            <div id="button-div">
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Lägg till" CommandName="Insert" CssClass="button-style" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Tillbaka" NavigateUrl='<%$ RouteUrl:routename=Default %>' CssClass="button-style" />
            </div>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
