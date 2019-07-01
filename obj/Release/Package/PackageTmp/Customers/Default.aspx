<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master" Title="مشتریان" CodeBehind="Default.aspx.cs" Inherits="Amburer.CustomersFolder.Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div class="">
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp; </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="مشتریان"></asp:Label>
                </li>
            </ul>
        </div>

        <div class="InnerPage">
            <ul class="SelectedPros">
        <asp:Repeater ID="rptCustomers" runat="server">
            <ItemTemplate>
                <li class="ProListItem CustomerGridView">
                    
                    <asp:HyperLink CssClass="zoom" runat="server" NavigateUrl='<%#"~/Customers/ShowCustomer.aspx?Code=" + Eval("Code") %>'>
                        <div class="ListViewRight">
                            <div class="CustomerLogoPicCont">
                                <div class="block">
                                    <asp:Image AlternateText='<%#Eval("Title") %>' ToolTip='<%#Eval("Title") %>'
                                        ImageUrl='<%#"~/" + Eval("LogoFile") %>' runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="ListViewLeft">
                            <div class="ProTitle">
                                <%#Eval("Title") %>
                            </div>
                            <div class="ProDesc NoDisp">
                                <%#Eval("Description") %>
                            </div>
                            
                        </div>
                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
        </div>
        <div class="Clear">
        </div>
        
        <div class="Clear">
        </div>
    </div>
    <div class="Clear">
    </div>
    
</asp:Content>