<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSelectedProducts.ascx.cs"
    Inherits="Amburer.UserControls.UCSelectedProducts" %>
<asp:Panel runat="server" ID="pnlSelectedProducts" CssClass="SelectedProsCont">
    <div class="Caption">
        <asp:Literal ID="ltrHeader" runat="server"></asp:Literal>
    </div>
    <ul class="SelectedPros">
        <asp:Repeater ID="rptSelectedPros" runat="server">
            <ItemTemplate>
                <li class="ProItem">
                    <asp:HyperLink runat="server" NavigateUrl='<%#"~/" + Tools.ConrrectUrl(Eval("EnTitle")) + Eval("ProductCode") + ".html" %>'>
                <div class="ProPicCont">
                    <asp:Image AlternateText=<%#Eval("FaTitle") %> ToolTip=<%#Eval("FaTitle") %>  ImageUrl='<%#"~/" + Eval("SmallPicFile") %>' runat="server" />
                </div>
                <div class="ProTitle">
                    <%#Eval("FaTitle") %>
                </div>
                <div class="Price">
                    
                    <%#Tools.FormatCurrency2( Eval("Price")) %>
                    تومان
                    
                </div>
                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <div class="Clear">
    </div>
</asp:Panel>
<asp:Panel ID="pnlMessage" Visible="false" CssClass="Marginer10" runat="server">
    <AKP:MsgBox runat="server" ID="msg">
    </AKP:MsgBox>
</asp:Panel>
