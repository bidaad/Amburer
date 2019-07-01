﻿<%@ Page Language="C#" Title="دسیلی :: درباره ما" MasterPageFile="~/MainRoot.Master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Amburer.About" %>


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
                    <asp:Label ID="Label1" runat="server" Text="درباره ما"></asp:Label>
                </li>
            </ul>
        </div>
        <div class="RTL Justify LHeight1">
            <div class="LogoContainer">
                <asp:Image ID="Image1" ImageUrl="~/images/Logo.jpg" runat="server" />
            </div>
            <p>شرکت “تحرک فناور رباتیک”، پیشرو در طراحی و ساخت تجهیزات توانبخشی رباتیکی در ایران می‌باشد. این شرکت با بهره‌گیری از متخصصان داخلی و دانش‌آموختگان بهترین دانشگاه‌های ایران در رشته‌های مرتبط با تجهیزات رباتیکی و ساخت و تولید، تاسیس شده است.</p>
            <p>ربات گام‌برداری تحرک به عنوان اولین نمونه از این‌گونه تجهیزات در ایران از درون تحقیقات دانشگاهی و برمبنای طراحی‌های خلاقانه بومی به منظور توسعه و پیشبرد در زمینه تجهیزات توانبخشی طراحی و تولید شده است.</p>
            <p>ربات تحرک یک اورتز گام‌برداری متحرک است که به منظور تمرین گام‌برداری بر روی تردمیل برای بیماران دچار مشکلات حرکتی مثل بیماران سکته مغزی، ضایعه نخاعی و یا افراد مبتلا به پارکینسون مورد استفاده قرار می‌گیرد. علاوه بر این از ربات تحرک در تحلیل‌های مرتبط با گام‌برداری و به منظور کارهای تحقیقاتی در دانشگاه‌ها و پژوهشکده‌های تخصصی توانبخشی می‌توان استفاده کرد.</p>
            <p>ربات گام‌برداری تحرک باعث افزایش انگیزه بیماران در روند درمانی می‌گردد و امید به راه رفتن مجدد و بدون مشکل را در آن‌ها زنده نگه می‌دارد.</p>
            <p>شرکت تحرک فناور رباتیک همواره تلاش دارد بهترین کیفیت را در انجام وظایف خود داشته باشد و با تکیه بر تحقیق و توسعه متداوم، سرویس‌دهی مناسب و صادقانه به مشتریان و بهبود تولیدات داخلی خود و در نهایت از طریق صادرات محصولات باکیفیت نقش مهمی در پیشبرد صنعت ایران در زمینه تجهیزات پزشکی داشته باشد.</p>


        </div>
    </div>
</asp:Content>
