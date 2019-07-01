<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/EditPopup.master" AutoEventWireup="true" CodeFile="EditCustomerPictures.aspx.cs" Inherits="CustomerPictures_EditCustomerPictures" Title="CustomerPictures" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">


    <div>
        <AKP:MsgBox runat="server" ID="msgBox" />
    </div>
    <div class="UploaderContainer">
        <fieldset style="direction: rtl; margin-right: 120px;">
            <legend>&nbsp;<asp:Label runat="server" Text="لوگو" ID="lblPicFile" />&nbsp;</legend>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <div class="cPic">
                            <AKP:ExRadUpload ID="uplPicFile" jas="1" runat="server" AllowedFileExtensions=".gif,.jpg,.jpeg,.png,.bmp"
                                TargetFolder="~/Files/Customers/" Skin="Vista" MaxFileSize="900000" ControlObjectsVisibility="None" />
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
