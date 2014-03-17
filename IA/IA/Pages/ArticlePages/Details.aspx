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
        UpdateMethod="ArticleListView_UpdateItem"
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
              <asp:HyperLink ID="ArticleTypeDeleteHyperLink" runat="server" NavigateUrl='<%# GetRouteUrl("DeleteArticleType", new { id = Item.ArticleID, id2 = Item.ArticleTypeID })  %>' Text="Ta bort" CssClass="grot" />
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
            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" CssClass="button-style" />
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Artikeln saknas.
            </p>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <div class="editor-field">
                <asp:TextBox ID="Header" runat="server" Text='<%# BindItem.Header %>' MaxLength="255" />
                 <asp:RequiredFieldValidator ID="HeaderRequiredFieldValidator" runat="server" ErrorMessage="Rubrik måste anges." ControlToValidate="Header" Display="None" ValidationGroup="EditValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="editor-field">
                <asp:TextBox ID="Content" runat="server" Text='<%# BindItem.Content %>' TextMode="MultiLine" CssClass="contentcss" MaxLength="8000" />
                 <asp:RequiredFieldValidator ID="ContentRequiredFieldValidator" runat="server" ErrorMessage="Innehåll måste anges." ControlToValidate="Content" Display="None" ValidationGroup="EditValidation"></asp:RequiredFieldValidator>
            </div>
            <div id="button-div">
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Update" Text="Spara" ValidationGroup="EditValidation" CssClass="button-style"/>
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" ValidationGroup="EditValidation" CssClass="button-style"/>
            </div>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
