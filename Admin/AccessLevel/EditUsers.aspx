<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="true" Inherits="Users_EditUsers"
    Title="Users" Codebehind="EditUsers.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">

   

    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label></div>
    <div>
        <div>
            <AKP:MsgBox runat="server" ID="msgBox" />
        </div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtID" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblID" runat="server" Text="شناسه:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExCheckBox ID="chkAutoLogin" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblAutoLogin" runat="server" Text="ورود خودکار:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtName" jas="1" MaxLength="100" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblName" runat="server" Text="نام کامل:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExCheckBox ID="chkActive" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblActive" runat="server" Text="فعال:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtEmail" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblEmail" runat="server" Text="ايميل:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtPassword" SkinID="English" TextMode="Password" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblPassword" runat="server" Text="کلمه عبور:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboHCGenderCode" AllowNull="false" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblHCGenderCode" runat="server" Text="جنسيت:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                    </td>
                </tr>
            </table>
        </div>
        
        
        
        
    </div>
    <div class="TabHeaderData">
        <telerik:RadTabStrip Style="margin-right: 8px;" dir="rtl" ID="tsUsers" runat="server"
            MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Vista" SkinsPath="~/RadControls/TabStrip/Skins">
            <Tabs>
                <telerik:RadTab ID="Tab1" runat="server" Text="گروه های کاربر">
                </telerik:RadTab>
                
                
            </Tabs>
        </telerik:RadTabStrip>
        <div class="cTabWrapper">
            <telerik:RadMultiPage ID="RadMultiPage1" SelectedIndex="0" runat="server">
                <telerik:RadPageView ID="PageView1" runat="server">
                    <div class="cDivSep">
                    </div>
                    <div class="cBrowseArea" id="UserGroups">
                    </div>
                    <div class="cDivSep">
                    </div>
                </telerik:RadPageView>
                
                
            </telerik:RadMultiPage>
        </div>
    </div>
    <div style="text-align: right">
        <table class="tblEditButtons" cellpadding="2" cellspacing="4">
            <tr>
                <td>
                    <asp:ImageButton ID="imgBtnBack" Text=" بازگشت " SkinID="BackButton" OnClick="GoToList"
                        runat="server" />
                </td>
                <td>
                    <asp:ImageButton ID="imgBtnSave" Text=" ذخیره " SkinID="SaveButton" OnClick="DoSave"
                        runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hfPassword" runat="server" />
</asp:Content>
