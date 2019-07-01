<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/MainRoot.Master" Title="گالری عکس و فیلم" Inherits="Amburer.Galleries.Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <script src="/Scripts/jwplayer.js" type="text/javascript"></script>
    <div class="">
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp; </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="گالری عکس و فیلم"></asp:Label>
                </li>
            </ul>
        </div>

        <div class="InnerPage">
            <div class="Padder10">
                <div class="dropdown pull-left">
                    <button class="btn btn-primary dropdown-toggle" style="width: 160px;" type="button" data-toggle="dropdown">
                        نوع
  <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu">
                        <li>
                            <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Galleries?MediaType=0" runat="server">همه</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Galleries?MediaType=1" runat="server">عکس</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Galleries?MediaType=2" runat="server">فیلم</asp:HyperLink></li>
                    </ul>
                </div>
                <div class="pull-left" style="width: 20px; height: 10px;">&nbsp;</div>
                <div class="dropdown pull-left">
                    <button class="btn btn-warning dropdown-toggle" style="width: 160px;" type="button" data-toggle="dropdown">
                        گروه
  <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu">
                        <li>
                            <asp:HyperLink NavigateUrl="~/Galleries?CatCode=0" runat="server">همه گروه ها</asp:HyperLink></li>
                        <asp:Repeater ID="rptGalleryCats" runat="server">
                            <ItemTemplate>

                                <li>
                                    <asp:HyperLink NavigateUrl='<%# "~/Galleries?CatCode=" + Eval("Code") %>' runat="server"><%#Eval("Name") %></asp:HyperLink></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="clear"></div>


            <div class="panel-group Padder20">
                <asp:Panel runat="server" ID="pnlPictures" CssClass="panel panel-default">
                    <div class="panel-heading RTL">عکس</div>
                    <div class="panel-body">
                        <ul class="SelectedPros gallery clearfix">
                            <asp:Repeater ID="rptPicGalleries" runat="server">
                                <ItemTemplate>
                                    <li class="GalleryPicItem">
                                        <div class="block ">
                                            <a href='<%#Eval("MediaFile") %>' rel="prettyPhoto">
                                                <asp:Image AlternateText='<%#Eval("Title") %>' ToolTip='<%#Eval("Title") %>'
                                                    ImageUrl='<%#"~/" + Eval("MediaFile") %>' runat="server" />
                                            </a>
                                        </div>
                                        <div class="ProTitle text-center">
                                            <%#Eval("Title") %>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <%--<script type="text/javascript" charset="utf-8">
                        $(document).ready(function () {
                            $("area[rel^='prettyPhoto']").prettyPhoto();

                            $(".gallery:first a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', theme: 'light_square', slideshow: 3000, autoplay_slideshow: true });
                            $(".gallery:gt(0) a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'fast', slideshow: 10000, hideflash: true });


                        });
                    </script>--%>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlMovies" CssClass="panel panel-warning">
                    <div class="panel-heading RTL">فیلم</div>
                    <div class="panel-body">
                        <ul class="SelectedPros">
                            <asp:Repeater ID="rptMovies" runat="server">
                                <ItemTemplate>
                                    <li class="GalleryPicItem">
                                        <div>
                                            <div id="mediaplayer<%#Eval("Code") %>">
                                            </div>
                                            <script type="text/javascript">
                                                jwplayer("mediaplayer<%#Eval("Code") %>").setup({
                                                    flashplayer: "/Files/swf/player.swf",
                                                    file: "<%# Convert.ToString(Eval("MediaFile")).Replace("//","/") %>",
                                                    image: "/Files/Media/Preview1.jpg"
                                                });
                                            </script>
                                        </div>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </asp:Panel>

            </div>
        </div>
        <div class="Clear">
        </div>

        <div class="Clear">
        </div>
    </div>
    <div class="Clear">
    </div>
    <h2>Picture alone</h2>
    <ul class="gallery clearfix">
        <li><a href="../images/2.jpg" rel="prettyPhoto" title="&lt;a href=&#x27;http://www.google.ca&#x27; target=&#x27;_blank&#x27; &gt;This will open Google.com in a new window&lt;/a&gt;">
            <img src="../images/t_2.jpg" width="60" height="60" alt="Picture alone 1" /></a></li>
    </ul>
</asp:Content>
