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
using Telerik.Web.UI;
using System.Drawing;

public partial class Admin_Products_ProductCatsTree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BOLProductCats BOLClass = new BOLProductCats();

            TreeProductCats.DataTextField = "Name";
            TreeProductCats.DataFieldID = "Code";
            TreeProductCats.DataFieldParentID = "MasterCode";
            TreeProductCats.DataValueField = "Code";

            TreeProductCats.DataSource = BOLClass.GetAllNodes();
            TreeProductCats.DataBind();

            BannersDataContext dc2 = new BannersDataContext();

        }

    }

    protected bool CheckTextBox(Button button, TextBox textBox)
    {
        if (textBox.Text.Length == 0)
        {
            RadAjaxManager1.Alert("لطفا نام گره را وارد کنید");
            textBox.BackColor = Color.Yellow;
            return false;
        }
        else
        {
            textBox.BackColor = Color.White;
            return true;
        }
    }
    protected void btnAddChild_Click(object sender, System.EventArgs e)
    {
        if (TreeProductCats.SelectedNode == null)
        {
            RadAjaxManager1.Alert("لطفا یک گره انتخاب کنید");
        }
        else
        {
            if (CheckTextBox(btnAddChild, tbNewNodeText))
            {
                BOLProductCats ProductCatsBOl = new BOLProductCats();
                int ReturnCode = ProductCatsBOl.InsertRecord(Convert.ToInt32(TreeProductCats.SelectedNode.Value), tbNewNodeText.Text);

                RadTreeNode rtn = new RadTreeNode(tbNewNodeText.Text);
                rtn.Value = ReturnCode.ToString();
                TreeProductCats.SelectedNode.Nodes.Add(rtn);
                TreeProductCats.SelectedNode.ExpandChildNodes();

                tbNewNodeText.Text = string.Empty;
            }

        }
    }

    protected void TreeProductCats_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        tbNodeText.Text = e.Node.Text;
    }
    protected void btnRemove_Click(object sender, System.EventArgs e)
    {
        if (TreeProductCats.SelectedNode != null)
        {
            if (!TreeProductCats.SelectedNode.Equals(TreeProductCats.Nodes[0]))
            {
                if (TreeProductCats.SelectedNode.Nodes.Count != 0)
                {
                    RadAjaxManager1.Alert("لطفا ابتدا گره های داخلی را حذف کنید");
                }
                else
                {
                    BOLProductCats ProductCatsBOl = new BOLProductCats();
                    ((IBaseBOLTree<ProductCats>)ProductCatsBOl).DeleteRecord(TreeProductCats.SelectedNode.Value);
                    TreeProductCats.SelectedNode.Remove();
                    tbNodeText.Text = string.Empty;
                }
            }
            else
            {
                RadAjaxManager1.Alert("گره اصلی قابل انتقال نیست");
            }
        }
        else
        {
            RadAjaxManager1.Alert("لطفا یک گره انتخاب کنید");
        }
    }

    protected void AddChilds(RadTreeNode dstNode, RadTreeNode srcNode)
    {
        foreach (RadTreeNode srcChildNode in srcNode.Nodes)
        {
            RadTreeNode destChildNode = new RadTreeNode(srcChildNode.Text, srcChildNode.Value);
            dstNode.Nodes.Add(destChildNode);
            AddChilds(destChildNode, srcChildNode);
        }
    }

    public void AjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        string[] args = e.Argument.Replace("\r\n", "\n").Split('\n');
        RadTreeView srcTree = null;
        RadTreeView dstTree = null;
        if (TreeProductCats.ClientID.Equals(args[0]))
        {
            srcTree = TreeProductCats;
        }
        else if (TreeProductCats.ClientID.Equals(args[0]))
        {
            srcTree = TreeProductCats;
        }

        if (TreeProductCats.ClientID.Equals(args[1]))
        {
            dstTree = TreeProductCats;
        }
        else if (TreeProductCats.ClientID.Equals(args[1]))
        {
            dstTree = TreeProductCats;
        }

        RadTreeNode sourceNode = srcTree.FindNodeByText(args[2]);
        RadTreeNode destNode = dstTree.FindNodeByText(args[3]);

        //if (sourceNode.Parent == null)
        //{
        //    RadAjaxManager1.Alert("گره اصلی قابل حذف نیست");
        //    return;
        //}
        RadTreeNode tempNode = destNode;
        while (tempNode != null)
        {
            if (!tempNode.Equals(sourceNode))
                tempNode = tempNode.ParentNode;
            else
                break;
        }
        if (tempNode != null)
        {
            RadAjaxManager1.Alert("نمیتوان یک گره را به فرزندانش منتقل کرد");
            return;
        }

        BOLProductCats ProductCatsBOl = new BOLProductCats();
        ProductCatsBOl.Code = Convert.ToInt32(sourceNode.Value);
        ProductCatsBOl.MasterCode = Convert.ToInt32(destNode.Value);
        ProductCatsBOl.Name = sourceNode.Text;
        ProductCatsBOl.SaveChanges(false);

        RadTreeNode newNode = new RadTreeNode(sourceNode.Text, sourceNode.Value);
        AddChilds(newNode, sourceNode);
        destNode.Nodes.Add(newNode);
        destNode.ExpandChildNodes();
        if (!sourceNode.Equals(srcTree.Nodes[0]))
        {
            sourceNode.Remove();
        }
    }

    protected void RadTreeView1_HandleDrop(object sender, RadTreeNodeDragDropEventArgs e)
    {
        RadTreeNode sourceNode = e.SourceDragNode;
        RadTreeNode destNode = e.DestDragNode;
        RadTreeViewDropPosition dropPosition = e.DropPosition;

        if (destNode != null) //drag&drop is performed between trees
        {
            PerformDragAndDrop(dropPosition, sourceNode, destNode);
        }
    }

    private void PerformDragAndDrop(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode, RadTreeNode destNode)
    {
        if (sourceNode.Equals(destNode) || sourceNode.IsAncestorOf(destNode))
        {
            return;
        }
        sourceNode.Owner.Nodes.Remove(sourceNode);

        switch (dropPosition)
        {
            case RadTreeViewDropPosition.Over:
                // child
                if (!sourceNode.IsAncestorOf(destNode))
                {
                    destNode.Nodes.Add(sourceNode);
                }
                break;

            case RadTreeViewDropPosition.Above:
                // sibling - above                    
                destNode.InsertBefore(sourceNode);
                break;

            case RadTreeViewDropPosition.Below:
                // sibling - below
                destNode.InsertAfter(sourceNode);
                break;
        }
        BOLProductCats ProductCatsBOl = new BOLProductCats();
        ProductCatsBOl.UpdateRecord(Convert.ToInt32(sourceNode.Value), Convert.ToInt32(destNode.Value), sourceNode.Text);

    }

    protected void btnRename_Click(object sender, System.EventArgs e)
    {
        if (CheckTextBox(btnRename, tbNodeText))
        {
            if (TreeProductCats.SelectedNode != null)
            {
                BOLProductCats ProductCatsBOl = new BOLProductCats();
                int? MasterCode = null;
                if (TreeProductCats.SelectedNode.ParentNode != null)
                    MasterCode = Convert.ToInt32(((RadTreeNode)TreeProductCats.SelectedNode.ParentNode).Value);
                ProductCatsBOl.UpdateRecord(Convert.ToInt32(TreeProductCats.SelectedNode.Value), MasterCode, tbNodeText.Text);
                TreeProductCats.SelectedNode.Text = tbNodeText.Text;
            }
            else
            {
                RadAjaxManager1.Alert("لطفا یک گره برای تغییر نام انتخاب کنید");
            }
        }
    }

    protected void btnAddRoot_Click(object sender, System.EventArgs e)
    {
        if (CheckTextBox(btnAddRoot, tbNewNodeText))
        {
            TreeProductCats.Nodes.Add(new RadTreeNode(tbNewNodeText.Text));
            BOLProductCats ProductCatsBOl = new BOLProductCats();
            ProductCatsBOl.InsertRecord(null, tbNewNodeText.Text);
            tbNewNodeText.Text = string.Empty;
        }
    }
}
