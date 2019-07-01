using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using Amburer.Old_App_Code.DAL;

public class BOLArticles : BaseBOLArticles, IBaseBOL<Articles>
{
    public IList CheckBusinessRules()
    {
        var messages = new List<string>();

        #region Business Rules
        //Example
        //if (string.IsNullOrEmpty(this.FirstName))
        //    messages.Add("Please fill FirstName.");

        #endregion
        return messages;
    }

    internal int GetNewsCount()
    {
        return dataContext.vArticles.Count();
    }

    internal vArticles GetFullInfo(int Code)
    {
        return dataContext.vArticles.SingleOrDefault(p => p.Code.Equals(Code));
    }

    internal object GetLatestNews(int PageNo, int PageSize)
    {
        int SkipCount = (PageNo - 1) * PageSize;
        return dataContext.vArticles.Skip(SkipCount).Take(PageSize);
    }

    public object GetLatestArticles()
    {
        return dataContext.vArticles.OrderByDescending(p => p.Code);
    }
}
