<%@ Page Language="C#" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Amburer._Default" %>

<%@ Register Src="~/UserControls/UCSelectedPics.ascx" TagName="UCSelectedPics" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/UCProductList.ascx" TagName="UCProductList" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/Banner.ascx" TagName="UCBanner" TagPrefix="UC" %>
<%@ Register Src="~/UserControls/NewsBox.ascx" TagName="NewsBox" TagPrefix="NWS" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">

    <div class="MainDataCont">
        <div class="row hidden-sm hidden-xs">
            <section class="col-lg-3 col-md-3 col-sm-12 col-xs-12 main-column text-center">
                <UC:UCBanner runat="server" ID="Banner1" PositionCode="1" />
            </section>
            <section class="col-lg-6 col-md-6 col-sm-12 col-xs-12 main-column hidden-xs">
                <UC:UCSelectedPics runat="server" ID="UCSelectedPics1" />
            </section>
            <aside class="col-lg-3 col-md-3 col-sm-12 col-xs-12 offcanvas-sidebar">
                <%--<UC:UCBanner runat="server" PositionCode="1" />--%>
                <NWS:NewsBox runat="server" />
            </aside>
        </div>

        <div class="Clear">
        </div>
        <div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h1 class="MainPageHeaderSlogan">ربات توانبخشی تحرک
                            </h1>
                        </div>
                        <div class="panel-body">
                            <div class="MainPageText">
                                ربات توانبخشی "تحرک" برای بیمارانی که از اختلالات حرکتی پا رنج می‌برند، امکان انجام تمرینات مختلف توانبخشی را به منظور اصلاح الگوی راه رفتن فراهم می‌کند. این دستگاه رباتیکی می‌تواند به عنوان روشی نوین در مراکز توانبخشی، جایگزین روش‌های سنتی گردد. برای انجام تمرینات، یک بازوی رباتیکی به پای بیمار متصل شده و با استفاده از الگوهای هوشمند از پیش طراحی شده، بیمار به کمک ربات بر روی تردمیل حرکت می‌کند. نرم‌افزار طراحی شده برای این دستگاه، علاوه بر آن‌که با واسط گرافیکی زیبای خود باعث افزایش انگیزه در بیمار می‌گردد، به گونه‌ای طراحی شده است که می‌تواند به عنوان ابزاری تحقیقاتی در آنالیزهای مربوط به گام برداشتن مورد استفاده قرار گیرد و برنامه‌های کنترلی (تمرینی) متفاوتی بر روی آن اجرا گردد.
                        <div class="DownloadContainer">
                            <asp:HyperLink ID="hplPDF1" NavigateUrl="~/Files/Docs/Taharok-BWSS.pdf" runat="server">
                                <asp:Image ID="imgPDF1" ImageUrl="~/images/PDF.png" runat="server" /><br />
                                دریافت بروشور دستگاه
                            </asp:HyperLink>
                        </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h1 class="MainPageHeaderSlogan">دستگاه تعلیق وزن دینامیکی تحرک
                            </h1>
                        </div>
                        <div class="panel-body dynamic-device-text">
                            <div class="MainPageText">
                                سیستم تعلیق وزن "تحرک"، امکان تعلیق وزن بیمار به منظور انجام تمرینات نوانبخشی و یا تمرین بر روی تردمیل فرآهم می اورد. این سیستم می تواند بیمار را به صورت کاملا ایمن معلق نموده و یا تنها بخشی از وزن بیمار را خنثی کند. با این سیستم بیمار در حین تمرینات توانبخشی، احساس راحتی و امنیت داشته و ابعاد مناسب و سهولت استفاده از این دستگاه آن را برای استفاده های خانگی مناسب ساخته است.
                                <br /><br /><br />
                                <div class="DownloadContainer">
                                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Files/Docs/Taharok-Gait-Trainer-Robot.pdf" runat="server">
                                    <asp:Image ID="Image1" ImageUrl="~/images/PDF.png" runat="server" /><br />
                                    دریافت بروشور دستگاه
                                </asp:HyperLink>
                            </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>




        </div>
        <asp:Panel runat="server" ID="pnlSpecialProduct" CssClass="ProBox pull-left">
            <div class="pro-field-image">
                <asp:HyperLink ID="hplSepcialPro" runat="server">
                    <asp:Image ID="imgSpecialPro" runat="server" />
                </asp:HyperLink>
            </div>
            <div class="pro-field-title">
                <span class="field-content">
                    <asp:HyperLink ID="hplSpecialProTitle" runat="server">
                    </asp:HyperLink>
                </span>
            </div>
            <div class="pro-field-desc">
                <span class="field-content">
                    <asp:Label ID="lblSpecialProDesc" runat="server">
                    </asp:Label>
                </span>
            </div>
        </asp:Panel>

        <div class="MediaBox pull-left">
            <script type="text/javascript" src="/Scripts/jwplayer.js"></script>
            <div>
                <div id="mediaplayer">
                </div>
                <script type="text/javascript">
                    jwplayer("mediaplayer").setup({
                        flashplayer: "/Files/swf/player.swf",
                        file: "/Files/Media/BWSS.flv",
                        image: "/Files/Media/Preview1.jpg"
                    });
                </script>
            </div>
        </div>

        <div class="clear">
        </div>

    </div>
</asp:Content>
