<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master" AutoEventWireup="true" Inherits="Galleries_EditGalleries" Title="Galleries" CodeBehind="EditGalleries.aspx.cs" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">
     <div>
        <AKP:MsgBox runat="server" ID="msgBox" />
    </div>
    <div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtTitle" jas="1" Width="600" MaxLength="500" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblTitle" runat="server" Text="عنوان:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
            </table>
        </div>
        <div class="UploaderContainer">
            <fieldset style="direction: rtl; margin-right: 120px;">
                <legend>&nbsp;<asp:Label runat="server" Text="فایل" ID="lblMediaFile" />&nbsp;</legend>
                <table class="cTblOneRow">
                    <tr>
                        <td class="cFieldLeft">
                            <div class="cPic">
                                <AKP:ExRadUpload ID="uplMediaFile" jas="1" runat="server" AllowedFileExtensions=".gif,.jpg,.jpeg,.png,.bmp,.flv"
                                    TargetFolder="~/Files/Galleries/" Skin="Vista" MaxFileSize="99999999" ControlObjectsVisibility="None" />
                                <br />
                                <asp:CheckBox ID="chkDeleteMediaFile" runat="server" Text="حذف فایل" />
                            </div>
                        </td>
                        <td class="cFieldRight">
                            <asp:HyperLink rel="lightbox" EnableViewState="false" Target="_blank" runat="server"
                                ID="hplMediaFile" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboHCGalleryCatCode" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblHCGalleryCatCode" runat="server" Text="گروه:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:Combo ID="cboHCMediaTypeCode" AllowNull="false" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblHCMediaTypeCode" runat="server" Text="نوع:"></asp:Label>
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
                                    <AKP:ExTextBox ID="txtDescription" jas="1" CssClass="cMultiLine" TextMode="MultiLine" MaxLength="1000" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblDescription" runat="server" Text="توضیحات:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight"></td>
                </tr>
            </table>
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
</asp:Content>
