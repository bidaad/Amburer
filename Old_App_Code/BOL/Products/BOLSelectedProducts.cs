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

public class BOLSelectedProducts : BaseBOLSelectedProducts, IBaseBOL<SelectedProducts>
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

    internal bool CheckExistance(int ProdductCode, int HCSelectTypeCode)
    {
        return dataContext.SelectedProducts.Where(p => p.ProductCode.Equals(ProdductCode) && p.HCSelectTypeCode.Equals(HCSelectTypeCode)).Count() > 0;
    }

    internal void InsertNewRecord(int ProductCode, int HCSelectTypeCode)
    {
        SelectedProducts NewItem = new SelectedProducts();
        dataContext.SelectedProducts.InsertOnSubmit(NewItem);
        NewItem.ProductCode = ProductCode;
        NewItem.HCSelectTypeCode = HCSelectTypeCode;
        dataContext.SubmitChanges();
    }
}
