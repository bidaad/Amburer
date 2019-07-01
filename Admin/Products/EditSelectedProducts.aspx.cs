using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Amburer.Old_App_Code.DAL;


public partial class SelectedProducts_EditSelectedProducts : EditForm<SelectedProducts>
{
    private string BaseID = "SelectedProducts";
    IBaseBOL<SelectedProducts> BaseBOL;



    protected void Page_Load(object sender, EventArgs e)
    {
        #region Tab Pages
        //if (!NewMode)
        //     ShowDetails();
        //else
        //{
        //     RadMultiPage1.SelectedIndex = 0;
        //     tsSelectedProducts.Tabs[0].Selected = true;
        //}
        #endregion
        BOLClass = new BOLSelectedProducts();
        lblSysName.Text = BOLClass.PageLable;

        if ((Code == null) && (!NewMode)) return;
        if (!Page.IsPostBack)
        {
            //if (!NewMode) ShowDetails();


            #region Fill Combo
            cboHCSelectTypeCode.DataSource = new BOLHardCode().GetHCDataTable("HCSelectTypes");

            #endregion
            if (!NewMode)
            {
                LoadData((int)Code);
            }
        }


    }

    protected void DoSave(object sender, EventArgs e)
    {
        try
        {
            int ReturnCode = SaveControls("~/Main/Default.aspx?BaseID=" + BaseID);
            if (NewMode && ReturnCode != -1)
            {
                NewMode = false;
                Code = ReturnCode;
            }
        }
        catch
        {
        }
    }
    
}
