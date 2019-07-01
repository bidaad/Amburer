using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amburer.Old_App_Code.DAL;
using System.Data;
using AKP.Web.Controls;

namespace Amburer.ProductsFolder
{
    public partial class ShowProduct : System.Web.UI.Page
    {
        public string strHirarchy = "";
        public string ProTitle = "";
        public string strCode = "";
        public string strEnTitle = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!Page.IsPostBack)
            {

                BOLProductCats BOLClass = new BOLProductCats();
                strCode = Request["Code"];
                int Code;
                Int32.TryParse(strCode, out Code);
                if (Code != 0)
                {
                    ViewState["Code"] = Code;                    

                    BOLProducts ProductsBOL = new BOLProducts();
                    Products CurProduct = ((IBaseBOL<Products>)ProductsBOL).GetDetails(Code);
                    if (CurProduct != null)
                    {
                    
                        int CatCode = 0;
                        
                        ViewState["Code"] = Code.ToString();
                        if (Request.UserAgent == "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)" ||
                            Request.UserAgent == "Mozilla/5.0 (compatible; Yahoo! Slurp; http://help.yahoo.com/help/us/ysearch/slurp)" ||
                            Request.UserAgent == "msnbot/2.0b (+http://search.msn.com/msnbot.htm)._" ||
                            Request.UserAgent == "Mozilla/5.0 (compatible; bingbot/2.0; +http://www.bing.com/bingbot.htm)" ||
                            Request.UserAgent == "Mozilla/5.0 (en-us) AppleWebKit/525.13 (KHTML, like Gecko; Google Web Preview) Version/3.1 Safari/525.13" ||
                            Request.UserAgent == "Mozilla/5.0 (compatible; MJ12bot/v1.3.3; http://www.majestic12.co.uk/bot.php?+)"
                            )
                        {
                            int ff = 1;
                        }
                        else
                        {
                            ProductsBOL.IncProVisits(CurProduct.Code);
                        }


                        lblTitle.Text = CurProduct.Title;

                        lblDescription.Text = Tools.FormatString(CurProduct.Description);
                        lblTechnicalDetails.Text = Tools.FormatString(CurProduct.TechnicalInfo);

                        hplLargePic.NavigateUrl = CurProduct.LargePicFile.Replace("//", "/");
                        imgPicFile.ImageUrl = "~/" + CurProduct.LargePicFile;
                        imgPicFile.ToolTip = CurProduct.Title;
                        imgPicFile.Attributes.Add("data-zoom-image", Page.ResolveUrl( "~/" + CurProduct.LargePicFile));

                        if (CurProduct.HCProductAvailabilityCode == 1)
                        {
                            imgAvailStatus.ImageUrl = "~/images/Available.gif";
                            imgAvailStatus.ToolTip = "موجود";
                        }
                        else
                        {
                            imgAvailStatus.ImageUrl = "~/images/UnAvailable.gif";
                            imgAvailStatus.ToolTip = "ناموجود";
                        }

                        ProTitle = CurProduct.Title;

                        ReqUtils Utils = new ReqUtils();
                        string FullDesc = CurProduct.Description;
                        string BriefDesc = Tools.ShowBriefText(Utils.RemoveTags(FullDesc), 300);
                        Tools.SetMeta("description", BriefDesc);
                        Tools.SetMeta("keywords", ProTitle);

                        Tools.SetMeta("ogTitle", ProTitle);
                        Tools.SetMeta("ogImage", "http://www.amburer.com" + CurProduct.LargePicFile.Replace("//", "/"));
                        Tools.SetMeta("ogDescription", BriefDesc);
                        Tools.SetMeta("ogURL", "http://www.amburer.com/Products/" + CurProduct.Code + ".htm");



                        Page.Title = ProTitle;

                        if (CurProduct.Special != null)
                        {
                            if((bool)CurProduct.Special)
                                imgSpecialOfferLBL.Visible = true;
                        }

                        //if (CurProduct.ProductCatCode != null)
                        //{
                        //    SelectedProducts1.CatCode = (int)CurProduct.ProductCatCode;
                        //    RelatedProducts1.ProductCode = CurProduct.Code;
                        //    RelatedProducts1.ShowSelectedProducts();

                        //}
                        //else
                        //    SelectedProducts1.Visible = false;





                        BOLProductPictures ProductPicturesBOL = new BOLProductPictures(1);
                        rptProductPictures.DataSource = ProductPicturesBOL.GetAllPictures(CurProduct.Code);
                        rptProductPictures.DataBind();

                        if (rptProductPictures.Items.Count == 0)
                            pnlProPictures.Visible = false;

                        BOLHardCode HardCodeBOL = new BOLHardCode();

                        //ltrHirarchy.Text = strHirarchy;



                    }

                }



            }

        }

        private void GetHirarchy(int? CatCode)
        {
            if (CatCode != null)
            {
                BOLProductCats ProductCatsBOL = new BOLProductCats();
                ProductCats CurCat = ProductCatsBOL.GetCatInfo((int)CatCode);
                strHirarchy = @"<li class=""Sep"">&nbsp; </li><li><span><a href=" + Page.ResolveUrl("~/Products/?C=" + CurCat.Code) + ">" + CurCat.Name + "</a></span></li>" + strHirarchy;
                GetHirarchy(CurCat.MasterCode);
            }
        }
        public string ShowItem(Object obj)
        {
            string Result = "";
            try
            {
                if (obj != null)
                {
                    Result = Convert.ToString(obj);
                    if (Result.Trim() == "")
                        Result = "نامشخص";
                }
                return Result;
            }
            catch
            {
                return "";
            }
        }
        public string ShowDate(Object obj)
        {
            string Result = "";
            try
            {
                if (obj != null)
                {
                    DateTime dtCommentDate = Convert.ToDateTime(obj);
                    DateTimeMethods dtm = new DateTimeMethods();
                    Result = dtm.GetPersianDate(dtCommentDate);
                    Result = Tools.ChangeEnc(Result);
                }
                return Result;
            }
            catch
            {
                return "";
            }
        }
       

        public string FormatText(Object obj)
        {
            if (obj == null)
                return "";
            ReqUtils rUtil = new ReqUtils();
            return Tools.ShowBriefText(rUtil.RemoveTags(obj.ToString()), 15);

        }

        public string FormatText2(Object obj, int CharCount)
        {
            if (obj == null)
                return "";
            ReqUtils rUtil = new ReqUtils();
            return Tools.ShowBriefText(rUtil.RemoveTags(obj.ToString()), CharCount);

        }

        public string ShowPic(object Title, object PicName)
        {
            string Result = "";
            if (PicName != null && PicName != "")
                Result = "<img class=\"cPic3\" alt=\"" + Title + "" + Title + "\" src=\"" + ((Page)HttpContext.Current.Handler).ResolveUrl("~/" + PicName) + "\" />";
            return Result;
        }

        public string ShowNum(Object obj)
        {
            string Result = "";
            if (obj != null)
            {
                int intCount = Convert.ToInt32(obj);
                if (intCount != 0)
                    Result = "(" + Tools.ChangeEnc(intCount.ToString()) + ")";
            }
            return Result;
        }

        protected void btnCatalogue_Click(object sender, EventArgs e)
        {
            if(ViewState["Code"] != null)
            {
                int Code = Convert.ToInt32(ViewState["Code"]);
                BOLProducts ProductsBOL = new BOLProducts();
                Products CurProduct = ProductsBOL.GetDetails(Code);
                if (CurProduct != null)
                    Response.Redirect("~" + CurProduct.CatalogFile);
                else
                {
                    msgBox.MessageTextMode = AKP.Web.Controls.Common.MessageMode.Error;
                    msgBox.Text = "فایل کاتالوگ موجود نیست";
                }
            }
        }
    }
}