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
using ConLine.Old_App_Code.DAL;


public partial class ProductComments_EditProductComments : EditForm<ProductComments>
{
    private string BaseID = "ProductComments";
    IBaseBOL<ProductComments> BaseBOL;



    protected void Page_Load(object sender, EventArgs e)
    {
        #region Tab Pages
        //if (!NewMode)
        //     ShowDetails();
        //else
        //{
        //     RadMultiPage1.SelectedIndex = 0;
        //     tsProductComments.Tabs[0].Selected = true;
        //}
        #endregion
        BOLClass = new BOLProductComments();
        lblSysName.Text = BOLClass.PageLable;

        if ((Code == null) && (!NewMode)) return;
        if (!Page.IsPostBack)
        {
            //if (!NewMode) ShowDetails();


            #region Fill Combo
            cboHCCommentStatusCode.DataSource = new BOLHardCode().GetHCDataTable("HCCommentStatuses");

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
            if (txtEmail.Text != "")
            {
                if (cboHCCommentStatusCode.SelectedValue == "2")
                {
                    EmailTools emailTools = new EmailTools();
                    Tools tools = new Tools();
                    string EmailTemplate = emailTools.LoadTemplate("ProductComment");//Suggest
                    EmailTemplate = EmailTemplate.Replace("[SenderName]", txtName.Text);
                    EmailTemplate = EmailTemplate.Replace("[CommentLink]", "http://www.ConLine.ir/ShowProduct.aspx?Code=" + lkpProductCode.Code);

                    bool SendSellResult = tools.SendEmail(EmailTemplate, " کانلاین :: نظرات کاربران ", "info@ConLine.ir", txtEmail.Text, "admin@ConLine.ir", "");
                    if (SendSellResult)
                        msgBox.Text = "ایمیل به کاربر ارسال شد";
                    else
                        msgBox.Text = "خطا در ارسال ایمیل";
                }
            }
        }
        catch
        {
        }
    }
}
