<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master" CodeBehind="ShowCustomer.aspx.cs" Inherits="Amburer.CustomersFolder.ShowCustomer" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <script src="../Scripts/modernizr.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.jcarousel.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.elevatezoom.js"></script>

    <div class="">
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp;
                </li>
                <li>
                    <asp:Label ID="ltrHirarchy" runat="server" Text="مشتریان"></asp:Label>
                </li>
            </ul>
        </div>
        <div class="clear">
        </div>
        <div class="">

            <div id="productdetails" class="MainProDetail ">
                <div class="row">
                    <div class="ProOptions col-lg-8 col-md-8 col-sm-8 col-xs-12">
                        <div class="clear">
                        </div>
                        <div class="cNormText">
                            <div class="ProDesc">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="Padder20">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h1 class="MainPageHeaderSlogan">عکسهای دستگاه
                                </h1>
                            </div>
                            <div class="panel-body dynamic-device-text">

                                <asp:Panel runat="server" ID="pnlProPictures">
                                    <section class="slider">
                                        <div class="flexslider">
                                            <ul class="slides">
                                                <asp:Repeater ID="rptCustomerPictures" runat="server">

                                                    <ItemTemplate>

                                                        <li data-thumb="..<%#Eval("PicFile").ToString().Replace("//","/") %>">
                                                            <img src="..<%#Eval("PicFile").ToString().Replace("//","/") %>" />
                                                        </li>
                                                    </ItemTemplate>

                                                </asp:Repeater>

                                            </ul>
                                        </div>
                                    </section>

                                    <script defer src="../Scripts/jquery.flexslider.js"></script>

                                    <script type="text/javascript">
                                        $(function () {
                                            SyntaxHighlighter.all();
                                        });
                                        $(window).load(function () {
                                            $('.flexslider').flexslider({
                                                animation: "slide",
                                                controlNav: "thumbnails",
                                                start: function (slider) {
                                                    $('body').removeClass('loading');
                                                }
                                            });
                                        });
                                    </script>
                                </asp:Panel>
                            </div>
                        </div>
                            </div>

                    </div>
                    <div class="ProGallery col-lg-4 col-md-4 col-sm-4 col-xs-12">

                        <div class="Clear">
                        </div>
                        <div class="ProFullPic text-center">
                            <ul class="gallery clearfix">
                                <li>
                                    <div class="ProMainImage">
                                        <asp:HyperLink ID="hplLargePic" runat="server" rel="prettyPhoto[gallery2]" title="">
                                            <figure>
                                                <asp:Image runat="server" BorderWidth="0" CssClass="ShowProPic" ID="imgPicFile" />
                                            </figure>
                                        </asp:HyperLink>
                                        <asp:Image runat="server" ID="imgSpecialOfferLBL" Visible="false" CssClass="SepcialOffer"
                                            ImageUrl="../images/SpecialOffer.png" alt="پیشنهاد ویژه" />
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <div class="cProTitle text-center">
                            <h3>
                                <asp:Literal ID="lblTitle" runat="server"></asp:Literal></h3>
                        </div>
                        <div class="clear">
                        </div>




                    </div>
                </div>

            </div>
            <div class="Clear">
            </div>
            <br />
        </div>
        <div class="Clear">
        </div>
    </div>
    <div class="Clear">
    </div>

</asp:Content>
