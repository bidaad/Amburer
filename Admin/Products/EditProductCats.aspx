<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="true" Inherits="ProductCats_EditProductCats"
    Title="ProductCats" Codebehind="EditProductCats.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">

    <script language="javascript" type="text/javascript">
        var SelTab = <%=SelectedTabIndex%>;
        function ClientTabSelectedHandler(sender, eventArgs)
        {
          var tabStrip = sender;
          SelTab = tabStrip.SelectedIndex
        }
        function GoToPage()
        {
            window.location.href = 'EditProductCats.aspx?SelectedTab=' + SelTab + '&Code=<%=Code%>'
        }
    </script>

    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label></div>
    <div>
        <div>
            <table class="cTblOneRow">
                <tr>
                    <td class="cFieldLeft">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox ID="txtTitle" jas="1" CssClass="cMultiLine" TextMode="MultiLine" MaxLength="200"
                                        runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblTitle" runat="server" Text="عنوان:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:LookupTree ID="treMasterCode" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblMasterCode" runat="server" Text="گروه بالاتر:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="text-align: right">
        <table cellpadding="2" cellspacing="4">
            <tr>
                <td>
                    <a class="button2" onclick="ChangeLang()">فارسی </a>
                </td>
                <td class="cVerBar1">
                </td>
                <td>
                    <asp:LinkButton ID="imgBtnBack" Text=" بازگشت " SkinID="BackButton" OnClick="GoToList"
                        runat="server" />
                </td>
                <td class="cVerBar1">
                </td>
                <td>
                    <asp:LinkButton ID="imgBtnSave" Text=" ذخیره " SkinID="SaveButton" OnClick="DoSave"
                        runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
