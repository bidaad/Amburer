<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master" AutoEventWireup="true" Inherits="Customers_EditCustomers" Title="Customers" Codebehind="EditCustomers.aspx.cs" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">

    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label>
    </div>
    <div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox id="txtTitle" jas="1" Width="500" maxlength="500" runat="server" />
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
            <legend>&nbsp;<asp:Label runat="server" Text="لوگو" ID="lblLogoFile" />&nbsp;</legend>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <div class="cPic">
                            <AKP:ExRadUpload ID="uplLogoFile" jas="1" runat="server" AllowedFileExtensions=".gif,.jpg,.jpeg,.png,.bmp"
                                TargetFolder="~/Files/Customers/" Skin="Vista" MaxFileSize="900000" ControlObjectsVisibility="None" />
                            <br />
                            <asp:CheckBox ID="chkDeleteLogoFile" runat="server" Text="حذف فایل" />
                        </div>
                    </td>
                    <td class="cFieldRight">
                        <asp:HyperLink rel="lightbox" EnableViewState="false" Target="_blank" runat="server"
                            ID="hplLogoFile" />
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
                                    <AKP:ExTextBox id="txtAddress" jas="1" cssclass="cMultiLine" textmode="MultiLine" maxlength="500" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblAddress" runat="server" Text="آدرس:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:extextbox id="txtDescription" jas="1" cssclass="cMultiLine" textmode="MultiLine" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblDescription" runat="server" Text="توضیحات:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>

    </div>
    <table class="cEditTabs" width="100%">
        <tr>
            <td>
                <div>
                    <div class="TabHeaderData">
                        <telerik:RadTabStrip Style="margin-right: 8px;" dir="rtl" ID="tsOrders" runat="server"
                            MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Vista" SkinsPath="~/RadControls/TabStrip/Skins">
                            <Tabs>
                                <telerik:RadTab ID="Tab1" runat="server" Text="عکسها">
                                </telerik:RadTab>
                                
                                
                            </Tabs>
                        </telerik:RadTabStrip>
                        <div class="cTabWrapper">
                            <telerik:RadMultiPage ID="RadMultiPage1" SelectedIndex="0" runat="server">
                                <telerik:RadPageView ID="RadPageView2" runat="server">
                                    <div class="cDivSep">
                                    </div>
                                    <div class="cBrowseArea" id="CustomerPictures">
                                    </div>
                                    <div class="cDivSep">
                                    </div>
                                </telerik:RadPageView>
                                
                            </telerik:RadMultiPage>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
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
