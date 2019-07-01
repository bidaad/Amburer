<%@ Page Language="C#" StylesheetTheme="Edit" MasterPageFile="~/Admin/Main.master"
    AutoEventWireup="true" Inherits="Articles_EditArticles"
    Title="Articles" Codebehind="EditArticles.aspx.cs" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphMain">

    <div class="EditHeader">
        <asp:Label runat="server" ID="lblSysName"></asp:Label></div>
    <div>
        <div>
            <AKP:MsgBox runat="server" ID="msgBox"></AKP:MsgBox>
        </div>
        <div>
            <table class="cTblField">
                <tr>
                    <td class="cCtrl">
                        <AKP:ExTextBox ID="txtTitle" jas="1" Width="300" MaxLength="200" runat="server" />
                    </td>
                    <td class="cLabel">
                        <asp:Label ID="lblTitle" runat="server" Text="عنوان:"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table class="cTblField">
                <tr>
                    <td class="cCtrl">
                        <AKP:ExRadEditor ID="txtArticleContent" Width="700" Height="800" jas="1" 
                            TextMode="MultiLine" runat="server" />
                    </td>
                    <td class="cLabel">
                        <asp:Label ID="lblArticleContent" runat="server" Text="متن:"></asp:Label>
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
                                    <AKP:FarsiDate ID="dteArticleDate" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="lblArticleDate" runat="server" Text="تاريخ:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="cFieldRight">
                        <table class="cTblField">
                            <tr>
                                <td class="cCtrl">
                                    <AKP:ExTextBox SkinID="English" ID="txtUrl" Width="300" jas="1" runat="server" />
                                </td>
                                <td class="cLabel">
                                    <asp:Label ID="Label1" runat="server" Text="آدرس سایت:"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
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
