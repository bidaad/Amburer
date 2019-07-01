using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amburer.CustomersFolder
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BOLCustomers CustomersBOL = new BOLCustomers();
            rptCustomers.DataSource = CustomersBOL.GetAll();
            rptCustomers.DataBind();
        }
    }
}