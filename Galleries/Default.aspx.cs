using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amburer.Galleries
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BOLHardCode HardCodeBOL = new BOLHardCode();
                rptGalleryCats.DataSource = HardCodeBOL.GetHCDataTable("HCGalleryCats");
                rptGalleryCats.DataBind();
            }
            int CatCode = 0;
            int MediaType = 0;

            string strCatCode = Request["CatCode"];
            string strMediaType = Request["MediaType"];
            if (!string.IsNullOrEmpty(strCatCode))
                Int32.TryParse(strCatCode, out CatCode);
            if (!string.IsNullOrEmpty(strMediaType))
                Int32.TryParse(strMediaType, out MediaType);

            BOLGalleries GalleriesBOL = new BOLGalleries();
            if (MediaType == 0 || MediaType == 1)
            {
                rptPicGalleries.DataSource = GalleriesBOL.GetGalleries(1, CatCode);
                rptPicGalleries.DataBind();
            }
            else
                pnlPictures.Visible = false;

            if (MediaType == 0 || MediaType == 2)
            {
                rptMovies.DataSource = GalleriesBOL.GetGalleries(2, CatCode);
                rptMovies.DataBind();
            }
            else
                pnlMovies.Visible = false;

            
        }
    }
}