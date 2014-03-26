<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IA.Pages.ArticlePages.Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validation-summary-errors" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="validation-summary-errors" ValidationGroup="EditValidation" ShowModelStateErrors="false" />
    <asp:FormView ID="ArticleFormView" runat="server"
        ItemType="IA.Model.Article"
        DataKeyNames="ArticleID"
        DefaultMode="Edit"
        RenderOuterTable="false"
        SelectMethod="ArticleFormView_GetItem"
        UpdateMethod="ArticleFormView_UpdateItem">
        <EditItemTemplate>
            <div class="editor-field">
                <asp:TextBox ID="Header" runat="server" Text='<%# BindItem.Header %>' MaxLength="255" />
                <asp:RequiredFieldValidator ID="HeaderRequiredFieldValidator" runat="server" ErrorMessage="Rubrik måste anges." ControlToValidate="Header" Display="None" ValidationGroup="EditValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Content" runat="server" Text='<%# BindItem.Content %>' TextMode="MultiLine" CssClass="contentcss" MaxLength="8000" />
                <asp:RequiredFieldValidator ID="ContentRequiredFieldValidator" runat="server" ErrorMessage="Innehåll måste anges." ControlToValidate="Content" Display="None" ValidationGroup="EditValidation"></asp:RequiredFieldValidator>
            </div>

            <div>
                <asp:CheckBoxList ID="CategoryCheckBoxList" runat="server" SelectMethod="CategoryCheckBoxList_GetCategorys" DataTextField="Category" DataValueField="CategoryID" TextAlign="Left" RepeatDirection="Horizontal" OnDataBound="CategoryCheckBoxList_DataBound"></asp:CheckBoxList>
            </div>

            <div id="button-div">
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Update" ValidationGroup="EditValidation" CssClass="button-style" />
                <asp:HyperLink ID="HyperLink1" runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("ArticleDetails", new { id = Item.ArticleID }) %>' CssClass="button-style" />
            </div>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
