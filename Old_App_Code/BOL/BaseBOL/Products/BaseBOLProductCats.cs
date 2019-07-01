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
using System.Web.SessionState;
using System.Collections.Generic;
using System.Reflection;
using Amburer.Old_App_Code.DAL;

public class BaseBOLProductCats : ProductCats, IBaseBOLTree<ProductCats>
{
    public ProductsDataContext dataContext;
    List<AccessListStruct> AccessList;
    protected string TableOrViewName = "vProductCats";
    public string BaseID = "ProductCats";
    public BaseBOLProductCats()
    {
        dataContext = new ProductsDataContext();

    }

    string IBaseBOLTree.QueryObjName
    {
        get
        {
            return TableOrViewName;
        }
        set
        {
            TableOrViewName = value;
        }
    }
    public List<WebControl> ObjectList;

    protected int _code;
    int IBaseBOLTree.Code
    {
        get
        {
            return _code;
        }

        set
        {
            _code = value;
        }
    }

    protected int? _masterCode;
    int? IBaseBOLTree.MasterCode
    {
        get
        {
            return _masterCode;
        }

        set
        {
            _masterCode = value;
        }
    }

    protected string _name;
    string IBaseBOLTree.Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    ProductCats IBaseBOLTree<ProductCats>.GetDetails(int Code)
    {
        return dataContext.ProductCats.Single(p => p.Code.Equals(Code));
    }
    public int SaveChanges(bool IsNewRecord)
    {
        HttpSessionState Session = HttpContext.Current.Session;
        ProductCats ObjTable;
        if (IsNewRecord)
        {
            ObjTable = new ProductCats();
            dataContext.ProductCats.InsertOnSubmit(ObjTable);
        }
        else
        {
            ObjTable = dataContext.ProductCats.Single(p => p.Code.Equals(_code));
        }
        try
        {
            #region Save Detail Controls
            ObjTable.Code = _code;
            ObjTable.MasterCode = _masterCode;
            ObjTable.Name = _name;
            #endregion

            Tools tools = new Tools();
            tools.AccessList = tools.GetAccessList("ProductCats");
            if (tools.HasAccess("Edit", "ProductCats"))
                dataContext.SubmitChanges();
        }
        catch (Exception exp)
        {
            throw exp;
        }

        return ObjTable.Code;
    }
    #region IBaseBOLTree Members
    string IBaseBOLTree.EditForm
    {
        get { return "ProductCats/EditProductCats.aspx"; }
    }
    string IBaseBOLTree.ViewForm
    {
        get { return ""; }
    }

    string IBaseBOLTree.PageLable
    {
        get { return "گروه های افراد"; }
    }
    int IBaseBOLTree.EditWidth
    {
        get { return 750; }
    }
    int IBaseBOLTree.EditHeight
    {
        get { return 600; }
    }
    DataTable IBaseBOLTree.GetDataSource(SearchFilterCollection sFilterCols, string SortString, int PageSize, int CurrentPage)
    {
        string WhereCond = Tools.GetCondition(sFilterCols);
        var ListResult = dataContext.ExecuteQuery<vProductCats>(string.Format("exec spGetPaged '{0}','{1}','{2}','{3}',N'{4}'", TableOrViewName, SortString, PageSize, CurrentPage, WhereCond));
        DataTable dt = new Converter<vProductCats>().ToDataTable(ListResult);
        return dt;
    }

    void IBaseBOLTree.DeleteRecord(params string[] DelParam)
    {
        Tools tools = new Tools();
        tools.AccessList = tools.GetAccessList("ProductCats");
        if (tools.HasAccess("Edit", "ProductCats"))
        {
            ProductCats ObjTable = dataContext.ProductCats.Single(p => p.Code.Equals(DelParam[0]));
            dataContext.ProductCats.DeleteOnSubmit(ObjTable);
            dataContext.SubmitChanges();
        }
    }

    CellCollection IBaseBOLTree.GetListCellCollection()
    {
        DataCell dataCell;
        CellCollection CellCol = new CellCollection();

        dataCell = new DataCell();
        dataCell.CaptionName = "کد";
        dataCell.IsKey = true;
        dataCell.DisplayMode = DisplayModes.Hidden;
        dataCell.Align = AlignTypes.Right;
        dataCell.FieldName = "Code";
        dataCell.MaxLength = 100;
        dataCell.Width = 50;
        CellCol.Add(dataCell);

        dataCell = new DataCell("Name", "نام", AlignTypes.Right, 200);
        dataCell.IsListTitle = true;
        CellCol.Add(dataCell);

        return CellCol;
    }

    #endregion
}
