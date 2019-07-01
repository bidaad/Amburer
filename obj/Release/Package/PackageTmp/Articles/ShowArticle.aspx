<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master" CodeBehind="ShowArticle.aspx.cs" Inherits="Amburer.Articles.ShowArticle" %>

<%@ Register Src="~/UserControls/ShareTools.ascx" TagName="ShareTools" TagPrefix="UCST" %>
<%@ Register Src="~/UserControls/UCProductList.ascx" TagName="UCProductList" TagPrefix="UC" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <script type="text/javascript">
        var divFontsArray = new Array('lblSuTitr', 'lblTitle', 'lblBody', 'lblDate *');
        var currentFontSize = 9;

        function changefSize(Wdo) {
            if (Wdo == 'plus')
                currentFontSize++;
            else if (Wdo == 'reset')
                currentFontSize = 9;
            else if (Wdo == 'minus')
                currentFontSize--;

            for (i = 0; i < divFontsArray.length; i++) {
                var thisObj = $('#' + divFontsArray[i]);
                if (Wdo == 'reset')
                    thisObj.css('font-size', '');
                else
                    thisObj.css('font-size', currentFontSize + 'pt');
            }
        }

    </script>
    <div>
        <div>
            <div class="Hierarchy">
                <ul class="mnuHierarchy">
                    <li class="IcHome">
                        <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                    </li>
                    <li class="Sep">&nbsp; </li>
                    <li>
                        <asp:Label ID="Label1" runat="server" Text="مقاله"></asp:Label>
                    </li>
                </ul>
            </div>
            <div class="clearfix"></div>
            <div class="FullNewsBox">

                <div>
                    <div class="Tools hidden">
                        <div style="padding: 5px; text-align: left">
                            <ul class="Tools">
                                <li>
                                    <div class="ToolPrint">
                                        <a onclick="ShowPrintNews('<%=ArticleCode %>')" href="#">
                                            <asp:Image runat="server" ID="imgPrintVersion" ImageUrl="~/images/spacer.gif" Style="width: 17px; height: 16px; border: none"
                                                AlternateText="نسخه قابل پرينت" alt="نسخه قابل پرينت" /></a>
                                    </div>
                                </li>

                                <li>
                                    <div class="ToolSmallerFont">
                                        <a onclick="return changefSize('minus')" href="#a">
                                            <asp:Image runat="server" ID="imgFontLower" ImageUrl="/images/spacer.gif" Style="width: 29px; height: 16px; border: none"
                                                ToolTip="کوچکتر کردن اندازه فونت" AlternateText="" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="ToolLargerFont">
                                        <a onclick="return changefSize('plus')" href="#a">
                                            <asp:Image runat="server" ID="imgFontGreater" ImageUrl="/images/spacer.gif" Style="width: 29px; height: 16px; border: none"
                                                ToolTip="بزرگتر کردن اندازه فونت" AlternateText="بزرگتر کردن اندازه فونت" /></a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="Clear">
                    </div>
                    <div class="BotLine">
                    </div>
                </div>
                <div class="NewsToolLeft">
                    <UCST:ShareTools runat="server" />
                </div>
                <div class="IconCaption">
                    <asp:Image ID="Image1" ImageUrl="~/images/icon-article-large.png" runat="server" />
                </div>
                <div class="clear"></div>
                <asp:Panel runat="server" ID="pnlTextNews">
                    <div class="Padder5">
                        <div class="ShowNews">
                            <div>
                                <div class="NewsDate">
                                    <span class="fa fa-calendar Gray"></span>
                                    <asp:Label ID="lblDate" ClientIDMode="Static" runat="server"></asp:Label>

                                </div>
                                <div class="FullNewsTitle">
                                    <asp:Label ID="lblTitle" ClientIDMode="Static" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="Clear">
                    </div>
                    <div class="NewsBody">
                        <div id="lblBody" class="Justify">
                            <asp:Literal ID="ltrArticleBody" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div class="ArticleLink">
                        <span class="fa fa-link "></span>
                        <asp:HyperLink ID="hplUrl" Target="_blank" runat="server"></asp:HyperLink>

                    </div>
                </asp:Panel>
            </div>
        </div>
        <div class="Clear">
        </div>

    </div>
    <div class="Clear">
    </div>

</asp:Content>
