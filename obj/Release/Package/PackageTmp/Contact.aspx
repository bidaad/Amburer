<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MainRoot.Master" Title="اطلاعات تماس" CodeBehind="Contact.aspx.cs" Inherits="Amburer.Contact" %>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="CP1">
    <div id="about">
        <div class="Hierarchy">
            <ul class="mnuHierarchy">
                <li class="IcHome">
                    <asp:HyperLink ID="hplMainPage" NavigateUrl="~/" runat="server">صفحه اصلی</asp:HyperLink>
                </li>
                <li class="Sep">&nbsp;
                </li>
                <li>
                    <asp:Label ID="Label1" runat="server" Text="تماس با ما"></asp:Label>
                </li>
            </ul>
        </div>
        <div>

            <div class="Clear"></div>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h1 class="MainPageHeaderSlogan">تماس با ما</h1>
                </div>
                <div class="panel-body">
                    <div class="MainPageText">
                        <div class="LogoContainer">
                            <asp:Image ID="Image1" ImageUrl="~/images/Contacts-128.png" runat="server" />
                        </div>
                        <p><span class="fa fa-map-marker Gray"></span>&nbsp;&nbsp;&nbsp;&nbsp;آدرس: تهران – خیابان کارگر شمالی&nbsp;– نرسیده به بیمارستان قلب – خیابان شهریور&nbsp;– پلاک ۲۵&nbsp;–&nbsp;واحد سوم شرقی</p>
                        <p><span class="fa fa-phone Gray"></span>&nbsp;&nbsp;&nbsp;&nbsp;تلفن: ۸۸۲۲۱۸۸۰&nbsp;– ۰۹۱۲۷۱۱۰۴۳۵</p>
                        <p><span class="fa fa-fax Gray"></span>&nbsp;&nbsp;&nbsp;&nbsp;فکس:&nbsp;۸۸۲۲۱۷۵۲</p>
                        <p><span class="fa fa-envelope Gray"></span>&nbsp;&nbsp;&nbsp;&nbsp; ایمیل: <a href="mailto:info@amburer.com">info@amburer.com</a></p>
                    </div>
                </div>
            </div>

            <div class="Clear"></div>
            <div class="panel panel-success">
                <div class="panel-heading">
                    <h1 class="MainPageHeaderSlogan">نقشه</h1>
                </div>
                <div class="panel-body"><div id="CP1_pnlGoogleMap" class="WinRadiusGray Padder10">
		
                <div id="map"></div>
                <script>

                    var map;
                    function initMap() {
                        var myLatLng = { lat: 35.719748, lng: 51.388184};

                        map = new google.maps.Map(document.getElementById('map'), {
                            center: { lat: 35.719748, lng: 51.388184 },
                            zoom: 16
                        });
                        var marker = new google.maps.Marker({
                            position: myLatLng,
                            map: map,
                            title: ''
                        });

                    }

                </script>
                <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDBPl3Xg8AykOgG-3Q-hPRsi_v8_x6i6Rs&callback=initMap"
                    async defer></script>
            
	</div></div>
            </div>


        </div>
    </div>
</asp:Content>
