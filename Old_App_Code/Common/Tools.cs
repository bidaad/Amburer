﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Web.SessionState;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Amburer.Old_App_Code.DAL;
using System.IO;
using DataAccess;


public class Tools
{
    public List<AccessListStruct> AccessList;
    public Tools()
    {
    }
    public static string FormatText(object obj)
    {
        string Result = "";
        if (obj != null)
        {
            Result = obj.ToString();
            Result = Result.Replace("\n", "<br>");
        }
        return Result;

    }

    public DataTable GetDataTable(string SqlStr)
    {
        string cnStr = ConfigurationManager.ConnectionStrings["AmburerConnectionString"].ConnectionString;
        SQLServer dal = new SQLServer(cnStr);
        DataSet ds = dal.runSQLDataSet(SqlStr, "dt");
        return ds.Tables[0];

    }

    public static DateTime GetIranDate()
    {
        DateTime ServerDate = DateTime.Now;
        string TimeDiff = ConfigurationManager.AppSettings["TimeDiff"];
        string[] TimeDiffArray = TimeDiff.Split(':');
        int HourDiff = Convert.ToInt32(TimeDiffArray[0]);
        int MinDiff = Convert.ToInt32(TimeDiffArray[1]);

        return ServerDate.AddHours(HourDiff).AddMinutes(MinDiff);
    }
    public static string HLText(object obj, string Keyword)
    {
        string Result = "";
        if (obj != null)
        {
            Result = obj.ToString();
            if (Keyword != null)
            {
                string[] KeywordArray = Keyword.Split(' ');
                for (int i = 0; i < KeywordArray.Length; i++)
                {
                    Result = Result.Replace(KeywordArray[i], "<b>" + KeywordArray[i] + "</b>");
                }
            }
        }
        return Result;


    }

    public static string ConrrectUrl(Object objstr)
    {
        if (objstr == null)
            return "";
        string str = objstr.ToString();
        str = str.Replace("&nbsp;", "");
        str = str.Replace("&", "");
        str = str.Replace(";", "");

        str = str.Replace("\"", "");
        str = str.Replace("?", "");
        str = str.Replace("؛", "");
        str = str.Replace(":", "");
        str = str.Replace(".", "");
        str = str.Replace("-", "");

        string Result = str;
        Result = Result.Replace(" ", "_") + "-";
        return Result;
    }
    public static bool GetValue(bool? Val)
    {
        if (Val == null)
            return false;
        else
        {
            return (bool)Val;
        }
    }

    public static string GetPrettyDate(DateTime d)
    {
        // 1.
        // Get time span elapsed since the date.
        TimeSpan s = DateTime.Now.Subtract(d);

        // 2.
        // Get total number of days elapsed.
        int dayDiff = (int)s.TotalDays;

        // 3.
        // Get total number of seconds elapsed.
        int secDiff = (int)s.TotalSeconds;

        // 4.
        // Don't allow out of range values.
        if (dayDiff < 0 || dayDiff >= 31)
        {
            return null;
        }

        // 5.
        // Handle same-day times.
        if (dayDiff == 0)
        {
            // A.
            // Less than one minute ago.
            if (secDiff < 60)
            {
                return "just now";
            }
            // B.
            // Less than 2 minutes ago.
            if (secDiff < 120)
            {
                return "1 minute ago";
            }
            // C.
            // Less than one hour ago.
            if (secDiff < 3600)
            {
                return string.Format("{0} minutes ago",
                    Math.Floor((double)secDiff / 60));
            }
            // D.
            // Less than 2 hours ago.
            if (secDiff < 7200)
            {
                return "1 hour ago";
            }
            // E.
            // Less than one day ago.
            if (secDiff < 86400)
            {
                return string.Format("{0} hours ago",
                    Math.Floor((double)secDiff / 3600));
            }
        }
        // 6.
        // Handle previous days.
        if (dayDiff == 1)
        {
            return "yesterday";
        }
        if (dayDiff < 7)
        {
            return string.Format("{0} days ago",
                dayDiff);
        }
        if (dayDiff < 31)
        {
            return string.Format("{0} weeks ago",
                Math.Ceiling((double)dayDiff / 7));
        }
        return null;
    }
    public static string ChageEnc(string str)
    {
        string Result = "";
        string CurChar = "";
        for (int i = 0; i < str.Length; i++)
        {
            CurChar = str.Substring(i, 1);
            switch (CurChar)
            {
                case "0":
                    Result += "۰";
                    break;
                case "1":
                    Result += "۱";
                    break;
                case "2":
                    Result += "۲";
                    break;
                case "3":
                    Result += "۳";
                    break;
                case "4":
                    Result += "۴";
                    break;
                case "5":
                    Result += "۵";
                    break;
                case "6":
                    Result += "۶";
                    break;
                case "7":
                    Result += "۷";
                    break;
                case "8":
                    Result += "۸";
                    break;
                case "9":
                    Result += "۹";
                    break;
                default:
                    Result += CurChar;
                    break;
            }

        }
        return Result;
    }

    public static void CheckUserAccess()
    {
        if (HttpContext.Current.Session["UserCode"] == null)
            HttpContext.Current.Response.Redirect("~/Users/Login.aspx", true);
    }
    public static string ConvertToUnicode(object obj)
    {
        string Result = "";
        if (obj != null)
        {
            Result = obj.ToString();
            Result = Result.Replace("1", "١");
            Result = Result.Replace("2", "٢");
            Result = Result.Replace("3", "٣");
            Result = Result.Replace("4", "٤");
            Result = Result.Replace("5", "٥");
            Result = Result.Replace("6", "٦");
            Result = Result.Replace("7", "٧");
            Result = Result.Replace("8", "٨");
            Result = Result.Replace("9", "٩");
            Result = Result.Replace("0", "٠");
        }
        return Result;
    }
    public static string ShowIcon(string str)
    {
        string Ext = Tools.GetExtension(str);
        switch (Ext)
        {
            case "DOC":
                return "doc.gif";
                break;
            case "PDF":
                return "pdf.gif";
                break;
            case "TXT":
                return "txt.gif";
                break;

            default:
                return "txt.gif";
                break;
        }
        return "";
    }
    public static string GetExtension(string str)
    {
        string Extesion = "";
        if (str.Length > 3)
        {
            Extesion = str.Substring(str.Length - 3, 3).ToUpper();
        }
        return Extesion;
    }
    public static void SetMeta(string MetaID, string MetaVal)
    {
        HtmlMeta metadesc = (HtmlMeta)((Page)(HttpContext.Current.Handler)).Master.FindControl(MetaID);
        metadesc.Attributes["content"] = MetaVal;
        metadesc.Attributes.Remove("id");
    }
    public string RemoveTags(string InputHtml)
    {
        string InnerContent = InputHtml;
        int CutLen = 0;
        int StartIndex = 0;
        int EndIndex = 0;
        string TagContent = "";
        InnerContent = InnerContent.Replace("<SCRIPT", "<script");
        InnerContent = InnerContent.Replace("</SCRIPT", "</script");

        StartIndex = InnerContent.IndexOf("<script", 0);
        while (StartIndex > 0)
        {
            EndIndex = InnerContent.IndexOf("</script>", StartIndex + 7);
            if (EndIndex > 0)
            {
                CutLen = EndIndex - StartIndex + 9;
                TagContent = InnerContent.Substring(StartIndex, CutLen);
                InnerContent = InnerContent.Replace(TagContent, "");
                StartIndex = StartIndex - TagContent.Length;
            }
            else
                break;

            StartIndex = InnerContent.IndexOf("<script", 0);
        }





        InnerContent = InnerContent.Replace("<IFRAME", "<iframe");
        InnerContent = InnerContent.Replace("</IFRAME", "</iframe");

        StartIndex = InnerContent.IndexOf("<iframe", 0);
        while (StartIndex > 0)
        {
            EndIndex = InnerContent.IndexOf("</iframe>", StartIndex + 7);
            if (EndIndex > 0)
            {
                CutLen = EndIndex - StartIndex + 9;
                TagContent = InnerContent.Substring(StartIndex, CutLen);
                InnerContent = InnerContent.Replace(TagContent, "");
                StartIndex = StartIndex - TagContent.Length;
            }
            StartIndex = InnerContent.IndexOf("<iframe", 0);
        }




        StartIndex = InnerContent.IndexOf("<", 0);
        while (StartIndex >= 0)
        {
            EndIndex = InnerContent.IndexOf(">", StartIndex + 1);
            if (EndIndex > 0)
            {
                CutLen = EndIndex - StartIndex - 1;
                TagContent = InnerContent.Substring(StartIndex + 1, CutLen);
                InnerContent = InnerContent.Replace("<" + TagContent + ">", "");
                StartIndex = StartIndex - TagContent.Length;
            }
            else
                break;
            StartIndex = InnerContent.IndexOf("<", 0);
        }


        return InnerContent;

    }
    public string GetRandString(int StrLen)
    {
        string Result = "";
        double RndIndex;
        string[] Alphabets = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9" ,
                               "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9" , 
                               "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        RandomProportional randObj = new RandomProportional();

        Random rnd;
        for (int i = 0; i < StrLen; i++)
        {
            rnd = new Random(Alphabets.Length);

            int rndIndex = (int)(randObj.NextDouble() * 100);
            Result = Result + Alphabets[rndIndex];
        }
        return Result;
    }
    public static string ShowPic(Object obj, string DefaultPic, string PicPath)
    {
        string Result = "";
        if (obj != null)
        {
            Result = ((Page)HttpContext.Current.Handler).ResolveUrl(PicPath + obj.ToString());
        }
        else
        {
            if (DefaultPic == null)
                Result = ((Page)HttpContext.Current.Handler).ResolveUrl(PicPath + "man_icon.png");
            else
                Result = ((Page)HttpContext.Current.Handler).ResolveUrl("~/" + DefaultPic);
        }
        return Result;
    }

    public bool SendEmail(string Body, string Subject, string FromEmail, string ToEmail, string BCC, string CC)
    {
        try
        {
            System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
            message.From = FromEmail;
            message.To = ToEmail;
            message.Bcc = BCC;
            message.Cc = CC;
            message.Subject = Subject;
            message.Body = Body;
            message.BodyFormat = System.Web.Mail.MailFormat.Html;
            message.BodyEncoding = new UTF8Encoding();
            System.Web.Mail.SmtpMail.SmtpServer = "46.4.104.67";

            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "info@Amburer.com");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "123Amburer123");
            System.Web.Mail.SmtpMail.Send(message);
            return true;
        }
        catch
        {
            return false;
        }

        //try
        //{
        //    SmtpClient client = new SmtpClient("mail.SDB.com", 25);

        //    client.Credentials = new NetworkCredential("info@SDB.com", "ali1357");
        //    client.EnableSsl = true;
        //    //client.Port = 465;

        //    using (MailMessage msg = new MailMessage())
        //    {
        //        msg.From = new MailAddress(FromEmail);
        //        msg.Subject = Subject;
        //        msg.Body = Body;

        //        msg.To.Add(new MailAddress(ToEmail));
        //        client.Send(msg);
        //    }
        //    return true;
        //}
        //catch(Exception errsend)
        //{
        //    return false;
        //}

    }
    

    public List<AccessListStruct> GetAccessList(string BaseID)
    {
        AccessList = new List<AccessListStruct>();
        AccessList.Clear();
        int UserCode;
        if (HttpContext.Current.Session["UserCode"] != null)
        {
            UserCode = Convert.ToInt32(HttpContext.Current.Session["UserCode"]);
            var UserAccess = new BOLUsers().GetUserAccessByBaseID(UserCode, BaseID);
            CreateAccess("New", 1, UserAccess, BaseID);
            CreateAccess("Edit", 2, UserAccess, BaseID);
            //            CreateAccess("Delete", 4, UserAccess, BaseID);
            CreateAccess("View", 8, UserAccess, BaseID);
            //            CreateAccess("Export", 16, UserAccess, BaseID);
        }
        return AccessList;
    }
    private void CreateAccess(string AccessName, int AccessCode, System.Linq.IQueryable<Amburer.Old_App_Code.DAL.vUserAccess> UserAccess, string BaseID)
    {
        foreach (Amburer.Old_App_Code.DAL.vUserAccess CurAccess in UserAccess)
        {
            if ((CurAccess.AccessType & AccessCode) == AccessCode)
            {
                if (CurAccess.ResName.Split('.')[0] == BaseID || BaseID == null)
                    AccessList.Add(new AccessListStruct(AccessName.ToUpper(), CurAccess.ResName.ToUpper()));
            }
        }

    }

    

    public static string ShowBriefText(Object obj, int CutLen)
    {
        string Result = "";
        string str = "";
        if (obj != null)
            str = obj.ToString();
        else
            return "";
        if (str.Length >= CutLen)
        {
            int CutPos = str.IndexOf(" ", CutLen);
            if (CutPos > 0)
                Result = str.Substring(0, CutPos) + "...";
            else
                Result = str;
        }
        else
            Result = str;

        return Result;
    }

    
    public static IBaseBOL GetBOLClass(string BaseID, params int[] MasterCodes)
    {

        if (IsHardCode(BaseID))
        {
            //UNDONE: return new BOLHardCode();
            return new BOLHardCode();
        }
        else
        {
            //switch (BaseID)
            Type t = System.Web.Compilation.BuildManager.GetType("BOL" + BaseID, true);

            if (t == null)
                throw new Exception("Invalid BaseID.");

            ConstructorInfo[] cArr = t.GetConstructors();
            if ((cArr.Length > 0) && (cArr[0].GetParameters().Length > 0))
            {
                object[] oArr = { MasterCodes };
                return (IBaseBOL)Activator.CreateInstance(t, oArr);
            }
            else
                return (IBaseBOL)Activator.CreateInstance(t);

        }

    }

    public static IBaseBOLTree GetBOLClassTree(string BaseID)
    {

        Type t = System.Web.Compilation.BuildManager.GetType("BOL" + BaseID, true);

        if (t == null)
            throw new Exception("Invalid BaseID.");

        ConstructorInfo[] cArr = t.GetConstructors();
        return (IBaseBOLTree)Activator.CreateInstance(t);

    }

    public static bool IsUserSessionStillValid()
    {
        //bool Result = false;
        //if (HttpContext.Current.Session["New"] != null ||
        //   HttpContext.Current.Session["Edit"] != null ||
        //   HttpContext.Current.Session["Delete"] != null ||
        //   HttpContext.Current.Session["View"] != null ||
        //   HttpContext.Current.Session["Export"] != null)
        //    Result = true;
        //return Result;
        return (HttpContext.Current.Session["UserCode"] != null);
    }
    public static string ConvertToAscii(string Unistr)
    {
        Encoding ascii = Encoding.UTF32;
        Byte[] b = ascii.GetBytes(Unistr);
        return ascii.GetString((b));
    }
    public static string GetHashString(string str)
    {
        return Tools.Encode(str);
    }
    private static bool IsImageExtension(string Extension)
    {
        string[] images = { "JPG", "GIF", "JPEG", "BMP", "PNG" };
        return images.Contains(Extension);
    }
    private static string GetFileExtension(string FileName)
    {
        int DotIndex = FileName.LastIndexOf(".");
        if (DotIndex > -1)
            return FileName.Substring(DotIndex + 1, FileName.Length - DotIndex - 1).ToUpper();
        else
            return "";
    }
    public static string GetRandomFileName(string FileName)
    {
        Guid newGd = Guid.NewGuid();
        string Extenstion = GetFileExtension(FileName);
        return newGd.ToString().Replace("-", "") + "." + Extenstion;
    }
    public static bool IsHardCode(string BaseID)
    {
        return BaseID.Substring(0, 2) == "HC";
    }
    public static void CloseWin(Page page, System.Web.UI.MasterPage MP, string BaseID, string InstanceName)
    {
        HtmlGenericControl CloseScript = new HtmlGenericControl("script");
        CloseScript.Attributes.Add("type", "text/javascript");
        StringBuilder strClose = new StringBuilder();
        if (InstanceName != null)
            strClose.Append("opener." + InstanceName + ".ShowDetail(\"" + BaseID + "\");\n");
        strClose.Append("window.close();");
        //CloseScript.InnerText = strClose.ToString();
        //page.Header.Controls.Add(CloseScript);
        ((Literal)MP.FindControl("ltrHeaderScript")).Text = "<script type=\"text/javascript\">" + strClose.ToString() + "</script>";

        MP.FindControl("cphMain").Visible = false;
    }
    public static string GetCondition(SearchFilterCollection sFilterCols)
    {
        string WhereCond = "";
        if (sFilterCols != null)
        {
            foreach (SearchFilter sf in sFilterCols)
            {
                if (sf.Value != "")
                {
                    string CurrentVal = sf.Value;
                    CurrentVal = CurrentVal.Replace("'", "''");
                    switch (sf.Operator)
                    {
                        case SqlOperators.Equal:
                            WhereCond = sf.ColumnName + " = N''" + CurrentVal + "'' " + sf.CurOperand.ToString() + " " + WhereCond;
                            break;
                        case SqlOperators.Like:
                            WhereCond = sf.ColumnName + " LIKE N''%" + CurrentVal + "%'' " + sf.CurOperand.ToString() + " " + WhereCond;
                            break;
                        case SqlOperators.StartsWith:
                            WhereCond = sf.ColumnName + " LIKE N''" + CurrentVal + "%'' " + sf.CurOperand.ToString() + " " + WhereCond;
                            break;
                        case SqlOperators.EndWith:
                            WhereCond = sf.ColumnName + " LIKE N''%" + CurrentVal + "'' " + sf.CurOperand.ToString() + " " + WhereCond;
                            break;
                        case SqlOperators.GreaterThan:
                            WhereCond = sf.ColumnName + " > " + CurrentVal + " " + sf.CurOperand.ToString() + " " + WhereCond;
                            break;
                        case SqlOperators.GreaterThanOrEqual:
                            WhereCond = sf.ColumnName + " >= " + CurrentVal + " " + sf.CurOperand.ToString() + " " + WhereCond;
                            break;
                        case SqlOperators.LessThan:
                            WhereCond = sf.ColumnName + " < " + CurrentVal + " " + sf.CurOperand.ToString() + " " + WhereCond;
                            break;
                        case SqlOperators.LessThanOrEqual:
                            WhereCond = sf.ColumnName + " <= " + CurrentVal + " " + sf.CurOperand.ToString() + " " + WhereCond;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (WhereCond.Length > 0)
            {
                if (WhereCond.Trim().Substring(WhereCond.Length - 4, 3) == "AND")
                    WhereCond = WhereCond.Substring(0, WhereCond.Length - 4); //Remove AND
                else if (WhereCond.Trim().Substring(WhereCond.Length - 3, 2) == "OR")
                    WhereCond = WhereCond.Substring(0, WhereCond.Length - 3); //Remove OR
            }
        }
        return WhereCond;
    }
    public bool HasAccess(string AccessName, string FieldName)
    {
        //bool Result = false;
        //HttpSessionState Session = HttpContext.Current.Session;

        //if (Session[AccessName] != null)
        //{
        //    string[] AccessArray = Session[AccessName].ToString().Split(',');
        //    for (int i = 0; i < AccessArray.Length; i++)
        //    {
        //        if (AccessArray[i].ToLower() == FieldName.ToLower())
        //        {
        //            Result = true;
        //            break;
        //        }
        //    }
        //}
        //return Result;

        if (AccessList != null)
        {
            if (AccessList.Contains(new AccessListStruct(AccessName.ToUpper(), FieldName.ToUpper())))
                return true;
        }
        return false;

    }
    public static string ChangeEnc(Object obj)
    {
        if (obj == null)
            return "";
        string str = obj.ToString();
        string Result = "";
        string CurChar = "";
        for (int i = 0; i < str.Length; i++)
        {
            CurChar = str.Substring(i, 1);
            switch (CurChar)
            {
                case "0":
                    Result += "۰";
                    break;
                case "1":
                    Result += "۱";
                    break;
                case "2":
                    Result += "۲";
                    break;
                case "3":
                    Result += "۳";
                    break;
                case "4":
                    Result += "۴";
                    break;
                case "5":
                    Result += "۵";
                    break;
                case "6":
                    Result += "۶";
                    break;
                case "7":
                    Result += "۷";
                    break;
                case "8":
                    Result += "۸";
                    break;
                case "9":
                    Result += "۹";
                    break;
                default:
                    Result += CurChar;
                    break;
            }

        }
        return Result;
    }
    public static string UploadPath()
    {
        //String savePath = @"D:\Projects\Mabsa\WebSite\Files\";
        string savePath = AppDomain.CurrentDomain.BaseDirectory + "Files\\";
        return savePath;

    }
    public static string Encode(string MyString)
    {
        string result;
        try
        {

            byte[] IV = new byte[8] { 240, 32, 45, 29, 0, 76, 173, 59 };
            string cryptoKey = "All you need is Love and money";
            byte[] buffer = System.Text.Encoding.ASCII.GetBytes(MyString);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            des.Key = MD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(cryptoKey));
            des.IV = IV;
            byte[] CodedBuffer = des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length);
            result = System.Convert.ToBase64String(CodedBuffer, 0, CodedBuffer.Length);
        }
        catch
        {
            result = null;
        }
        return result;

    }
    public static string Decode(string CodedString64)
    {
        string result;
        try
        {
            byte[] IV = new byte[8] { 240, 32, 45, 29, 0, 76, 173, 59 };
            string cryptoKey = "All you need is Love and money";
            byte[] buffer = Convert.FromBase64String(CodedString64);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            des.Key = MD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(cryptoKey));
            des.IV = IV;
            byte[] CodedBuffer = des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length);
            result = System.Text.Encoding.ASCII.GetString(CodedBuffer);
        }
        catch
        {
            result = "";
        }
        return result;
    }
    public static string FormatShamsiDate(string unfDate)
    {
        string Result = "";
        if (unfDate != null)
        {
            if (unfDate.Length == 8)
                Result = unfDate.Substring(0, 4) + "/" + unfDate.Substring(4, 2) + "/" + unfDate.Substring(unfDate.Length - 2, 2);
            else
                Result = "";
        }
        else
            Result = "";
        return Result;
    }
    public string[] GetHeaderArray(string SqlStr)
    {
        int SelectIndex = 0;
        int FromIndex = 0;
        string ColStr = "";
        string CutFullHedaer = "";
        string[] Result;
        string TempResult = "";
        string MySeperator = "|SEP|";
        char[] charSeparators1 = new char[] { ',' };
        string[] stringSeparators1 = new string[] { "AS" };
        string[] stringSeparators2 = new string[] { MySeperator };

        try
        {
            SelectIndex = SqlStr.ToUpper().IndexOf("SELECT");
            FromIndex = SqlStr.ToUpper().IndexOf("FROM");
            if (FromIndex > SelectIndex)
            {
                ColStr = SqlStr.Substring(SelectIndex + 7, FromIndex - SelectIndex - 7);
                string[] ColStrArray = ColStr.Split(charSeparators1);

                for (int i = 0; i < ColStrArray.Length; i++)
                {
                    CutFullHedaer = ColStrArray[i];
                    if (CutFullHedaer.ToUpper().IndexOf("AS") >= 0)
                    {
                        string[] ColNameAliasArray = CutFullHedaer.Split(stringSeparators1, StringSplitOptions.None);
                        if (i == 0)
                            TempResult = ColNameAliasArray[0].Trim();
                        else
                            TempResult = TempResult + MySeperator + ColNameAliasArray[0].Trim();
                    }
                    else
                    {
                        if (i == 0)
                            TempResult = CutFullHedaer.Trim();
                        else
                            TempResult = TempResult + MySeperator + CutFullHedaer.Trim();
                    }
                }
                Result = TempResult.Split(stringSeparators2, StringSplitOptions.None);

                return Result;
            }
            else
                return null;

        }
        catch
        {
            return null;
        }


    }
    public static string GetXMLData(DataSet dsxml, string FilterKeyword, int FilterClm, int PageNo, string BtnType, int PageSize, int PageCount, int OldOrder, int Order, int Repeat)
    {
        string XMLColumnName = "";
        if (BtnType == "Next" || BtnType == "Back")
        {
            switch (BtnType)
            {
                case "Back":
                    if (PageNo > 1)
                        PageNo = PageNo - 1;
                    else
                        PageNo = 1;
                    break;
                case "Next":
                    if (PageNo < PageCount)
                        PageNo = PageNo + 1;
                    else
                        PageNo = PageCount;
                    break;

                default:
                    PageNo = 1;
                    break;
            }
        }

        int StartRecord = (PageNo - 1) * PageSize;
        int EndRecord = StartRecord + PageSize - 1;
        string strResult = "";

        strResult = "<?xml version='1.0' encoding='utf-8'?><dataroot>";
        DataView dv = new DataView(dsxml.Tables[0]);
        DataTable dt = new DataTable();

        string ColName = "";
        ColName = dv.Table.Columns[Order].ColumnName;
        if (Order == OldOrder && Repeat == 0)
            ColName = ColName + " DESC";
        else
            Repeat = 1;
        dv.Sort = ColName;
        OldOrder = Order;

        dt = dv.ToTable();

        //start data cells
        for (int j = StartRecord; j < EndRecord; j++)
        {
            if (j >= dt.Rows.Count)
                break;
            strResult += "<item>";
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                XMLColumnName = dt.Columns[k].ColumnName;
                XMLColumnName = XMLColumnName.Replace(" ", "_x0020_");
                strResult += "<" + XMLColumnName + ">" + dt.Rows[j][k].ToString() + "</" + XMLColumnName + ">";
            }
            strResult += "</item>";
        }
        //end data cells
        strResult += "</dataroot>";


        return strResult;

    }
    public static string GetListXMLData(DataSet dsxml, CellCollection CellCol, string FilterKeyword, int FilterClm, int PageNo, string BtnType, int PageSize, int PageCount, int OldOrder, int Order, int Repeat)
    {
        string XMLColumnName = "";
        if (BtnType == "Next" || BtnType == "Back")
        {
            switch (BtnType)
            {
                case "Back":
                    if (PageNo > 1)
                        PageNo = PageNo - 1;
                    else
                        PageNo = 1;
                    break;
                case "Next":
                    if (PageNo < PageCount)
                        PageNo = PageNo + 1;
                    else
                        PageNo = PageCount;
                    break;

                default:
                    PageNo = 1;
                    break;
            }
        }

        int StartRecord = (PageNo - 1) * PageSize;
        int EndRecord = StartRecord + PageSize - 1;
        string strResult = "";

        strResult = "<?xml version='1.0' encoding='utf-8'?><dataroot>";
        DataView dv = new DataView(dsxml.Tables[0]);
        DataTable dt = new DataTable();

        string ColName = "";
        ColName = dv.Table.Columns[Order].ColumnName;
        if (Order == OldOrder && Repeat == 0)
            ColName = ColName + " DESC";
        else
            Repeat = 1;
        dv.Sort = ColName;
        OldOrder = Order;

        dt = dv.ToTable();

        //start data cells
        for (int j = StartRecord; j < EndRecord; j++)
        {
            if (j >= dt.Rows.Count)
                break;
            strResult += "<item>";
            foreach (DataCell dc in CellCol)
            {
                XMLColumnName = dc.CaptionName;
                XMLColumnName = XMLColumnName.Replace(" ", "_x0020_");
                strResult += "<" + XMLColumnName + ">" + dt.Rows[j][dc.FieldName].ToString() + "</" + XMLColumnName + ">";
            }

            strResult += "</item>";
        }
        //end data cells
        strResult += "</dataroot>";
        /*
        for (int k = 0; k < dt.Columns.Count; k++)
        {
            XMLColumnName = dt.Columns[k].ColumnName;
            XMLColumnName = XMLColumnName.Replace(" ", "_x0020_");
            strResult += "<" + XMLColumnName + ">" + dt.Rows[j][k].ToString() + "</" + XMLColumnName + ">";
        }
         */

        return strResult;

    }
    private static string GetTableName(string BaseID)
    {
        string Result = "";
        switch (BaseID)
        {
            case "Companies":
                {
                    Result = "PersonCompanies";
                    break;
                }
            default:
                {
                    Result = BaseID;
                    break;
                }
        }
        return Result;
    }
    public static string FormatCurrency(Object objPrice)
    {
        if (objPrice == null)
            return "";
        string Price = objPrice.ToString();
        Price = Price.Replace(" ", "");
        string Result = "";
        if (Price != "")
        {
            //Price = Price.Substring(0, Price.Length - 1);//convert rial to toman
            while (Price.Length > 3)
            {
                if (Result == "")
                    Result = Price.Substring(Price.Length - 3, 3);
                else
                    Result = Price.Substring(Price.Length - 3, 3) + "," + Result;
                Price = Price.Substring(0, Price.Length - 3);
            }
        }
        if (Result != "")
            Result = Price + "," + Result;

        if (Result == "")
            Result = Price;
        return Result;

    }

    public static string FormatCurrency2(Object objPrice)
    {
        string Price = "";
        if (objPrice == null)
            return "";
        else
            Price = objPrice.ToString();
        try
        {
            Price = Price.Replace(" ", "");
            string Result = "";
            if (Price != "")
            {
                //Price = Price.Substring(0, Price.Length - 1);//convert rial to toman
                while (Price.Length > 3)
                {
                    if (Result == "")
                        Result = Price.Substring(Price.Length - 3, 3);
                    else
                        Result = Price.Substring(Price.Length - 3, 3) + "," + Result;
                    Price = Price.Substring(0, Price.Length - 3);
                }
            }
            if (Result != "")
                Result = Price + "," + Result;

            if (Result == "")
                Result = Price;
            Result = ChangeEnc(Result);
            return Result;

        }
        catch
        {
            return "";
        }

    }

    //public static string LogError(HttpRequest Req , Exception exp)
    //{
    //    string Result = "بروز خطای غیر منتظره";
    //    string ErrorMessage = exp.Message;
    //    BOLErrorLog ErrorLogBOL = new BOLErrorLog();
    //    ErrorLogBOL.Insert(exp.Message, DateTime.Now, Req.Url.AbsolutePath, Req.QueryString.ToString());
    //    if (ErrorMessage.IndexOf("DELETE statement conflicted") >= 0)
    //        Result = Messages.ShowMessage(MessagesEnum.ErrorWhileDelete);
    //    else if (ErrorMessage.IndexOf("Cannot insert duplicate key") >= 0)
    //        Result = Messages.ShowMessage(MessagesEnum.ErrorInsertDuplicate);


    //    return Result;

    //}
    public static string GetAppPath()
    {
        return "http://localhost:4300/WebSite";
        //return "http://www.hamshahrimahalleh.net";
    }
    public static string GetListTitle(string BaseID, params int[] CodeArray)
    {
        string Result = "";
        IBaseBOL BOLClass = GetBOLClass(BaseID);
        if (IsHardCode(BaseID))
            BOLClass.QueryObjName = BaseID;
        #region Generate SearchFilter
        SqlOperators CurOperator = SqlOperators.Equal; ;
        SearchFilter sFilter;
        SearchFilterCollection sfCols = new SearchFilterCollection();
        sFilter = new SearchFilter("CODE", CurOperator, CodeArray[0].ToString());
        sfCols.Add(sFilter);
        #endregion
        DataTable dt = BOLClass.GetDataSource(sfCols, "Code", 1, 1);

        CellCollection cellCol = BOLClass.GetListCellCollection();
        int Counter = 0;
        bool BracketAdded = false;
        if (dt.Rows.Count > 0)
        {
            foreach (DataCell dataCell in cellCol)
            {
                if (dataCell.IsListTitle)
                {
                    if (Counter == 1)
                    {
                        Result = Result + " (" + dt.Rows[0][dataCell.FieldName].ToString();
                        BracketAdded = true;
                    }
                    else
                        Result = Result + " " + dt.Rows[0][dataCell.FieldName].ToString();
                    Counter++;
                }
                
            }
            if (Counter > 1 && BracketAdded)
                Result = Result + ")";
            //else
            //    Result = Result.Substring(0, Result.Length - 1);
            if (Result.EndsWith("()"))
                Result = Result.Substring(0, Result.Length - 2);
            Result = Result.Trim();
        }
        return Result;
    }

    public static string GetListTitle(string BaseID, string CodeArray)
    {
        string Result = "";
        if (CodeArray.Trim() == "")
            return Result;
        IBaseBOL BOLClass = GetBOLClass(BaseID);
        if (IsHardCode(BaseID))
            BOLClass.QueryObjName = BaseID;
        #region Generate SearchFilter
        SqlOperators CurOperator = SqlOperators.Equal; ;
        SearchFilter sFilter;
        SearchFilterCollection sfCols = new SearchFilterCollection();
        sFilter = new SearchFilter("CODE", CurOperator, CodeArray.ToString());
        sfCols.Add(sFilter);
        #endregion
        DataTable dt = BOLClass.GetDataSource(sfCols, "Code", 1, 1);

        CellCollection cellCol = BOLClass.GetListCellCollection();
        if (dt.Rows.Count > 0)
        {
            foreach (DataCell dataCell in cellCol)
            {
                if (dataCell.IsListTitle)
                    Result = Result + " " + dt.Rows[0][dataCell.FieldName].ToString();
            }
            Result = Result.Trim();
        }
        return Result;
    }

    public static string GetListTreeTitle(string BaseID, params int[] CodeArray)
    {
        string Result = "";
        IBaseBOLTree BOLClass = GetBOLClassTree(BaseID);
        if (IsHardCode(BaseID))
            BOLClass.QueryObjName = BaseID;
        #region Generate SearchFilter
        SqlOperators CurOperator = SqlOperators.Equal; ;
        SearchFilter sFilter;
        SearchFilterCollection sfCols = new SearchFilterCollection();
        sFilter = new SearchFilter("CODE", CurOperator, CodeArray[0].ToString());
        sfCols.Add(sFilter);
        #endregion
        DataTable dt = BOLClass.GetDataSource(sfCols, "Code", 1, 1);

        CellCollection cellCol = BOLClass.GetListCellCollection();
        if (dt.Rows.Count > 0)
        {
            foreach (DataCell dataCell in cellCol)
            {
                if (dataCell.IsListTitle)
                    Result = Result + " " + dt.Rows[0][dataCell.FieldName].ToString();
            }
            Result = Result.Trim();
        }
        return Result;
    }
    //public bool SendMail(string MailText, string MailSubject, string Email, string BCC, string SenderAccount)
    //{
    //    string mailServerName = "mail.hamshahrimahalleh.net";//"smtp.gmail.com";
    //    string from = "\"Subject Board\" <info@hamshahrimahalleh.net>";
    //    string to = "";
    //    string subject = "";
    //    string body = "";

    //    string Sender = SenderAccount;
    //    body = MailText;
    //    subject = MailSubject;
    //    to = Email;

    //    try
    //    {
    //        using (MailMessage message =
    //            new MailMessage(from, to, subject, body))
    //        {
    //            message.IsBodyHtml = true;
    //            if (BCC != "")
    //            {
    //                MailAddressCollection SendBCC = new MailAddressCollection();
    //                SendBCC.Add(BCC);
    //                foreach (MailAddress BCCEmail in SendBCC)
    //                    message.Bcc.Add(BCCEmail);
    //            }
    //            SmtpClient mailClient = new SmtpClient(mailServerName);

    //            //mailClient.EnableSsl = true;
    //            mailClient.UseDefaultCredentials = false;
    //            mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    //            //mailClient.Credentials = new System.Net.NetworkCredential(Sender, "ads123");
    //            mailClient.Credentials = new System.Net.NetworkCredential("", "");
    //            mailClient.Send(message);
    //        }
    //        return true;
    //    }
    //    catch (FormatException)
    //    {
    //        return false;
    //    }
    //    catch (SmtpException)
    //    {
    //        return false;
    //    }

    //}

    public static void AddToDic(Control ctrl, string BOLName, IList list)
    {
        var dic = new Dictionary<Control, object>();
        string PropertyFullName = BOLName + "." + ctrl.ID.Substring(3, ctrl.ID.Length - 3);
        dic.Add(ctrl, PropertyFullName);
        list.Add(dic);
    }
    public static string PersianTextCorrection(string str)
    {
        //ي U+FEF1 Arabic Letter Yeh Isolated Form
        //ي U+064A Arabic Letter Yeh
        //ى U+0649 Arabic Letter Alef Maksura
        //ی U+06CC Arabic Letter Farsi Yeh

        //ك U+0643 Arabic Letter Kaf
        //ک U+069A Arabic Letter Keh

        //U+0660 	٠ 	Arabic-Indic Digit Zero
        //U+0661 	١ 	Arabic-Indic Digit One
        //U+0662 	٢ 	Arabic-Indic Digit Two
        //U+0663 	٣ 	Arabic-Indic Digit Three
        //U+0664 	٤ 	Arabic-Indic Digit Four
        //U+0665 	٥ 	Arabic-Indic Digit Five
        //U+0666 	٦ 	Arabic-Indic Digit Six
        //U+0667 	٧ 	Arabic-Indic Digit Seven
        //U+0668 	٨ 	Arabic-Indic Digit Eight
        //U+0669 	٩ 	Arabic-Indic Digit Nine

        //U+06F0 	۰ 	Extended Arabic-Indic Digit Zero
        //U+06F1 	۱ 	Extended Arabic-Indic Digit One
        //U+06F2 	۲ 	Extended Arabic-Indic Digit Two
        //U+06F3 	۳ 	Extended Arabic-Indic Digit Three
        //U+06F4 	۴ 	Extended Arabic-Indic Digit Four
        //U+06F5 	۵ 	Extended Arabic-Indic Digit Five
        //U+06F6 	۶ 	Extended Arabic-Indic Digit Six
        //U+06F7 	۷ 	Extended Arabic-Indic Digit Seven
        //U+06F8 	۸ 	Extended Arabic-Indic Digit Eight
        //U+06F9 	۹ 	Extended Arabic-Indic Digit Nine
        return str.Replace('ي', 'ی').Replace('ي', 'ی').Replace('ى', 'ی').Replace('ﻳ', 'ی').Replace('ﻱ', 'ی').Replace('ﻲ', 'ی').Replace('ﻰ', 'ی').Replace('ﻯ', 'ی').Replace('ك', 'ک')
            .Replace('٠', '۰').Replace('١', '۱').Replace('٢', '۲').Replace('٣', '۳').Replace('٤', '۴')
            .Replace('٥', '۵').Replace('٦', '۶').Replace('٧', '۷').Replace('٨', '۸').Replace('٩', '۹');
    }

    public string PersianTextCorrection2(string str)
    {
        //ي U+FEF1 Arabic Letter Yeh Isolated Form
        //ي U+064A Arabic Letter Yeh
        //ى U+0649 Arabic Letter Alef Maksura
        //ی U+06CC Arabic Letter Farsi Yeh

        //ك U+0643 Arabic Letter Kaf
        //ک U+069A Arabic Letter Keh

        //U+0660 	٠ 	Arabic-Indic Digit Zero
        //U+0661 	١ 	Arabic-Indic Digit One
        //U+0662 	٢ 	Arabic-Indic Digit Two
        //U+0663 	٣ 	Arabic-Indic Digit Three
        //U+0664 	٤ 	Arabic-Indic Digit Four
        //U+0665 	٥ 	Arabic-Indic Digit Five
        //U+0666 	٦ 	Arabic-Indic Digit Six
        //U+0667 	٧ 	Arabic-Indic Digit Seven
        //U+0668 	٨ 	Arabic-Indic Digit Eight
        //U+0669 	٩ 	Arabic-Indic Digit Nine

        //U+06F0 	۰ 	Extended Arabic-Indic Digit Zero
        //U+06F1 	۱ 	Extended Arabic-Indic Digit One
        //U+06F2 	۲ 	Extended Arabic-Indic Digit Two
        //U+06F3 	۳ 	Extended Arabic-Indic Digit Three
        //U+06F4 	۴ 	Extended Arabic-Indic Digit Four
        //U+06F5 	۵ 	Extended Arabic-Indic Digit Five
        //U+06F6 	۶ 	Extended Arabic-Indic Digit Six
        //U+06F7 	۷ 	Extended Arabic-Indic Digit Seven
        //U+06F8 	۸ 	Extended Arabic-Indic Digit Eight
        //U+06F9 	۹ 	Extended Arabic-Indic Digit Nine
        return str.Replace('ي', 'ی').Replace('ي', 'ی').Replace('ى', 'ی').Replace('ﻳ', 'ی').Replace('ﻱ', 'ی').Replace('ﻲ', 'ی').Replace('ﻰ', 'ی').Replace('ﻯ', 'ی').Replace('ك', 'ک')
            .Replace('٠', '۰').Replace('١', '۱').Replace('٢', '۲').Replace('٣', '۳').Replace('٤', '۴')
            .Replace('٥', '۵').Replace('٦', '۶').Replace('٧', '۷').Replace('٨', '۸').Replace('٩', '۹');
    }

    private List<WebControl> listControls = new List<WebControl>();
    public List<WebControl> GetControls()
    {
        ContentPlaceHolder cph = ((ContentPlaceHolder)((Page)(HttpContext.Current.Handler)).Master.FindControl("cphMain"));
        RecursiveFindControl(cph.Controls);
        return listControls;
        //RecursiveFindControl(ControlCollection RootCol)
    }
    private void RecursiveFindControl(ControlCollection RootCol)
    {
        foreach (Control c in RootCol)
        {
            if (c is WebControl)
            {
                WebControl wc = (WebControl)c;
                string wcAtt = wc.Attributes["jas"];
                if (!string.IsNullOrEmpty(wcAtt) && wcAtt == "1")
                    listControls.Add(wc);
            }
            if (c.Controls.Count > 0)
                RecursiveFindControl(c.Controls);
        }
    }
    public static IList TryGet(IList<Dictionary<Control, object>> ControlsAndValues, IBaseBOL CurObj)
    {

        try
        {
            ArrayList arr = new ArrayList();
            int count = ControlsAndValues.Count;

            for (int i = 0; i < count; i++)
            {
                string message = ValidateControls(ControlsAndValues[i].Keys.First(), ControlsAndValues[i], CurObj);
                if (!string.IsNullOrEmpty(message))
                {
                    arr.Add(message);
                }
            }
            return arr;
        }
        catch (Exception exp)
        {
            throw new Exception(exp.Message);
        }
    }


    public static string[] SplitValue(ColumnAttribute att)
    {
        string dbt = att.DbType;
        string MaxLen = "", AllowNull, Dbtype;


        if ((dbt.IndexOf("NOT NULL") > 0) || (att.CanBeNull = false))
        {
            AllowNull = "FALSE";
            dbt = dbt.Replace("NOT NULL", "");
        }
        else
            AllowNull = "TRUE";

        if (dbt.IndexOf("(") > 0)
        {
            MaxLen = dbt.Substring(dbt.IndexOf("(") + 1, dbt.IndexOf(")") - (dbt.IndexOf("(") + 1));
            dbt = dbt.Replace("(" + MaxLen + ")", "");
        }

        Dbtype = dbt.Trim().ToUpper();

        return new string[] { Dbtype, MaxLen, AllowNull };

    }

    public static object GetControlValue(Control ctrl)
    {
        ContentPlaceHolder cph = ((ContentPlaceHolder)((Page)(HttpContext.Current.Handler)).Master.FindControl("cphMain"));

        object retVal = "";
        try
        {
            switch (ctrl.GetType().ToString())
            {
                //case "System.Web.UI.WebControls.TextBox":
                //    TextBox t = (TextBox)ctrl;
                //    retVal = t.Text;
                //    break;
                case "AKP.Web.Controls.ExTextBox":
                    AKP.Web.Controls.ExTextBox ExTB = (AKP.Web.Controls.ExTextBox)ctrl;
                    retVal = ExTB.Text;
                    break;

                case "System.Web.UI.WebControls.HiddenField":
                    HiddenField h = (HiddenField)ctrl;
                    retVal = h.Value;

                    break;
                case "System.Web.UI.WebControls.Label":
                    Label lbl = (Label)ctrl;
                    retVal = lbl.Text;

                    break;
                case "System.Web.UI.WebControls.RadioButtonList":
                    RadioButtonList r = (RadioButtonList)ctrl;
                    retVal = r.SelectedValue;

                    break;
                case "System.Web.UI.WebControls.DropDownList":
                    DropDownList drpList = (DropDownList)ctrl;
                    retVal = drpList.SelectedValue;

                    break;
                case "System.Web.UI.WebControls.CheckBox":
                    CheckBox chk = (CheckBox)ctrl;
                    retVal = chk.Checked;

                    break;
                case "AKP.Web.Controls.ExCheckBox":
                    CheckBox Exchk = (CheckBox)ctrl;
                    retVal = Exchk.Checked;

                    break;
                case "System.Web.UI.WebControls.RadioButton":
                    RadioButton rd = (RadioButton)ctrl;
                    retVal = rd.Checked;

                    break;
                case "AKP.Web.Controls.FarsiDate":
                    AKP.Web.Controls.FarsiDate dte = (AKP.Web.Controls.FarsiDate)ctrl;
                    retVal = dte.SelectedDateChristian;

                    break;
                case "AKP.Web.Controls.Combo":
                    AKP.Web.Controls.Combo cbo = (AKP.Web.Controls.Combo)ctrl;
                    retVal = cbo.Value;

                    break;


                case "AKP.Web.Controls.NumericTextBox":
                    AKP.Web.Controls.NumericTextBox ntxtBox = (AKP.Web.Controls.NumericTextBox)ctrl;
                    retVal = ntxtBox.Text;

                    break;
                case "System.Web.UI.WebControls.HyperLink":
                    //System.Web.UI.WebControls.HyperLink hl = (System.Web.UI.WebControls.HyperLink)ctrl;
                    //hl.ImageUrl = "~/Imager.aspx?ImgFilePath=" + HttpUtility.UrlEncode(Tools.Encode(dic.ToString())) + "&StaticHW=150";
                    //dic[ctrl] = hl.NavigateUrl;

                    break;
                case "Telerik.Web.UI.RadUpload":
                    Telerik.Web.UI.RadUpload Upload = (Telerik.Web.UI.RadUpload)ctrl;
                    string UploadPath = Upload.TargetFolder;
                    if (!string.IsNullOrEmpty(UploadPath))
                    {
                        if (Upload.UploadedFiles.Count > 0)
                        {
                            string FileExtension = GetFileExtension(Upload.UploadedFiles[0].FileName);
                            if (FileExtension.ToUpper() != "ASP" && FileExtension.ToUpper() != "ASPX" && FileExtension.ToUpper() != "JS" || FileExtension.ToUpper() == "PHP")
                            {
                                string RandName = GetRandomFileName(Upload.UploadedFiles[0].FileName);
                                Upload.UploadedFiles[0].SaveAs(HttpContext.Current.Server.MapPath(UploadPath + RandName));

                                string FileNameID = Upload.ID.Replace("upl", "hpl");
                                HyperLink hpl = (HyperLink)cph.FindControl(FileNameID);
                                hpl.ImageUrl = "~/Imager.aspx?ImgFilePath=" + HttpUtility.UrlEncode(Encode(UploadPath + RandName)) + "&StaticHW=150";

                                retVal = RandName;
                                Upload.Attributes.Add("FileName", RandName);
                                return retVal;
                            }
                        }
                        else
                            if (!string.IsNullOrEmpty(Upload.Attributes["FileName"]))
                                retVal = Upload.Attributes["FileName"];
                    }


                    string UploadID = Upload.ID;
                    string DelCheckBoxID = UploadID.Replace("upl", "chkDelete");
                    CheckBox chkDelUpload = (CheckBox)cph.FindControl(DelCheckBoxID);
                    if (chkDelUpload != null)
                    {
                        if (chkDelUpload.Checked)
                        {
                            retVal = null;
                        }

                    }

                    break;
                case "AKP.Web.Controls.ExRadUpload":
                    AKP.Web.Controls.ExRadUpload ExUpload = (AKP.Web.Controls.ExRadUpload)ctrl;
                    string ExUploadPath = ExUpload.TargetFolder;
                    if (!string.IsNullOrEmpty(ExUploadPath))
                    {
                        if (ExUpload.UploadedFiles.Count > 0)
                        {
                            string FileExtension = GetFileExtension(ExUpload.UploadedFiles[0].FileName);
                            if (FileExtension.ToUpper() != "ASP" && FileExtension.ToUpper() != "ASPX" && FileExtension.ToUpper() != "JS" || FileExtension.ToUpper() == "PHP")
                            {
                                string RandName = GetRandomFileName(ExUpload.UploadedFiles[0].FileName);
                                if (!Directory.Exists(HttpContext.Current.Request.MapPath(ExUploadPath)))
                                    Directory.CreateDirectory(HttpContext.Current.Request.MapPath(ExUploadPath));
                                ExUpload.UploadedFiles[0].SaveAs(HttpContext.Current.Server.MapPath(ExUploadPath + "/" + RandName));
                                retVal = ExUploadPath + "/" + RandName;
                                if (retVal.ToString().Length > 1)
                                    retVal = retVal.ToString().Substring(1, retVal.ToString().Length - 1);//removing ~

                                ExUpload.Attributes.Add("FileName", retVal.ToString());
                                HyperLink hl = cph.FindControl(ExUpload.ID.Replace("upl", "hpl")) as HyperLink;

                                if (IsImageExtension(GetFileExtension(retVal.ToString().ToUpper())))
                                {
                                    hl.ImageUrl = "~/Imager.aspx?ImgFilePath=" + HttpUtility.UrlEncode(Encode(retVal.ToString())) + "&StaticHW=150";
                                    hl.Attributes.Add("rel", "lightbox");
                                    hl.ToolTip = "برای مشاهده اندازه واقعی روی عکس کلیک کنید";
                                }
                                else
                                {
                                    hl.ImageUrl = "~/Images/File.jpg";
                                    hl.ToolTip = "نمایش فایل";
                                }

                                hl.NavigateUrl = retVal.ToString();

                                return retVal;
                            }
                        }
                        else
                        {
                            string FileName = ExUpload.Attributes["FileName"];
                            HyperLink hl = cph.FindControl(ExUpload.ID.Replace("upl", "hpl")) as HyperLink;
                            if (IsImageExtension(GetFileExtension(FileName.ToUpper())))
                            {
                                hl.ImageUrl = "~/Imager.aspx?ImgFilePath=" + HttpUtility.UrlEncode(Encode(FileName)) + "&StaticHW=150";
                                hl.Attributes.Add("rel", "lightbox");
                                hl.ToolTip = "برای مشاهده اندازه واقعی روی عکس کلیک کنید";
                            }
                            else
                            {
                                hl.ImageUrl = "~/Images/File.jpg";
                                hl.ToolTip = "نمایش فایل";
                            }

                            hl.NavigateUrl = FileName;
                            retVal = FileName;
                        }
                    }



                    string ExDelCheckBoxID = ExUpload.ID.Replace("upl", "chkDelete");
                    CheckBox ExchkDelUpload = (CheckBox)cph.FindControl(ExDelCheckBoxID);
                    if (ExchkDelUpload != null)
                    {
                        if (ExchkDelUpload.Checked)
                        {
                            retVal = null;
                        }

                    }

                    break;
                case "AKP.Web.Controls.Lookup":
                    AKP.Web.Controls.Lookup lkp = (AKP.Web.Controls.Lookup)ctrl;
                    retVal = lkp.Value;
                    break;

                case "AKP.Web.Controls.LookupTree":
                    AKP.Web.Controls.LookupTree lkpTree = (AKP.Web.Controls.LookupTree)ctrl;
                    retVal = lkpTree.Value;
                    break;
                case "Telerik.Web.UI.RadEditor":
                    Telerik.Web.UI.RadEditor Editor = (Telerik.Web.UI.RadEditor)ctrl;
                    retVal = PersianTextCorrection(Editor.Html).Replace("\n", "");
                    break;
                case "AKP.Web.Controls.ExRadEditor":
                    AKP.Web.Controls.ExRadEditor ExEditor = (AKP.Web.Controls.ExRadEditor)ctrl;
                    retVal = PersianTextCorrection(ExEditor.Html).Replace("\n", "");
                    //retVal = PersianTextCorrection(ExEditor.Html);
                    break;

                default:
                    retVal = "نوع کنترل غیر مجاز است.";
                    break;
            }

            return retVal;
        }
        catch (Exception exp)
        {
            return exp.Message;
        }


    }

    public static string ValidateControls(Control ctrl, Dictionary<Control, object> dic, IBaseBOL CurObj)
    {
        try
        {
            string Property = dic[ctrl].ToString().Remove(0, dic[ctrl].ToString().IndexOf(".") + 1);

            //if (!Tools.HasAccess(AccessList,AccessList,"Edit", BaseID + "." + Property))
            //    return "";

            string ErrorMessage = "";
            ContentPlaceHolder cph = ((ContentPlaceHolder)((Page)(HttpContext.Current.Handler)).Master.FindControl("cphMain"));


            MemberInfo mi = CurObj.GetType().GetMember(Property)[0];
            ColumnAttribute att = (ColumnAttribute)Attribute.GetCustomAttribute(mi, typeof(ColumnAttribute));

            string[] sv = new string[] { };
            sv = SplitValue(att);

            Label l;
            string LabelText;
            switch (ctrl.GetType().ToString())
            {
                case "AKP.Web.Controls.ExTextBox":
                    AKP.Web.Controls.ExTextBox ExTB = (AKP.Web.Controls.ExTextBox)ctrl;
                    l = cph.FindControl(ExTB.ID.Replace("txt", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";

                    if (sv[2] == "FALSE")
                        if (ExTB.DisplayMode == AKP.Web.Controls.Common.EnmDisplayMode.EditMode)
                        {
                            if (string.IsNullOrEmpty(ExTB.Text))
                            {
                                ErrorMessage = LabelText + "نباید خالی باشد";
                                return (ErrorMessage);
                            }
                        }

                    if (sv[0].ToUpper() != "NTEXT" && sv[0].ToUpper() != "TEXT")
                    {
                        if (ExTB.DisplayMode == AKP.Web.Controls.Common.EnmDisplayMode.EditMode)
                        {
                            if (ExTB.Text.Length > Convert.ToInt32(sv[1]))
                                ErrorMessage = string.Format("طول {0} بیشتر از حد مجاز است", LabelText);
                        }
                    }
                    break;

                case "System.Web.UI.WebControls.HiddenField":
                    HiddenField h = (HiddenField)ctrl;

                    break;
                case "System.Web.UI.WebControls.Label":
                    Label lbl = (Label)ctrl;

                    break;
                case "System.Web.UI.WebControls.RadioButtonList":
                    RadioButtonList r = (RadioButtonList)ctrl;

                    break;
                case "System.Web.UI.WebControls.DropDownList":
                    DropDownList drpList = (DropDownList)ctrl;

                    l = cph.FindControl(drpList.ID.Replace("cbo", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";

                    if (!(drpList.SelectedValue.ToString() != string.Empty))
                    {
                        if (sv[2] == "FALSE")
                            ErrorMessage = LabelText + "نباید خالی باشد";
                        else
                            dic[ctrl] = null;
                    }

                    break;
                case "System.Web.UI.WebControls.CheckBox":
                    CheckBox chk = (CheckBox)ctrl;

                    break;
                case "AKP.Web.Controls.ExCheckBox":
                    CheckBox Exchk = (CheckBox)ctrl;

                    break;
                case "System.Web.UI.WebControls.RadioButton":
                    RadioButton rd = (RadioButton)ctrl;

                    break;
                case "AKP.Web.Controls.FarsiDate":
                    AKP.Web.Controls.FarsiDate dte = (AKP.Web.Controls.FarsiDate)ctrl;
                    l = cph.FindControl(dte.ID.Replace("dte", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";
                    if (sv[2] == "FALSE" && dte.SelectedDateChristian == null)
                    {
                        ErrorMessage = LabelText + "نباید خالی باشد";

                    }

                    break;
                case "AKP.Web.Controls.Combo":
                    AKP.Web.Controls.Combo cbo = (AKP.Web.Controls.Combo)ctrl;
                    l = cph.FindControl(cbo.ID.Replace("cbo", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";

                    if (cbo.Value != null && cbo.Value.ToString() == string.Empty)
                    {
                        if (sv[2] == "FALSE")
                            ErrorMessage = LabelText + "نباید خالی باشد";
                    }

                    break;

                case "Telerik.Web.UI.RadEditor":
                    Telerik.Web.UI.RadEditor Editor = (Telerik.Web.UI.RadEditor)ctrl;
                    break;
                case "AKP.Web.Controls.ExRadEditor":
                    AKP.Web.Controls.ExRadEditor ExEditor = (AKP.Web.Controls.ExRadEditor)ctrl;
                    break;

                case "AKP.Web.Controls.NumericTextBox":
                    AKP.Web.Controls.NumericTextBox ntxtBox = (AKP.Web.Controls.NumericTextBox)ctrl;
                    l = cph.FindControl(ntxtBox.ID.Replace("txt", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";

                    if (ntxtBox.Text != null)
                    {
                        if (ntxtBox.HasError)
                        {
                            ErrorMessage = string.Format("عدد وارد شده برای {0} بزرگتر از حد مجاز است", LabelText);
                            return (ErrorMessage);
                        }
                    }
                    if (sv[2] == "FALSE")
                        if (ntxtBox.Text == null || string.IsNullOrEmpty(ntxtBox.Text.ToString()))
                        {
                            ErrorMessage = LabelText + "نباید خالی باشد";
                            return (ErrorMessage);
                        }
                    break;
                case "System.Web.UI.WebControls.HyperLink":
                    //System.Web.UI.WebControls.HyperLink hl = (System.Web.UI.WebControls.HyperLink)ctrl;
                    //hl.ImageUrl = "~/Imager.aspx?ImgFilePath=" + HttpUtility.UrlEncode(Tools.Encode(dic.ToString())) + "&StaticHW=150";
                    //dic[ctrl] = hl.NavigateUrl;
                    break;

                case "Telerik.Web.UI.RadUpload":
                    Telerik.Web.UI.RadUpload Upload = (Telerik.Web.UI.RadUpload)ctrl;
                    string UploadPath = Upload.TargetFolder;
                    l = cph.FindControl(Upload.ID.Replace("upl", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";
                    if (!string.IsNullOrEmpty(UploadPath))
                    {
                        if (Upload.UploadedFiles.Count > 0)
                        {
                            string FileExtension = GetFileExtension(Upload.UploadedFiles[0].FileName);
                            if (FileExtension.ToUpper() == "ASP" ||
                                FileExtension.ToUpper() == "ASPX" ||
                                FileExtension.ToUpper() == "JS" ||
                                FileExtension.ToUpper() == "PHP" ||
                                FileExtension.ToUpper() == "EXE" ||
                                FileExtension.ToUpper() == "COM" ||
                                FileExtension.ToUpper() == "BAT" ||
                                FileExtension.ToUpper() == "REG")
                            {
                                ErrorMessage = " مجاز به بارگذاری " + LabelText + " با پسوند " + FileExtension.ToUpper() + " نیستید ";
                                return (ErrorMessage);
                            }
                        }
                        else if (Upload.InvalidFiles.Count > 0)
                        {
                            int MaxSize = Upload.MaxFileSize / 1048576;
                            if (Upload.InvalidFiles[0].ContentLength > Upload.MaxFileSize)
                                ErrorMessage = LabelText + " وارد شده نباید بزرگتر از " + Convert.ToString(MaxSize) + " مگابایت باشد ";
                            else
                                ErrorMessage = LabelText + "وارد شده تصویری نیست";
                            return (ErrorMessage);
                        }
                    }
                    break;

                case "AKP.Web.Controls.ExRadUpload":
                    AKP.Web.Controls.ExRadUpload RadUpload = (AKP.Web.Controls.ExRadUpload)ctrl;
                    string RadUploadPath = RadUpload.TargetFolder;
                    l = cph.FindControl(RadUpload.ID.Replace("upl", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";
                    if (!string.IsNullOrEmpty(RadUploadPath))
                    {
                        if (RadUpload.UploadedFiles.Count > 0)
                        {
                            string FileExtension = GetFileExtension(RadUpload.UploadedFiles[0].FileName);
                            if (FileExtension.ToUpper() == "ASP" ||
                                FileExtension.ToUpper() == "ASPX" ||
                                FileExtension.ToUpper() == "JS" ||
                                FileExtension.ToUpper() == "PHP" ||
                                FileExtension.ToUpper() == "EXE" ||
                                FileExtension.ToUpper() == "COM" ||
                                FileExtension.ToUpper() == "BAT" ||
                                FileExtension.ToUpper() == "REG")
                            {
                                ErrorMessage = " مجاز به بارگذاری " + LabelText + " با پسوند " + FileExtension.ToUpper() + " نیستید ";
                                return (ErrorMessage);
                            }
                        }
                        else if (RadUpload.InvalidFiles.Count > 0)
                        {
                            int MaxSize;
                            MaxSize = RadUpload.MaxFileSize / 1048576;
                            if (RadUpload.InvalidFiles[0].ContentLength > RadUpload.MaxFileSize)
                                ErrorMessage = LabelText + " وارد شده نباید بزرگتر از " + Convert.ToString(MaxSize) + " مگابایت باشد ";
                            else
                                ErrorMessage = LabelText + "وارد شده تصویری نیست";
                            return (ErrorMessage);
                        }
                    }
                    break;
                case "AKP.Web.Controls.Lookup":
                    AKP.Web.Controls.Lookup lkp = (AKP.Web.Controls.Lookup)ctrl;
                    l = cph.FindControl(lkp.ID.Replace("lkp", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";

                    if ((lkp.Code != null && lkp.Code.ToString() == string.Empty))
                    {
                        if (sv[2] == "FALSE")
                            ErrorMessage = LabelText + "نباید خالی باشد";
                    }

                    break;


                case "AKP.Web.Controls.LookupTree":
                    AKP.Web.Controls.LookupTree lkpTree = (AKP.Web.Controls.LookupTree)ctrl;
                    l = cph.FindControl(lkpTree.ID.Replace("lkp", "lbl")) as Label;
                    LabelText = l != null ? l.Text : "";
                    LabelText = "<u>" + LabelText.Replace(":", "") + "</u>" + " ";

                    if ((lkpTree.Code.ToString() == string.Empty))
                    {
                        if (sv[2] == "FALSE")
                            ErrorMessage = LabelText + "نباید خالی باشد";
                    }
                    break;
                default:
                    ErrorMessage = "نوع کنترل غیر مجاز است.";
                    break;
            }


            //if ((pi != null) && (string.IsNullOrEmpty(ErrorMessage)))
            //    pi.SetValue(CurObj, dic[ctrl], new object[] { });

            return ErrorMessage;
        }
        catch (Exception exp)
        {
            return exp.Message;
        }


    }


    
    public void ShowControl(string FieldName, Control ctrl, object obj, IBaseBOL CurObj)
    {

        if (this.HasAccess("View", FieldName))
            Tools.SetControlValue(ctrl, obj, CurObj);
        //else
        //ctrl.SkinID = "NoViewAccess";
    }

    #region Show Label and Set Control Value
    public void ShowLabel(string FieldName, Label lbl, object obj, ShamsiDateModes DateMode)
    {
        if (this.HasAccess("View", FieldName))
            if (obj != null)
            {
                DateTimeMethods dtm = new DateTimeMethods();
                if (obj.ToString().Trim() != "")
                    lbl.Text = dtm.GetPersianDate(Convert.ToDateTime(obj));
            }
    }
    public void ShowLabel(string FieldName, Label lbl, object obj, ControlTypes ctrlType, params string[] args)
    {
        if (this.HasAccess("View", FieldName))
            if (obj != null)
            {
                switch (ctrlType)
                {
                    case ControlTypes.ExTextBox:
                        break;
                    case ControlTypes.ComboBox:
                        break;
                    case ControlTypes.Lookup:
                        break;
                    case ControlTypes.LookupTree:
                        lbl.Text = Tools.GetListTreeTitle(args[0], Convert.ToInt32(obj));
                        break;
                    case ControlTypes.PersianDate:
                        break;
                    case ControlTypes.RadUpload:
                        break;
                    case ControlTypes.NumericTextBox:
                        break;
                    case ControlTypes.Label:
                        break;
                    case ControlTypes.CheckBox:
                        break;
                    case ControlTypes.RadioButton:
                        break;
                    case ControlTypes.RadEditor:
                        break;
                    case ControlTypes.HyperLink:
                        break;
                    default:
                        break;
                }
            }
    }
    public void ShowLabel(string FieldName, HyperLink hl, object obj)
    {

        if (this.HasAccess("View", FieldName))
            if (obj != null)
            {
                hl.Text = Tools.FormatString(obj.ToString());
                hl.NavigateUrl = obj.ToString();
            }
    }
    public void ShowLabel(string FieldName, Label lbl, object obj)
    {
        if (this.HasAccess("View", FieldName))
            if (obj != null)
            {
                if (obj.GetType() == typeof(bool))
                {
                    if (Convert.ToBoolean(obj))
                        lbl.Text = "بله";
                    else
                        lbl.Text = "خیر";
                }
                else
                {
                    //lbl.Text = Tools.FormatString(obj.ToString());
                    //HyperLink hplLabel = (HyperLink)lbl;
                    if (obj != null)
                    {
                        string Result = "";
                        string ShowAllTextAtr = lbl.Attributes["ShowAllText"];
                        bool ShowAllText = ShowAllTextAtr == "1";
                        if (ShowAllText)
                            Result = obj.ToString();
                        else
                            Result = ShowMoreText(obj.ToString(), lbl, 200, ShowAllText, FieldName, "متن کامل");

                        Result = Tools.FormatString(Result);
                        lbl.Text = Result;

                    }
                }
            }
    }
    public void ShowLabel(string FieldName, Label lbl, object obj, string BaseID)
    {
        if (this.HasAccess("View", FieldName))
            if (obj != null)
            {
                lbl.Text = Tools.GetListTitle(BaseID, Convert.ToInt32(obj));
            }
    }
    public void ShowLabel(string FieldName, HyperLink hl, object obj, string UploadPath)
    {
        if (this.HasAccess("View", FieldName))
            if (obj != null)
            {
                if (obj.ToString() != "")
                {
                    if (IsImageExtension(GetFileExtension(obj.ToString().ToUpper())))
                    {
                        hl.ImageUrl = "~/Imager.aspx?ImgFilePath=" + HttpUtility.UrlEncode(Tools.Encode(UploadPath + obj.ToString())) + "&StaticHW=150";
                    }
                    else
                    {
                        hl.ImageUrl = "~/Images/File.jpg";
                        hl.ToolTip = "نمایش فایل";
                    }
                    hl.NavigateUrl = UploadPath + obj.ToString();
                }

            }
    }
    public static void SetControlValue(Control ctrl, object obj, IBaseBOL CurObj)
    {
        #region Display Mandatory -- Moved EditForm.cs
        //Label lbl;
        //string ctrID;
        //string[] sv = new string[] { };

        //ctrID = ctrl.ID.Substring(3, ctrl.ID.Length - 3);
        //ContentPlaceHolder cphMandatory = ((ContentPlaceHolder)((Page)(HttpContext.Current.Handler)).Master.FindControl("cphMain"));
        //lbl = cphMandatory.FindControl("lbl" + ctrID) as Label;

        //PropertyInfo piMandatory = CurObj.GetType().GetProperty(ctrID);
        //MemberInfo miMandatory = CurObj.GetType().GetMember(ctrID)[0];
        //ColumnAttribute attMandatory = (ColumnAttribute)System.Attribute.GetCustomAttribute(miMandatory, typeof(ColumnAttribute));

        //sv = SplitValue(attMandatory);
        //if (sv[2] == "FALSE" && lbl != null)
        //    lbl.Text = lbl.Text + " * ";

        #endregion Display Mandatory

        switch (ctrl.GetType().ToString())
        {
            case "System.Web.UI.WebControls.HiddenField":
                HiddenField h = (HiddenField)ctrl;
                h.Value = obj.ToString();
                break;
            case "System.Web.UI.WebControls.Label":
                Label l = (Label)ctrl;
                if (obj != null)
                    l.Text = obj.ToString();
                break;
            case "System.Web.UI.WebControls.RadioButtonList":
                RadioButtonList r = (RadioButtonList)ctrl;
                r.SelectedValue = obj.ToString();
                break;
            case "System.Web.UI.WebControls.DropDownList":
                DropDownList drpList = (DropDownList)ctrl;
                if ((obj.ToString() != string.Empty))
                    drpList.SelectedValue = obj.ToString();
                else
                    obj = DBNull.Value;
                break;
            case "System.Web.UI.WebControls.CheckBox":
                CheckBox chk = (CheckBox)ctrl;
                if (obj != DBNull.Value)
                    chk.Checked = Convert.ToBoolean(obj);
                break;
            case "AKP.Web.Controls.ExCheckBox":
                CheckBox Exchk = (CheckBox)ctrl;
                if (obj != DBNull.Value)
                    Exchk.Checked = Convert.ToBoolean(obj);
                break;

            case "System.Web.UI.WebControls.RadioButton":
                RadioButton rd = (RadioButton)ctrl;
                if (obj != DBNull.Value)
                    rd.Checked = Convert.ToBoolean(obj);
                break;
            case "AKP.Web.Controls.FarsiDate":
                AKP.Web.Controls.FarsiDate dte = (AKP.Web.Controls.FarsiDate)ctrl;
                if (obj != null)
                    dte.SelectedDateChristian = Convert.ToDateTime(obj);
                break;
            case "AKP.Web.Controls.Combo":
                AKP.Web.Controls.Combo cbo = (AKP.Web.Controls.Combo)ctrl;
                if (obj != null)
                    cbo.Value = Convert.ToInt32(obj);
                break;
            case "AKP.Web.Controls.ExTextBox":
                AKP.Web.Controls.ExTextBox ExTB = (AKP.Web.Controls.ExTextBox)ctrl;
                if (obj != null)
                {
                    if ((ExTB.DisplayMode == AKP.Web.Controls.Common.EnmDisplayMode.ViewMode))
                    {
                        ExTB.Text = new Tools().ShowMoreText(obj.ToString(), ExTB, ExTB.MoreLinkLength, !ExTB.HasMoreLink, HttpContext.Current.Request.QueryString["BaseID"] + "." + ExTB.ID.Remove(0, 3), ExTB.MoreLinkText);
                    }
                    else
                        ExTB.Text = obj.ToString();
                }

                break;

            case "AKP.Web.Controls.NumericTextBox":
                AKP.Web.Controls.NumericTextBox ntxtBox = (AKP.Web.Controls.NumericTextBox)ctrl;
                if (obj != null)
                    ntxtBox.Text = Convert.ToInt32(obj);
                break;


            case "Telerik.Web.UI.RadEditor":
                Telerik.Web.UI.RadEditor Editor = (Telerik.Web.UI.RadEditor)ctrl;
                if (obj != null)
                    Editor.Html = PersianTextCorrection(obj.ToString());
                break;
            case "AKP.Web.Controls.ExRadEditor":
                AKP.Web.Controls.ExRadEditor ExEditor = (AKP.Web.Controls.ExRadEditor)ctrl;
                if (obj != null)
                    ExEditor.Html = PersianTextCorrection(obj.ToString());
                break;

            case "System.Web.UI.WebControls.HyperLink":
                break;

            case "Telerik.Web.UI.RadUpload":
                Telerik.Web.UI.RadUpload wc = (Telerik.Web.UI.RadUpload)ctrl;
                string DBFieldName = wc.ID.Substring(3, wc.ID.Length - 3);
                ContentPlaceHolder cph = ((ContentPlaceHolder)((Page)(HttpContext.Current.Handler)).Master.FindControl("cphMain"));
                HyperLink hpl = (HyperLink)cph.FindControl("hpl" + DBFieldName);
                wc.Attributes.Add("FileName", obj != null ? obj.ToString() : "");

                SetControlValue(hpl, obj, wc.TargetFolder);
                if (HttpContext.Current.Request["ViewMode"] == "1")
                {
                    CheckBox chkDelete = (CheckBox)cph.FindControl("chkDelete" + wc.ID.Replace("upl", ""));
                    chkDelete.Visible = false;
                    wc.Visible = false;
                }

                break;
            case "AKP.Web.Controls.ExRadUpload":
                AKP.Web.Controls.ExRadUpload upl = (AKP.Web.Controls.ExRadUpload)ctrl;
                string ExDBFieldName = upl.ID.Substring(3, upl.ID.Length - 3);
                ContentPlaceHolder Excph = ((ContentPlaceHolder)((Page)(HttpContext.Current.Handler)).Master.FindControl("cphMain"));
                HyperLink Exhpl = (HyperLink)Excph.FindControl("hpl" + ExDBFieldName);
                upl.Attributes.Add("FileName", obj != null ? obj.ToString() : "");
                SetControlValue(Exhpl, obj, upl.TargetFolder);

                break;
            case "AKP.Web.Controls.Lookup":
                AKP.Web.Controls.Lookup lkp = (AKP.Web.Controls.Lookup)ctrl;
                if (obj != null)
                {
                    lkp.Code = Convert.ToInt32(obj);
                    lkp.Title = GetListTitle(lkp.BaseID, Convert.ToInt32(obj));

                }
                break;
            case "AKP.Web.Controls.LookupTree":
                AKP.Web.Controls.LookupTree lkpTree = (AKP.Web.Controls.LookupTree)ctrl;
                if (obj != null)
                {
                    lkpTree.Code = Convert.ToInt32(obj);
                    lkpTree.Title = GetListTreeTitle(lkpTree.BaseID, Convert.ToInt32(obj));
                }
                break;


            default:
                throw new Exception("نوع کنترل غیر مجاز است.");
        }
    }
    public static void SetControlValue(Control ctrl, object obj, string UploadPath)
    {

        HyperLink hl = (HyperLink)ctrl;
        if (obj != null)
        {
            //object FullNameObj = UploadPath + obj;
            object FullNameObj = obj;
            if (obj.ToString().IndexOf(".") < 0)
                hl.Visible = false;
            else
            {
                if (IsImageExtension(GetFileExtension(obj.ToString().ToUpper())))
                {
                    hl.ImageUrl = "~/Imager.aspx?ImgFilePath=" + HttpUtility.UrlEncode(Encode(FullNameObj.ToString())) + "&StaticHW=150";
                    hl.Attributes.Add("rel", "lightbox");
                    hl.ToolTip = "برای مشاهده اندازه واقعی روی عکس کلیک کنید";
                }
                else
                {
                    hl.ImageUrl = "~/Images/File.jpg";
                    hl.ToolTip = "نمایش فایل";
                }

                hl.NavigateUrl = FullNameObj.ToString();
            }
        }
    }
    #endregion

    public void ShowFullLabel(string FieldName, Label lbl, object obj)
    {
        //if (this.HasAccess("View", FieldName))
        if (obj != null)
        {
            if (obj.GetType() == typeof(bool))
            {
                if (Convert.ToBoolean(obj))
                    lbl.Text = "بله";
                else
                    lbl.Text = "خیر";
            }
            else
            {
                //lbl.Text = Tools.FormatString(obj.ToString());
                //HyperLink hplLabel = (HyperLink)lbl;
                if (obj != null)
                {
                    string Result = "";
                    string strText = obj.ToString();

                    Result = strText;
                    Result = Tools.FormatString(Result);
                    lbl.Text = Result;

                }
            }
        }
    }
    private string ShowMoreText(string text, WebControl lbl, int Length, bool ShowAllText, string FieldName, string MoreLinkText)
    {
        string Result = "";
        string strText = text;

        if (strText.Length > Length && !ShowAllText)
        {
            int BlankPos = strText.IndexOf(" ", Length);
            if (BlankPos == -1) if (strText.Length > 30) BlankPos = 30;

            string url = new HyperLink().ResolveClientUrl(string.Format("~/ShowLabel.aspx?FullFieldName={0}&DetailCode={1}", FieldName, HttpContext.Current.Request.Params["Code"]));
            url = "window.open('" + url + "','','width=640,height=420,menubar=no,status=no,titlebar=no,scrollbars,resizable=yes,top=200,left=150');return false; ";
            string moreLink = string.Format(string.Format("<a style=\"cursor:pointer;color:Blue;\" onclick=\"{0}\" target='_blank'>{1}</a>", url, MoreLinkText));
            Result = Tools.FormatString(strText.Substring(0, BlankPos)) + "..." + moreLink;
        }
        else
            Result = strText;

        return Result;
    }

    public static string FormatString(object objstr)
    {
        if (objstr == null)
            return "";

        string str = Convert.ToString(objstr);
        str = str.Replace("\n", "<br />");
        return str;
    }
    public static void SetClientScript(Page p, string Key, string ScriptBody)
    {
        string ScriptStr;
        ScriptStr = "<script language='javascript'>";
        ScriptStr = ScriptStr + ScriptBody + "</script>";
        p.RegisterStartupScript(Key, ScriptStr);
    }

    private static ArrayList CreateList(string _pattern, string Result, int WordCount)
    {
        ArrayList ResultList = new ArrayList();
        Regex r = new Regex(_pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        Match m = r.Match(Result);
        string CurKeyword = "";
        while (m.Success)
        {
            CurKeyword = m.Groups[0].Captures[0].ToString();
            if (CurKeyword.Length > 2)
            {
                if (!ResultList.Contains(CurKeyword))
                {
                    if (WordCount > 1)
                        ResultList.Add(CurKeyword);
                    else
                    {
                        //if (!IsInGarbageWords(CurKeyword))
                            ResultList.Add(CurKeyword);
                    }
                }
            }
            m = m.NextMatch();
        }
        return ResultList;
    }
    protected int FindKeyNums(string Content, string Keyword)
    {
        int Count = 0;
        int IndexPos;
        IndexPos = Content.IndexOf(Keyword);
        while (IndexPos >= 0)
        {
            Count++;
            IndexPos = Content.IndexOf(Keyword, IndexPos + 1);
        }
        return Count;
    }
    internal void CheckEditButtnAccess(MasterPage mp, string BaseID)
    {
        AccessList = GetAccessList(BaseID);
        if (!HasAccess("Edit", BaseID))
        {
            try
            {
                ((ContentPlaceHolder)mp.FindControl("cphMain")).FindControl("hplEdit").Visible = false;
            }
            catch
            {
            }
        }
    }

    public static string GetRandID()
    {
        Random RandomNumber = new Random();
        double dblRandRowIndex = RandomNumber.NextDouble();
        string strRandNum = dblRandRowIndex.ToString();
        string GenID = strRandNum.Substring(2, strRandNum.Length - 2);
        return GenID;
    }
}

public class RandomProportional : Random
{
    // Sample generates a distribution proportional to the value 
    // of the random numbers, in the range [ 0.0, 1.0 ).
    protected override double Sample()
    {
        return Math.Sqrt(base.Sample());
    }
}

public class SearchFilter
{
    private string _columnName;
    private SqlOperators _operator = SqlOperators.Like;
    private string _value;
    public Operands CurOperand = Operands.AND;
    public SqlOperators Operator
    {
        get
        {
            return _operator;
        }
        set
        {
            _operator = value;
        }
    }
    public string ColumnName
    {
        get
        {
            return _columnName;
        }
        set
        {
            _columnName = value;
        }
    }
    public string Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
        }
    }

    public SearchFilter(string Col, SqlOperators Op, string Val)
    {
        _columnName = Col;
        _operator = Op;
        _value = Val;
    }
}
public class DataCell
{
    public Color DataBGCellCol;
    public Color HeaderBGCellCol;
    public Directions Direction = Directions.None;
    public CellTypes CellType = CellTypes.grdTextBox;
    public bool IsKey = false;
    public bool IsDate = false;
    public bool IsListTitle = false;
    public string CaptionName = "";
    public int MaxLength;
    public AlignTypes Align = AlignTypes.None;
    public string FieldName;
    public Unit Width;
    public DisplayModes DisplayMode = DisplayModes.Visible;
    public string ExtraAttribute;
    public bool IsImage = false;

    public DataCell(string _FieldName, string _CaptionName, AlignTypes _Align, Unit _Width)
    {
        FieldName = _FieldName;
        CaptionName = _CaptionName;
        Align = _Align;
        Width = _Width;
    }
    public DataCell()
    {
    }

}
public class SearchFilterCollection : CollectionBase
{
    public SearchFilter this[int index]
    {
        get
        {
            if (index <= List.Count - 1)
                return (SearchFilter)List[index];
            else
                return null;
        }
        set
        {
            if (index <= List.Count - 1)
                List[index] = value;
        }
    }
    public void Add(SearchFilter newCell)
    {
        List.Add(newCell);
    }
    public void Remove(SearchFilter newCell)
    {
        List.Remove(newCell);
    }
    public void Contains(SearchFilter newCell)
    {
        List.Contains(newCell);
    }
}
public class CellCollection : CollectionBase
{
    public DataCell this[int index]
    {
        get
        {
            if (index <= List.Count - 1)
                return (DataCell)List[index];
            else
                return null;
        }
        set
        {
            if (index <= List.Count - 1)
                List[index] = value;
        }
    }
    public void Add(DataCell newCell)
    {
        List.Add(newCell);
    }
    public void Remove(DataCell newCell)
    {
        List.Remove(newCell);
    }
    public void Contains(DataCell newCell)
    {
        List.Contains(newCell);
    }
}

public enum Operands
{
    AND,
    OR
}
public enum SqlOperators
{
    Equal,
    Like,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual,
    NotEqual,
    DontHave,
    Between,
    StartsWith,
    EndWith
}
public enum CellTypes
{
    grdCheckBox,
    grdOptionBox,
    grdImageBox,
    grdTextBox,
    grdLabelBox,
    grdComboBox,
    grdListBox,
    grdDateText
}
public enum DisplayModes
{
    Visible,
    Hidden,
    HiddenDefault
}
public enum Directions
{
    LeftToRight,
    RightToLeft,
    None
}
public enum AlignTypes
{
    Left,
    Right,
    Center,
    Justify,
    None
}
public enum ListRoles
{
    Browse,
    List
}
public enum AccessNameTypes
{
    News,
    Edit,
    Delete,
    View,
    Export
}
public enum ShamsiDateModes
{
    Simple,
    Long,
    FullDesc
}

public enum ControlTypes
{
    ExTextBox,
    ComboBox,
    Lookup,
    LookupTree,
    PersianDate,
    RadUpload,
    NumericTextBox,
    Label,
    CheckBox,
    RadioButton,
    RadEditor,
    HyperLink
}

public enum MessageTypes
{
    Info,
    Error
}

public class op_result
{
    private string _result;
    public string result
    {
        set
        {
            _result = value;
        }
        get
        {
            return _result;
        }
    }

    private string _success;
    public string success
    {
        set
        {
            _success = value;
        }
        get
        {
            return _success;
        }
    }
}

