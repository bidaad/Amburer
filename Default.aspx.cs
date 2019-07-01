using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Amburer.Old_App_Code.DAL;
using System.Reflection;


namespace Amburer
{
    public partial class _Default : System.Web.UI.Page
    {
        public string StartHour = "";
        public string StartMinute = "";
        public string StartSecond = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            int? HCNewsCatCode = null;
            DateTimeMethods dtm = new DateTimeMethods();


            //UCProductListSepcial.ShowSpecialProducts();
            //UCProductListNew.ShowNewProducts();
            //UCProductListMostSold.ShowMostSoldProducts();
            //UCProductListDiscount.ShowDiscountProducts();

            //UCProductListSpray.LoadProducts(4, "", 22, 1, 1);
            //UCProductListGel.LoadProducts(4, "", 23, 1, 1);
            //UCProductListDevice.LoadProducts(4, "", 26, 1, 1);


            BOLProducts ProductsBOL = new BOLProducts();
            Products SpecialPro = ProductsBOL.GetSpecialPro();
            if(SpecialPro != null)
            {
                hplSepcialPro.NavigateUrl = Page.ResolveUrl("~/Products/ShowProduct.aspx?Code=" + SpecialPro.Code);
                imgSpecialPro.ImageUrl = "~/" + SpecialPro.SmallPicFile;
                hplSpecialProTitle.Text = SpecialPro.Title;
                hplSpecialProTitle.NavigateUrl = Page.ResolveUrl("~/Products/ShowProduct.aspx?Code=" + SpecialPro.Code);
                lblSpecialProDesc.Text = Tools.ShowBriefText(SpecialPro.Description, 100);
            }
        }
        public string FormatDate(Object obj)
        {
            string Result = "";
            try
            {
                if (obj != null)
                {
                    DateTime CurDT = Convert.ToDateTime(obj);
                    DateTimeMethods dtm = new DateTimeMethods();
                    Result = Tools.ChageEnc(dtm.GetPersianLongDate(CurDT));
                }
                return Result;

            }
            catch
            {
                return "";
            }

        }
        public string ShowPic(object Title, object PicName)
        {
            string Result = "";
            if (PicName != null && PicName != "")
                Result = "<img class=\"cPicXSmall\" alt=\"" + Title + "\" src=\"" + PicName + "\" />";
            return Result;
        }
        private UserControl LoadControl(string UserControlPath, params object[] constructorParameters)
        {
            List<System.Type> constParamTypes = new List<System.Type>();
            foreach (object constParam in constructorParameters)
            {
                constParamTypes.Add(constParam.GetType());
            }

            UserControl ctl = Page.LoadControl(UserControlPath) as UserControl;

            // Find the relevant constructor
            ConstructorInfo constructor = ctl.GetType().BaseType.GetConstructor(constParamTypes.ToArray());

            //And then call the relevant constructor
            if (constructor == null)
            {
                throw new MemberAccessException("The requested constructor was not found on : " + ctl.GetType().BaseType.ToString());
            }
            else
            {
                constructor.Invoke(ctl, constructorParameters);
            }

            // Finally return the fully initialized UC
            return ctl;
        }

    }
}
