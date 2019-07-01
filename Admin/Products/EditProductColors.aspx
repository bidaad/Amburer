<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/EditPopup.master"
    AutoEventWireup="true" Inherits="ProductColors_EditProductColors" Title="ProductColors"
    CodeBehind="EditProductColors.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">
    <table cellpadding="0" cellspacing="0" align="center" width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="90%" class="cMainEditTable">
                    <tr>
                        <td>
                            <AKP:MsgBox ID="msgBox" runat="server" CssClass="cError" />
                        </td>
                    </tr>
                    <div>
                        <table class="cTblField">
                                        <tr>
                                            <td>
                                                <table class="EditRow">
                                                    <tr>
                                                        <td class="cCtrl">
                                                            <AKP:Combo ID="cboHCColorCode" AllowNull="false" jas="1" runat="server" />
                                                        </td>
                                                        <td class="cLabel">
                                                            <asp:Label ID="lblHCColorCode" runat="server" Text="رنگ:"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                    </div>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" class="cPopupToolbar">
                <table cellpadding="5" align="right" border="0" cellspacing="2">
                    <tr>
                        <td>
                            <asp:ImageButton ID="imgBtnBack" SkinID="BackButton" runat="server" OnClientClick="window.close()" />
                        </td>
                        <td class="cVerBar1">
                        </td>
                        <td>
                            <button onclick="ChangeLang()" class="cBtnLang" type="button">
                                <img alt="" name="langimg" border="0" src="../images/Farsibtn.gif" width="16" height="16" /></button>
                        </td>
                        <td class="cVerBar1">
                        </td>
                        <td>
                            <asp:ImageButton ID="imgBtnSave" SkinID="SaveButton" runat="server" OnClick="DoSave" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
