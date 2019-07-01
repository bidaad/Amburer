using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amburer.Old_App_Code.DAL;
using System.Data;
using AKP.Web.Controls;

public partial class UserControls_ProductList : System.Web.UI.UserControl
{
    public string RefID = "";
    public string strPageNo;
    int PageNo = 1;
    int _pageSize = 20;
    public int PageSize
    {
        set
        {
            _pageSize = value;
        }
    }
    string ConcatUrl;
    int Counter = 0;
    int ClassCounter = 0;
    int Turn = 0;

    protected int? _catCode = null;
    public int? CatCode
    {
        get
        {
            return _catCode;
        }
        set
        {
            _catCode = value;
        }
    }

    protected string _keyword = null;
    public string Keyword
    {
        get
        {
            return _keyword;
        }
        set
        {
            _keyword = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["dtOrders"] == null)
        //    btnCheckout.Visible = false;
        //else
        //{
        //    if( ((DataTable)Session["dtOrders"]).Rows.Count == 0)
        //        btnCheckout.Visible = false;
        //}
        //try
        //{

        //}
        //catch(Exception exp)
        //{
        //    BOLErrorLogs ErrorLogsBOL = new BOLErrorLogs();
        //    ErrorLogsBOL.Insert(exp.Message, DateTime.Now, Request.Url.AbsolutePath, Request.QueryString.ToString());
        //}
    }

    public void ShowAllProducts()
    {
        string strRefUserID = Request["Ref"];
        if (!string.IsNullOrEmpty(strRefUserID))
            RefID = strRefUserID;
        else if (Session["UserID"] != null)
            RefID = Session["UserID"].ToString();


        IQueryable<vProducts> ItemList;
        int ResultCount = 0;
        strPageNo = Request["PageNo"];
        if (strPageNo != "" && strPageNo != null)
            PageNo = Convert.ToInt32(strPageNo);
        BOLProducts ProductsBOL = new BOLProducts();

        if (_keyword == null)
        {
            ItemList = ProductsBOL.GetProducts(_catCode, _pageSize, PageNo, true);
            ResultCount = ProductsBOL.GetProductsCount(_catCode,true);
            if (_catCode != null)
            {
                BOLProductCats ProductCatsBOL = new BOLProductCats();
                ProductCats CurCat = ProductCatsBOL.GetSingleCat((int)_catCode);
                if (CurCat != null)
                {
                    lblListHeader.Text = "محصولات گروه " + CurCat.Name;
                    Page.Title = "محصولات گروه " + CurCat.Name;
                }
            }
        }
        else
        {
            ItemList = ProductsBOL.SearchProducts(_keyword, _pageSize, PageNo);
            ResultCount = ProductsBOL.SearchProductsCount(_keyword);
            lblListHeader.Text = "نتایج جستجو برای \"" + Keyword + "\"";
        }
        rptProducts.DataSource = ItemList;
        rptProducts.DataBind();

        int PageCount = ResultCount / _pageSize;
        if (ResultCount % _pageSize > 0)
            PageCount++;

        ConcatUrl += "&CatCode=" + Request["CatCode"] + "&Keyword=" + Keyword;
        pgrToolbar.PageNo = PageNo;
        pgrToolbar.PageCount = PageCount;
        pgrToolbar.ConcatUrl = ConcatUrl;
        pgrToolbar.PageBind();
    }
    public void ShowProductsBySelTypeCode(int HCSelectTypeCode)
    {
        IQueryable<vProducts> ItemList;
        strPageNo = Request["PageNo"];
        if (strPageNo != "" && strPageNo != null)
            PageNo = Convert.ToInt32(strPageNo);
        BOLProducts ProductsBOL = new BOLProducts();

        switch (HCSelectTypeCode)
        {
            case 1:
                lblListHeader.Text = "جدیدترین محصولات";
                break;
            case 2:
                lblListHeader.Text = "پر فروش ترین محصولات";
                break;
            case 3:
                lblListHeader.Text = "پر بازدید ترین محصولات";
                break;

            default:
                break;
        }
        rptProducts.DataSource = ProductsBOL.GetRandSelectedProducts(HCSelectTypeCode, _pageSize, PageNo);
        rptProducts.DataBind();

    }

    public string FormatText(Object obj)
    {
        if (obj == null)
            return "";
        ReqUtils rUtil = new ReqUtils();
        return Tools.ShowBriefText( rUtil.RemoveTags(obj.ToString()),15);

    }

    public string ShowPropStart()
    {
        string Result = "";
        string CurrentClass = GetCurrentClass();
        if ((Counter % 4) == 0 && Turn == 0)
        {
            Result = "<tr class=\"" + CurrentClass + "\"><td>";
        }
        else
        {
            Result = "<td>";
        }
        return Result;
    }
    public string ShowPropEnd()
    {
        string Result = "";
        if ((Counter % 4) == 0 && Turn == 1)
        {
            Result = "</td></tr>";
            ClassCounter++;
            if (ClassCounter == 4)
                ClassCounter = 0;
            Turn = 0;
        }
        else
        {
            Result = "</td>";
            Turn = 1;
        }
        Counter++;
        return Result;
    }
    public string GetCurrentClass()
    {
        string Result = "";
        switch (ClassCounter%4)
        {
            case 0:
                Result = "PurpleWin";
                break;
            case 1:
                Result = "BlueWin";
                break;
            case 2:
                Result = "Red1Win";
                break;
            case 3:
                Result = "Red2Win";
                break;
            default:
                Result = "PurpleWin";
                break;
        }

        return Result;
    }

    public string ShowPic(object Title, object PicName)
    {
        string Result = "";
        ReqUtils rUtil = new ReqUtils();
        Title =  rUtil.RemoveTags(Title.ToString());
        if (PicName != null && PicName != "")
            Result = "<img class=\"cPic2\" alt=\"" + Title + "\" src=\"" + ((Page)HttpContext.Current.Handler).ResolveUrl("~/" + PicName) + "\" />";
        return Result;
    }


   
    
    protected int? ProductInBasketItemCount(int ProductCode)
    {
        DataTable dt = (DataTable)Session["dtOrders"];
        if (dt == null)
            dt = new DataTable();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int CurProCode = Convert.ToInt32(dt.Rows[i]["ProductCode"]);
            if (CurProCode == ProductCode)
                return Convert.ToInt32( dt.Rows[i]["ItemCount"]);
        }
        return null;
    }
   



}
