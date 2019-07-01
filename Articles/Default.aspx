<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master" Title="مقالات" CodeBehind="Default.aspx.cs" Inherits="Amburer.Articles.Default" %>

<%@ Register Src="~/UserControls/PagerToolbar.ascx" TagName="PagerToolbar" TagPrefix="Tlb" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div >
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp; </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="مقالات"></asp:Label>
                </li>
            </ul>
        </div>
        <div class="clearfix"></div>
        <div >
            <div class="NewsListFull Marginer20">
                <asp:Repeater ID="rptArticles" EnableViewState="false" runat="server">
                    <ItemTemplate>
                        <div class="ArticleItem">
                            <asp:HyperLink  NavigateUrl='<%#"~/Articles/ShowArticle.aspx?Code=" + Eval("Code") %>'
                                runat="server"><%#Eval("Title") %></asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="Clear">
        </div>
        <div class="Clear">
        </div>
    </div>
    <div class="Clear">
    </div>
    <div>
        <Tlb:PagerToolbar runat="server" ID="pgrToolbar" />
    </div>
</asp:Content>

