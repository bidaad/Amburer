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


public partial class Users_EditUsers : EditForm<Users>
{
    private string BaseID = "Users";
    IBaseBOL<Users> BaseBOL;



    protected void Page_Load(object sender, EventArgs e)
    {
        #region Tab Pages
        if (!NewMode)
            ShowDetails();

        #endregion
        BOLClass = new BOLUsers();
        lblSysName.Text = BOLClass.PageLable;

        if ((Code == null) && (!NewMode)) return;
        if (!Page.IsPostBack)
        {
            //if (!NewMode) ShowDetails();


            #region Fill Combo
            cboHCGenderCode.DataSource = new BOLHardCode().GetHCDataTable("HCGenders");

            #endregion
            if (!NewMode)
            {
                Tools.SetClientScript(this, "ActiveTab1", "BrowseObj1.ShowDetail('UserGroups', '" + Code + "',true,'BrowseObj1')");
                LoadData((int)Code);
                BOLUsers UsersBOL = new BOLUsers();
                Users CurUser = ((IBaseBOL<Users>)UsersBOL).GetDetails((int)Code);
                txtPassword.Attributes.Add("value", CurUser.Password);
                hfPassword.Value = CurUser.Password;

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
                ShowDetails();
            }
            if (hfPassword.Value != txtPassword.Text)
            {
                BOLUsers UsersBOL = new BOLUsers();
                UsersBOL.ChangePassword(Code, txtPassword.Text);
                txtPassword.Attributes.Add("value", txtPassword.Text);

            }
        }
        catch
        {
        }
    }
    private void ShowDetails()
    {
        string Tab1Click = "BrowseObj1.ShowDetail('UserGroups', '" + Code
              + "', true,'BrowseObj1');";


        Tab1.Attributes.Add("onclick", Tab1Click);
        Tools.SetClientScript(this, "ActiveTab1", Tab1Click);

        #region HanldeSelectedTab
        if (Request["SelectedTab"] != null)
        {
            RadMultiPage1.SelectedIndex = Int32.Parse(Request["SelectedTab"]);
            SelectedTabIndex = Int32.Parse(Request["SelectedTab"]);
            switch (Int32.Parse(Request["SelectedTab"]))
            {
                case 0:
                    Tools.SetClientScript(Page, "ClickTab", Tab1Click);
                    RadMultiPage1.SelectedIndex = 0;
                    tsUsers.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
            tsUsers.Tabs[Int32.Parse(Request["SelectedTab"])].Selected = true;
        }
        else
        {
            RadMultiPage1.SelectedIndex = 0;
            tsUsers.Tabs[0].Selected = true;
        }
        #endregion
    }
}
