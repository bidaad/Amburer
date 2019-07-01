<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainMenu.ascx.cs"
    Inherits="Amburer.UserControls.MainMenu" %>
<div class="VerMenu">
    <div class="MenuContent">
        <div class="SubMenuCont">
            <div class="VMenuItem" id="mnuCondom">
                <asp:HyperLink ID="HyperLink4" NavigateUrl="~/Products/?C=1" runat="server">کاندوم</asp:HyperLink>
            </div>
            <div class="hide SubMenu" id="submenuMode">
                <div>
                    <div class="row">
                        <div class="col-md-6">
                            <ul class="navSubMenu">
                                <li class="boldtext">
                                    <asp:HyperLink ID="HyperLink40" NavigateUrl="~/Products/?C=6" runat="server">کاندوم تاخیری</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink41" NavigateUrl="~/Products/?C=7" runat="server">کاندوم خاردار</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink42" NavigateUrl="~/Products/?C=8" runat="server">کاندوم حلقوی</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink43" NavigateUrl="~/Products/?C=9" runat="server">کاندوم نازک</asp:HyperLink></li>
                            </ul>
                        </div>
                        <div class="col-md-6">
                            <ul class="navSubMenu">
                                <li class="boldtext">
                                    <asp:HyperLink ID="HyperLink34" NavigateUrl="~/Products/?C=10" runat="server">کاندوم تنگ کننده</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink5" NavigateUrl="~/Products/?C=11" runat="server">کاندوم روان کننده</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink6" NavigateUrl="~/Products/?C=12" runat="server">کاندوم آنتی باکتریال</asp:HyperLink></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="SubMenuCont">
            <div class="VMenuItem" id="mnuAmzGel">
                <asp:HyperLink ID="HyperLink53" NavigateUrl="~/Products/?C=2" runat="server">ژل آمیزشی</asp:HyperLink>
            </div>
            <div class="hide SubMenu" id="submenuAmzGel">
                <div>
                    <div class="row">
                        <ul class="navSubMenu">
                            <li class="boldtext">
                                <asp:HyperLink ID="HyperLink54" NavigateUrl="~/Products/?C=13" runat="server">ژل تاخیری</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="HyperLink66" NavigateUrl="~/Products/?C=14" runat="server">ژل حجم دهنده</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="HyperLink79" NavigateUrl="~/Products/?C=15" runat="server">ژل روان کننده</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="HyperLink80" NavigateUrl="~/Products/?C=16" runat="server">ژل تنگ کننده</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="HyperLink81" NavigateUrl="~/Products/?C=17" runat="server">ژل محرک</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="HyperLink82" NavigateUrl="~/Products/?C=18" runat="server">ژل گرم کننده</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="HyperLink83" NavigateUrl="~/Products/?C=19" runat="server">ژل تقویت کننده</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Products/?C=20" runat="server">ژل خنک کننده</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="HyperLink30" NavigateUrl="~/Products/?C=1" runat="server">ژل ضدعفونی کننده</asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="SubMenuCont">
            <div class="VMenuItem" id="mnuDelay">
                <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Products/?C=3" runat="server">اسپری آمیزشی</asp:HyperLink>
            </div>
            <div class="hide SubMenu" id="submenuCellPhone">
                <div class="row">
                    <ul class="navSubMenu">
                        <li class="boldtext">
                            <asp:HyperLink ID="HyperLink7" NavigateUrl="~/Products/?C=21" runat="server">کاندوم تاخیری</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink8" NavigateUrl="~/Products/?C=22" runat="server">اسپری تاخیری</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink9" NavigateUrl="~/Products/?C=23" runat="server">ژل تاخیری</asp:HyperLink></li>
                    </ul>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="SubMenuCont">
            <div class="VMenuItem" id="mnuHajmDehande">
                <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Products/?C=27" runat="server">سایر محصولات</asp:HyperLink>
            </div>
            <div class="hide SubMenu" id="submenuTablet">
                <div>
                    <ul class="OtherCatMenu">
                        <asp:Repeater ID="rptOtherProducts" runat="server">
                            <ItemTemplate>
                                <li>
                                     <asp:HyperLink ID="HyperLink10" NavigateUrl='<%#"~/" + Eval("EnTitle") + "-" + Eval("Code") + ".html" %>' runat="server">
                                            <%#Eval("FaTitle") %>
                                            </asp:HyperLink>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
