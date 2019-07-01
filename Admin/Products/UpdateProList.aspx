<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Main.master" CodeBehind="UpdateProList.aspx.cs" Inherits="ConLine.Admin.Products.UpdateProList" %>
<%@ Register Src="~/UserControls/PagerToolbar.ascx" TagName="PagerToolbar" TagPrefix="Tlb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">
    <div>
    <table style="direction:ltr;">
        <tr>
            <td>
                <AKP:MsgBox runat="server" ID="msgMessage"></AKA:MsgBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="جستجو" onclick="btnSearch_Click" />
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="ذخیره" onclick="btnSave_Click" />
            </td>
            <td><AKP:LookupTree ID="treProductCatCode" jas="1" BaseID="ProductCats" runat="server" /></td>
            <td style="direction:rtl;"><asp:Label ID="lblProductCatCode" runat="server" Text="گروه:"></asp:Label></td>
        </tr>
    </table>
    </div>
    <div class="Padder1">
        <asp:DataList ID="rptProducts"  RepeatDirection="Horizontal"
        RepeatColumns="4" CssClass="tblProducts" runat="server" 
            onitemdatabound="rptProducts_ItemDataBound">
        <ItemTemplate>
            <div>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="cTitle" ToolTip='<%#FormatText(DataBinder.Eval(Container.DataItem, "Title")) %>'
                    NavigateUrl='<%#"~/ShowProduct.aspx?Code=" +DataBinder.Eval(Container.DataItem, "ProductCode")%>'>
                                <%#ShowPic(DataBinder.Eval(Container.DataItem, "Title"),DataBinder.Eval(Container.DataItem, "SmallPicFile"))%>
                </asp:HyperLink>
            </div>
            <div>
                <asp:CheckBox runat="server" Code=<%#DataBinder.Eval(Container.DataItem, "Code")%> ID="chkProduct" />
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="cTitle" ToolTip='<%#DataBinder.Eval(Container.DataItem, "Title") %>'
                    NavigateUrl='<%#"~/ShowProduct.aspx?Code=" +DataBinder.Eval(Container.DataItem, "ProductCode") %>'><%#FormatText(DataBinder.Eval(Container.DataItem, "Title"))%></asp:HyperLink>
                
            </div>
            <div class="Rial">
                <span>&nbsp;ریال&nbsp;<%#Tools.FormatCurrency2(DataBinder.Eval(Container.DataItem, "Price"))%></span></div>
                
                <div>
                    قیمت:
                    <asp:TextBox ID="txtPrice" Text=<%#DataBinder.Eval(Container.DataItem, "Price")%> runat="server"></asp:TextBox>  
                </div>
                <div>
                    وزن:
                    <asp:TextBox ID="txtWeight" Text=<%#DataBinder.Eval(Container.DataItem, "Weight")%> runat="server"></asp:TextBox>  
                </div>
                <div>
                    شرکت:
                    <asp:DropDownList ID="cboCompanyCode" Code=<%#DataBinder.Eval(Container.DataItem, "HCCompanyCode")%> runat="server"></asp:DropDownList>  
                </div>
                <div>
                    وضعیت:
                    <asp:DropDownList ID="cboHCProductAvailabilitCode" Code=<%#DataBinder.Eval(Container.DataItem, "HCProductAvailabilitCode")%> runat="server"></asp:DropDownList>  
                </div>
                <div>
                    گروه:
                    <AKP:LookupTree ID="ProCatCode" Title=<%#Eval("CatTitle") %> Code=<%#Eval("ProductCatCode") %> BaseID="ProductCats" runat="server" />
                    <%--<%#DataBinder.Eval(Container.DataItem, "Cattitle")%>--%>
                </div>            
        </ItemTemplate>
    </asp:DataList>
    </div>
    <div>
        <Tlb:PagerToolbar runat="server" ID="pgrToolbar" />
    </div>
    </asp:Content>