<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    ValidateRequest="false" AutoEventWireup="true" Inherits="SelectedProducts_EditSelectedProducts"
    Title="SelectedProducts" CodeBehind="EditSelectedProducts.aspx.cs" %>

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
                                    <AKP:Combo ID="cboHCSelectTypeCode" jas="1" AllowNull="false" BaseID="HCSelectTypes"
                                        runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblHCSelectTypeCode" runat="server" Text="نوع:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
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
</asp:Content>
