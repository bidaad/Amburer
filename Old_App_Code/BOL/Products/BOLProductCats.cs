using System.Collections.Generic;
using System.Collections;
using Amburer.Old_App_Code.DAL;
using System.Data;
using System.Linq;
using Monty.Linq;

public class BOLProductCats : BaseBOLProductCats, IBaseBOLTree<ProductCats>
{
    public IList CheckBusinessRules()
    {
        var messages = new List<string>();
        //Business rules here

        if (false)
            messages.Add("");

        return messages;
    }



    public void UpdateRecord(int Code, int? MasterCode, string Name)
    {
        ProductCats CurCat = dataContext.ProductCats.SingleOrDefault(p => p.Code.Equals(Code));
        CurCat.MasterCode = MasterCode;
        CurCat.Name = Name;
        dataContext.SubmitChanges();
    }

    public int InsertRecord(int? MasterCode, string Name)
    {
        ProductCats NewCat = new ProductCats();
        dataContext.ProductCats.InsertOnSubmit(NewCat);
        NewCat.MasterCode = MasterCode;
        NewCat.Name = Name;
        dataContext.SubmitChanges();
        return NewCat.Code;
    }



    public ProductCats GetSingleCat(int Code)
    {
        return dataContext.ProductCats.SingleOrDefault(p => p.Code.Equals(Code));
    }

    internal ProductCats GetCatInfo(int Code)
    {
        return dataContext.ProductCats.SingleOrDefault(p => p.Code.Equals(Code));
    }
}
