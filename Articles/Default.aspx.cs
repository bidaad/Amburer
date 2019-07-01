using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amburer.Articles
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ConcatUrl = "";
            int PageNo = 1;
            int PageSize = 20;

            string strPageNo = Request["PageNo"];
            if (strPageNo != "" && strPageNo != null)
                PageNo = Convert.ToInt32(strPageNo);

            BOLArticles ArticleBOL = new BOLArticles();
            int PageCount = ArticleBOL.GetNewsCount() / PageSize;

            rptArticles.DataSource = ArticleBOL.GetLatestNews(PageNo, PageSize);
            rptArticles.DataBind();

            pgrToolbar.PageNo = PageNo;
            pgrToolbar.PageCount = PageCount;
            pgrToolbar.ConcatUrl = ConcatUrl;
            pgrToolbar.PageBind();
        }
    }
}