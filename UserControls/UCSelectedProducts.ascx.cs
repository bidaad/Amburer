using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Amburer.UserControls
{
    public partial class UCSelectedProducts : System.Web.UI.UserControl
    {
        protected int _hcSelectTypeCode = 1;
        public int HCSelectTypeCode
        {
            get
            {
                return _hcSelectTypeCode;
            }
            set
            {
                _hcSelectTypeCode = value;
            }
        }
        protected int _itemCount = 0;
        public int ItemCount
        {
            get
            {
                return _itemCount;
            }
            set
            {
                _itemCount = value;
            }
        }

        protected int _productCode = 0;
        public int ProductCode
        {
            get
            {
                return _productCode;
            }
            set
            {
                _productCode = value;
            }
        }

        protected int _catCode = 1;
        public int CatCode
        {
            get
            {
                return _catCode;
            }
            set
            {
                _catCode = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowSelectedProducts()
        {
            switch (_hcSelectTypeCode)
            {
                case 1:
                    ltrHeader.Text = "جدیدترین محصولات";
                    break;
                case 2:
                    ltrHeader.Text = "پر فروش ترین محصولات";
                    break;
                case 3:
                    ltrHeader.Text = "پر بازدید ترین محصولات";
                    break;
                case 4:
                    ltrHeader.Text = "محصولات ویژه";
                    break;
                case 5:
                    ltrHeader.Text = "برخی محصولات دیگر این گروه";
                    break;
                default:
                    break;
            }

            BOLProducts ProductsBOL = new BOLProducts();

            if (_hcSelectTypeCode != 5)
            {
                rptSelectedPros.DataSource = ProductsBOL.GetSelectedProducts(_hcSelectTypeCode, 5, 1);
                rptSelectedPros.DataBind();
            }
            else
            {

                rptSelectedPros.DataSource = ProductsBOL.GetRandProductsByCatCode(_catCode, 16, _productCode);
                rptSelectedPros.DataBind();
            }
        }

        
    }
}