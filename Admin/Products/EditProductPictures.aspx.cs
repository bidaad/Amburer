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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


public partial class ProductPictures_EditProductPictures : EditFormDetail<ProductPictures>
{

    protected void Page_Load(object sender, EventArgs e)
    {

        BOLClass = new BOLProductPictures((int)MasterCode);

        MasterFieldName="ProductCode";
        Label MasterPageTitle = (Label)Master.FindControl("lblTitle");
        MasterPageTitle.Text = BOLClass.PageLable;

        if (MasterCode == null)
            throw new Exception("No MasterCode Exception");
        if ((Code == null) && (!NewMode)) return;
        if (!Page.IsPostBack)
        {
            ViewState["InstanceName"] = Request["InstanceName"];
            
            if (!NewMode)
                LoadData((int)Code);
        }
    }

    public void SavePic(string FileName, string RandName, string SavePath, int MaxAllowWidth)
    {
        string FirstChar = RandName.Substring(0, 1);
        int StaticVal = MaxAllowWidth;
        int NewWidth;
        int NewHeight;
        Graphics oGraphics;

        System.Drawing.Image image = new Bitmap(HttpContext.Current.Request.MapPath("~/") + FileName);
        if (image.Width > MaxAllowWidth)
        {
            int width = image.Width;
            int height = image.Height;
            NewWidth = StaticVal;
            NewHeight = (StaticVal * height) / width;

            System.Drawing.Image BulkBmp = new Bitmap(NewWidth, NewHeight);
            oGraphics = Graphics.FromImage(BulkBmp);

            oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            oGraphics.DrawImage(
                image,
                new Rectangle(0, 0, NewWidth, NewHeight),
                // destination rectangle 
                0,
                0,           // upper-left corner of source rectangle
                width,       // width of source rectangle
                height,      // height of source rectangle
                GraphicsUnit.Pixel);

            BulkBmp.Save(SavePath + "\\" + RandName, ImageFormat.Jpeg);
            oGraphics.Dispose();
        }
        else
            File.Copy(HttpContext.Current.Request.MapPath("~/Files/Products/") + FileName, HttpContext.Current.Request.MapPath("~/Files/Products/Small/") + RandName);

    }


    protected void DoSave(object sender, EventArgs e)
    {
        try
        {
            int ReturnCode = SaveControls("~/Main/Default.aspx?BaseID=" + BaseID);
            if (ReturnCode != -1)
            {
                ProductPictures CurProductPicture;
                BOLProductPictures ProductPicturesBOL = new BOLProductPictures(1);

                CurProductPicture = ((IBaseBOL<ProductPictures>)ProductPicturesBOL).GetDetails(ReturnCode);
                if (uplPicFile.UploadedFiles.Count > 0 || string.IsNullOrEmpty(CurProductPicture.SmallPicFile))
                {
                    Guid newGd = Guid.NewGuid();
                    string RandSmallPic = newGd.ToString().Replace("-", "") + ".jpg";

                    SavePic(CurProductPicture.PicFile, RandSmallPic, HttpContext.Current.Request.MapPath("~/Files/Products/Small/"), 70);
                    ProductPicturesBOL.ChangeSmallPic(ReturnCode, "/Files/Products/Small/" + RandSmallPic);
                }


                Tools.CloseWin(Page, Master, BaseID, ViewState["InstanceName"].ToString());
            }
        }
        catch
        {
        }
    }
}
