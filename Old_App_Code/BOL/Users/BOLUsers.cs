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

public class BOLUsers : BaseBOLUsers, IBaseBOL<Users>
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
    public Users GetDataByEmail(string Email)
    {
        Users ValidUser = dataContext.Users.SingleOrDefault(p => p.Email.Equals(Email));
        return ValidUser;
    }

    public Users GetUserInfo(string Email)
    {
        return dataContext.Users.SingleOrDefault(p => p.Email.Equals(Email));
    }
    public System.Linq.IQueryable<vUserAccess> GetUserAccessByBaseID(int Code, string BaseID)
    {
        if (BaseID != null)
            return from u in dataContext.vUserAccesses
                   where u.UserCode.Equals(Code) && u.ResName.StartsWith(BaseID)
                   select u;
        else
            return from u in dataContext.vUserAccesses
                   where u.UserCode.Equals(Code) && (u.TypeCode.Equals(1) || u.TypeCode.Equals(2))
                   select u;

    }
    public System.Linq.IQueryable<vUserAccess> GetUserAccess(int Code)
    {
        var AccList = from u in dataContext.vUserAccesses
                      where u.UserCode.Equals(Code)
                      select u;
        return AccList;
    }



    public bool EmailExists(string Email)
    {
        IQueryable<Users> Result = dataContext.Users.Where(p => p.Email.Equals(Email));
        if (Result.Count() > 0)
            return true;
        else
            return false;
    }

    public Users GetUserByEmail(string Email)
    {
        return dataContext.Users.SingleOrDefault(p => p.Email.Equals(Email));
    }

    public void ChangePassword(int? Code, string NewPassword)
    {
        Users CurUser = dataContext.Users.SingleOrDefault(p => p.Code.Equals((int)Code));
        if (CurUser != null)
        {
            CurUser.Password = Tools.Encode(NewPassword);
            dataContext.SubmitChanges();
        }
    }

    public int InsertRecord()
    {
        Users ObjTable;
        ObjTable = new Users();
        dataContext.Users.InsertOnSubmit(ObjTable);
        try
        {
            #region Save Controls
            ObjTable.ID = ID;
            ObjTable.HCGenderCode = HCGenderCode;
            ObjTable.Name = Name;
            ObjTable.Password = Password;
            ObjTable.Email = Email;
            ObjTable.AutoLogin = AutoLogin;
            ObjTable.Active = Active;
            #endregion

            dataContext.SubmitChanges();
        }
        catch (Exception exp)
        {
            throw exp;
        }

        return ObjTable.Code;

    }


    public Users GetUserInfoByID(string UserID)
    {
        return dataContext.Users.SingleOrDefault(p => p.ID.Equals(UserID));
    }

    

    internal int GetBalanace(int UserCode)
    {
        int? Balance = dataContext.fnGetUserBalance(UserCode);
        if (Balance != null)
            return (int)Balance;
        else
            return 0;
    }


    internal int GetBalance(int UserCode)
    {
        int? UserBalance = dataContext.fnGetUserBalance(UserCode);
        if (UserBalance == null)
            UserBalance = 0;
        return (int)UserBalance;

    }
}
