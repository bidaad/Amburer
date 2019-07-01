<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Main.master"
    CodeBehind="PorList.aspx.cs" Inherits="ConLine.Admin.Products.PorList" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cphMain">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="از تاریخ:"></asp:Label>
                </td>
                <td>
                    <AKP:FarsiDate runat="server" ID="dteFromDate" />
                </td>
                
                <td>
                    <asp:Label ID="Label2" runat="server" Text="تا تاریخ:"></asp:Label>
                </td>
                <td>
                    <AKP:FarsiDate runat="server" ID="dteToDate" />
                </td>
                
                <td>
                    <asp:Button ID="btnRunReport" runat="server" Text="اجرای گزارش" 
                        onclick="btnRunReport_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Repeater ID="rptProList" runat="server">
            <HeaderTemplate>
                <table class="tblThem1">
                    <tr>
                        <th>
                            نام محصول
                        </th>
                        <th>
                            تعداد بازدید
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="Them1Cell">
                        <asp:HyperLink NavigateUrl='<%#"~/Admin/Products/EditProducts.aspx?Code="+ Eval("ProductCode")%>'
                            Target="_blank" runat="server">
                                        <%#Eval("Title")%>
                        </asp:HyperLink>
                    </td>
                    <td class="Them1Cell">
                        <%#Eval("ProCount")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
