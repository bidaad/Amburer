using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amburer.UserControls
{
    public partial class MainMenu : System.Web.UI.UserControl
    {
        public MainMenu()
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BOLProducts ProductsBOL = new BOLProducts();
            rptOtherProducts.DataSource = ProductsBOL.GetProducts(27, 18, 1, true);
            rptOtherProducts.DataBind();


        }

        protected void rptWorkGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }


    }
}