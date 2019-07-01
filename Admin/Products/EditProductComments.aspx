<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="true" Inherits="ProductComments_EditProductComments" Title="ProductComments"
    CodeBehind="EditProductComments.aspx.cs" %>

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
                                    <AKP:Lookup ID="lkpProductCode" jas="1" BaseID="Products" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblProductCode" runat="server" Text="محصول:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtName" jas="1" MaxLength="50" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblName" runat="server" Text="نام:"></asp:Label>
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
                                    <asp:Label ID="lblEmail" runat="server" Text="ایمیل:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
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
                                    <AKP:ExTextBox ID="txtComment" jas="1" Width="500" CssClass="cMultiLine" TextMode="MultiLine"
                                        runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblComment" runat="server" Text="نظر کاربر:"></asp:Label>
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
                                    <AKP:ExTextBox ID="txtAdminComment" jas="1" Width="500" CssClass="cMultiLine" TextMode="MultiLine"
                                        runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="Label1" runat="server" Text="پاسخ مدیر:"></asp:Label>
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
                                    <AKP:FarsiDate ID="dteCommentDate" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblCommentDate" runat="server" Text="تاریخ:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboHCCommentStatusCode" AllowNull="false" jas="1" BaseID="HCCommentStatuses"
                                        runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblHCCommentStatusCode" runat="server" Text="وضعیت:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="cHorSep">
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
    </div>
</asp:Content>
