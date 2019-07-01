using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amburer.Old_App_Code.DAL;

namespace Amburer.CustomersFolder
{
    public partial class ShowCustomer : System.Web.UI.Page
    {
        public string strHirarchy = "";
        public string ProTitle = "";
        public string strCode = "";
        public string strEnTitle = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                strCode = Request["Code"];
                int Code;
                Int32.TryParse(strCode, out Code);
                if (Code != 0)
                {
                    ViewState["Code"] = Code;

                    BOLCustomers CustomersBOL = new BOLCustomers();
                    Customers CurCustomer = ((IBaseBOL<Customers>)CustomersBOL).GetDetails(Code);
                    if (CurCustomer != null)
                    {

                        int CatCode = 0;

                        ViewState["Code"] = Code.ToString();



                        lblTitle.Text = CurCustomer.Title;

                        lblDescription.Text = Tools.FormatString(CurCustomer.Description);

                        hplLargePic.NavigateUrl = CurCustomer.LogoFile.Replace("//", "/");
                        imgPicFile.ImageUrl = "~/" + CurCustomer.LogoFile;
                        imgPicFile.ToolTip = CurCustomer.Title;
                        imgPicFile.Attributes.Add("data-zoom-image", Page.ResolveUrl("~/" + CurCustomer.LogoFile));

                        ProTitle = CurCustomer.Title;

                        ReqUtils Utils = new ReqUtils();
                        string FullDesc = CurCustomer.Description;
                        string BriefDesc = Tools.ShowBriefText(Utils.RemoveTags(FullDesc), 300);
                        Tools.SetMeta("description", BriefDesc);
                        Tools.SetMeta("keywords", ProTitle);

                        Tools.SetMeta("ogTitle", ProTitle);
                        Tools.SetMeta("ogImage", "http://www.amburer.com" + CurCustomer.LogoFile.Replace("//", "/"));
                        Tools.SetMeta("ogDescription", BriefDesc);
                        Tools.SetMeta("ogURL", "http://www.amburer.com/Customers/" + CurCustomer.Code + ".htm");

                        Page.Title = ProTitle;

                        BOLCustomerPictures CustomerPicturesBOL = new BOLCustomerPictures(1);
                        rptCustomerPictures.DataSource = CustomerPicturesBOL.GetAllPictures(CurCustomer.Code);
                        rptCustomerPictures.DataBind();

                        if (rptCustomerPictures.Items.Count == 0)
                            pnlProPictures.Visible = false;

                        BOLHardCode HardCodeBOL = new BOLHardCode();

                        //ltrHirarchy.Text = strHirarchy;



                    }

                }



            }

        }
    }
}