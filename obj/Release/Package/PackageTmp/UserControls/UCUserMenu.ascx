<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUserMenu.ascx.cs" Inherits="Amburer.UserControls.UCUserMenu" %>
<div class="panel panel-default ">
    <div class="panel-heading ListTitle">
        <h3 class="panel-title BulletList">منوی کاربر</h3>
    </div>
    <div class="Padder5 text-center">
        <div class="UserNav">
            <ul>

                <li>
                    <asp:HyperLink ID="hplNewAds" NavigateUrl="http://ipanel.Amburer.ir/Users/EditAdvertise.aspx" runat="server">آگهی جدید
                        <span class="fa fa-plus Gray"></span>
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplMyAds" NavigateUrl="http://ipanel.Amburer.ir/Users/Default.aspx" runat="server">فهرست آگهی ها
                        <span class="fa fa-list Gray"></span>
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplProfile" NavigateUrl="http://ipanel.Amburer.ir/Users/Profile.aspx" runat="server">اطلاعات کاربری
                        <span class="fa fa-user Gray"></span>
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplContactSupport" NavigateUrl="http://ipanel.Amburer.ir/ContactUs.aspx" runat="server">تماس با پشتیبانی
                        <span class="fa fa-support Gray"></span>
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplCharge" NavigateUrl="http://ipanel.Amburer.ir/Users/AccountCharge.aspx" runat="server">شارژ حساب
                        <span class="fa fa-battery-quarter Gray"></span>
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplTransactions" NavigateUrl="http://ipanel.Amburer.ir/Users/UserTransactions.aspx" runat="server">تراکنشها
                        <span class="fa fa-list-alt Gray"></span>
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplHelp" NavigateUrl="http://ipanel.Amburer.ir/Help.aspx" runat="server">راهنما
                        <span class="fa fa-info-circle Gray"></span>
                    </asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink ID="hplAdvertisement" NavigateUrl="http://ipanel.Amburer.ir/Advertisement.aspx" runat="server">تعرفه آگهی ویژه
                        <span class="fa fa-diamond Gray"></span>
                    </asp:HyperLink>
                </li>
                
            </ul>

        </div>
        <div class="clear">
        </div>
    </div>
</div>
