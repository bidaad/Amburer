using Amburer.Old_App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amburer.Articles
{
    public partial class ShowArticle : System.Web.UI.Page
    {
        public string ArticleCode;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {


                int Code = 0;
                string strCode = Request["Code"];
                Int32.TryParse(strCode, out Code);
                BOLArticles ArticleBOL = new BOLArticles();
                //Article CurArticle = ((IBaseBOL<Article>)ArticleBOL).GetDetails(Code);
                vArticles CurArticle = ArticleBOL.GetFullInfo(Code);
                if (CurArticle != null)
                {

                    ArticleCode = Code.ToString();
                    ViewState["Code"] = CurArticle.Code;
                    //hplExportTpPDF.NavigateUrl = "~/Export.aspx?Type=PDF&Code=" + CurArticle.Code;
                    Page.Title = lblTitle.Text = CurArticle.Title;


                    DateTimeMethods dtm = new DateTimeMethods();
                    string strDateTime = "";

                    if (!string.IsNullOrEmpty(CurArticle.ADate))
                        strDateTime += Tools.ChageEnc(CurArticle.ADate);

                    lblDate.Text = strDateTime;



                    ltrArticleBody.Text = Tools.FormatText(CurArticle.ArticleContent);

                    hplUrl.Text = CurArticle.Url;
                    hplUrl.NavigateUrl = CurArticle.Url;

                }
            }
        }
    }
}