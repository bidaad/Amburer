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

public class BOLProductComments : BaseBOLProductComments, IBaseBOL<ProductComments>
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

    internal bool SaveComment(int ProductCode, string Name, string Email, string Comment)
    {
        try
        {
            ProductComments CurComment = new ProductComments();
            dataContext.ProductComments.InsertOnSubmit(CurComment);
            CurComment.ProductCode = ProductCode;
            CurComment.Name = Name;
            CurComment.Email = Email;
            CurComment.Comment = Comment;
            CurComment.HCCommentStatusCode = 1;
            CurComment.CommentDate = DateTime.Now;
            dataContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal object GetProductComments(int ProductCode)
    {
        return dataContext.ProductComments.Where(p => p.ProductCode.Equals(ProductCode) && p.HCCommentStatusCode.Equals(2)).OrderByDescending(p => p.Code);
    }

    internal object GetCommentsByUserCode(int UserCode)
    {
        return dataContext.vProductComments.Where(p => p.UserCode.Equals(UserCode));
    }
}
