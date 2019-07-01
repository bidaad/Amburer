<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/EditPopup.master"
    AutoEventWireup="true" Inherits="ProductPictures_EditProductPictures"
    Title="ProductPictures" Codebehind="EditProductPictures.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">
    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label></div>
    <div>
        <div>
            <AKP:MsgBox runat="server" ID="msgBox" />
        </div>
        <div class="UploaderContainer">
            <fieldset style="direction: rtl; margin-right: 120px;">
                <legend>&nbsp;<asp:Label runat="server" Text="عکس" ID="lblPicFile" />&nbsp;</legend>
                <table class="cTblOneRow">
                    <tr>
                        <td class="cFieldLeft">
                            <div class="cPic">
                                <AKP:ExRadUpload ID="uplPicFile" jas="1" runat="server" AllowedFileExtensions=".gif,.jpg,.jpeg,.png,.bmp"
                                    TargetFolder="~/Files/Products/" Skin="Vista" MaxFileSize="900000" ControlObjectsVisibility="None" />
                                <br />
                                <asp:CheckBox ID="chkDeletePicFile" runat="server" Text="حذف فایل" />
                            </div>
                        </td>
                        <td class="cFieldRight">
                            <asp:HyperLink rel="lightbox" EnableViewState="false" Target="_blank" runat="server"
                                ID="hplPicFile" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    <div class="clear">
    </div>
    <div style="text-align: right">
        <table class="tblEditButtons" cellpadding="2" cellspacing="4">
            <tr>
                <td>
                    <asp:ImageButton ID="imgBtnBack" Text=" بازگشت " SkinID="BackButton" OnClientClick="window.close();"
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
