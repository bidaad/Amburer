using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConLine.Admin.Products
{
    public partial class PorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            BOLProducts ProductsBOL = new BOLProducts();
            rptProList.DataSource = ProductsBOL.GetProductsByViewNum(dteFromDate.SelectedDateChristian, dteToDate.SelectedDateChristian, 50);
            rptProList.DataBind();

        }
    }
}