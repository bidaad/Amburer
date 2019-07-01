using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConLine.Old_App_Code.DAL;
using System.Data;

namespace ConLine.Admin.Products
{
    public partial class UpdateProList : System.Web.UI.Page
    {
        public string strPageNo;
        int PageNo = 1;
        int _pageSize = 24;
        string ConcatUrl;
        int Counter = 0;
        public DataTable dtCompanies;
        public DataTable dtHCProductAvailabilities;

        protected void Page_Load(object sender, EventArgs e)
        {
            dtCompanies = new BOLHardCode().GetHCDataTable("HCCompanies");
            dtHCProductAvailabilities = new BOLHardCode().GetHCDataTable("HCProductAvailabilities");
            if (!Page.IsPostBack)
            {
                string strCatCode = Request["CatCode"];
                int CatCode;
                Int32.TryParse(strCatCode, out CatCode);

                IQueryable<vProducts> ItemList;
                int ResultCount = 0;
                strPageNo = Request["PageNo"];
                if (strPageNo != "" && strPageNo != null)
                    PageNo = Convert.ToInt32(strPageNo);
                BOLProducts ProductsBOL = new BOLProducts();


                ItemList = ProductsBOL.GetProducts(CatCode, _pageSize, PageNo, false);
                ResultCount = ProductsBOL.GetProductsCount(CatCode, false);


                rptProducts.DataSource = ItemList;
                rptProducts.DataBind();

                int PageCount = ResultCount / _pageSize;
                if (ResultCount % _pageSize > 0)
                    PageCount++;

                ConcatUrl += "&CatCode=" + Request["CatCode"];
                pgrToolbar.PageNo = PageNo;
                pgrToolbar.PageCount = PageCount;
                pgrToolbar.ConcatUrl = ConcatUrl;
                pgrToolbar.PageBind();
            }

        }

        public string FormatText(Object obj)
        {
            if (obj == null)
                return "";
            ReqUtils rUtil = new ReqUtils();
            return rUtil.RemoveTags(obj.ToString());

        }
        public string ShowPic(object Title, object PicName)
        {
            string Result = "";
            ReqUtils rUtil = new ReqUtils();
            Title = rUtil.RemoveTags(Title.ToString());
            if (PicName != null && PicName != "")
                Result = "<img class=\"cPic2\" alt=\"" + Title + "\" src=\"" + ((Page)HttpContext.Current.Handler).ResolveUrl("~/" + PicName) + "\" />";
            return Result;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int? CatCode = treProductCatCode.Code;
            Response.Redirect("~/Admin/Products/UpdateProList.aspx?CatCode=" + CatCode.ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (treProductCatCode.Code != null)
            //{
            int? SelectedCatCode = null;
                
                if(treProductCatCode.Code != null)
                    SelectedCatCode = (int)treProductCatCode.Code;
                BOLProducts ProductsBOL = new BOLProducts();
                for (int i = 0; i < rptProducts.Items.Count; i++)
                {
                    CheckBox chkProduct = (CheckBox)rptProducts.Items[i].FindControl("chkProduct");
                    DropDownList cboCompanyCode = (DropDownList)rptProducts.Items[i].FindControl("cboCompanyCode");
                    DropDownList cboHCProductAvailabilitCode = (DropDownList)rptProducts.Items[i].FindControl("cboHCProductAvailabilitCode");
                    TextBox txtPrice = (TextBox)rptProducts.Items[i].FindControl("txtPrice");
                    TextBox txtWeight = (TextBox)rptProducts.Items[i].FindControl("txtWeight");
                    AKP.Web.Controls.LookupTree ProCatCode = (AKP.Web.Controls.LookupTree)rptProducts.Items[i].FindControl("ProCatCode");
                    int? ProductCatCode = ProCatCode.Code;
                    if (chkProduct.Checked)
                    {
                        int ProductCode = Convert.ToInt32(chkProduct.Attributes["Code"]);
                        ProductsBOL.UpdateProduct(ProductCode, SelectedCatCode, Convert.ToInt32(cboCompanyCode.SelectedValue), txtPrice.Text, txtWeight.Text, Convert.ToInt32(cboHCProductAvailabilitCode.SelectedValue), ProductCatCode);
                        chkProduct.Checked = false;
                    }

                }
                msgMessage.Text = "تغییرات اعمال شد.";
            //}
        }

        protected void rptProducts_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DropDownList cboCompanyCode = (DropDownList)e.Item.FindControl("cboCompanyCode");
            DropDownList cboHCProductAvailabilitCode = (DropDownList)e.Item.FindControl("cboHCProductAvailabilitCode");

            string CurCompCode =cboCompanyCode.Attributes["Code"];
            string CurAvailCode = cboHCProductAvailabilitCode.Attributes["Code"];

            cboCompanyCode.DataTextField = "Name";
            cboCompanyCode.DataValueField = "Code";
            cboCompanyCode.DataSource = dtCompanies;
            cboCompanyCode.DataBind();


            cboHCProductAvailabilitCode.DataTextField = "Name";
            cboHCProductAvailabilitCode.DataValueField = "Code";
            cboHCProductAvailabilitCode.DataSource = dtHCProductAvailabilities;
            cboHCProductAvailabilitCode.DataBind();

            if(!string.IsNullOrEmpty(CurCompCode))
                cboCompanyCode.SelectedValue = CurCompCode;
            if (!string.IsNullOrEmpty(CurAvailCode))
                cboHCProductAvailabilitCode.SelectedValue = CurAvailCode;
        }

    }
}