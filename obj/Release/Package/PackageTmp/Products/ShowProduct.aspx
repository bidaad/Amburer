<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master"
    CodeBehind="ShowProduct.aspx.cs" Inherits="Amburer.ProductsFolder.ShowProduct" %>

<%@ Register Src="~/UserControls/UCSelectedProducts.ascx" TagName="UCSelectedProducts"
    TagPrefix="UC" %>

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
                <li class="Sep">
                    &nbsp;
                </li>
                <li >
                    <asp:Label ID="ltrHirarchy" runat="server" Text="مشاهده محصول"></asp:Label>
                </li>
            </ul>
        </div>
        <div class="clear">
        </div>
        <div class="">

            <div id="productdetails" class="MainProDetail ">
                <div class="row">
                    <div class="ProOptions col-lg-6 col-md-6 col-sm-6 col-xs-12">

                        
                        <div class="cProTitle  pull-left">
                            <h3>
                                <asp:Literal ID="lblTitle" runat="server"></asp:Literal></h3>
                        </div>
                        <div class="clear">
                        </div>
                        <div>
                            <table class="tblProInfo1">
                                <tr>
                                    <td class="TDVal">
                                        <div>
                                            <asp:Image ID="imgAvailStatus" ImageUrl="~/images/Available.gif" runat="server" />
                                        </div>
                                    </td>
                                    <td class="TDlbl">وضعیت:
                                    </td>
                                </tr>
                            </table>
                        </div>


                        <div class="clear">
                        </div>
                        <div class="cNormText">
                            <div class="ProDesc">
                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="clear"></div>
                        <div class="Padder20">
                            <asp:Button ID="btnCatalogue" CssClass="btn btn-primary" runat="server" Text="دانلود کاتالوگ" OnClick="btnCatalogue_Click" />
                            <button id="btnTechnicalDetails" type="button" class="btn btn-success">مشخصات فنی</button>
                            
                            <AKP:MsgBox runat="server" ID="msgBox" />
                        </div>
                    </div>
                    <div class="ProGallery col-lg-6 col-md-6 col-sm-6 col-xs-12">

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
                        <asp:Panel runat="server" ID="pnlProPictures">
                            <section class="slider">
                                <div class="flexslider">
                                    <ul class="slides">
                                        <asp:Repeater ID="rptProductPictures" runat="server">

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
                <div id="RegionTechnicalDetails" class="cNormText">
                    <div class="ProDesc">
                        <asp:Label ID="lblTechnicalDetails" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="Clear">
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

    <script type="text/javascript">
        $("#btnTechnicalDetails").click(function () {
            $('html, body').animate({
                scrollTop: $("#RegionTechnicalDetails").offset().top
            }, 1000);
        });

    </script>
</asp:Content>
