using CSEgitim301_BussinesLayer.Abstract;
using CSEgitim301_BussinesLayer.Concrete;
using CSEgitim301_DataAccessLayer.Abstract;
using CSEgitim301_DataAccessLayer.EntityFramework;
using CSEgitim301_entityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSEgitim301_Presentation
{
    public partial class FrmProduct: Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EFProductDal());
            _categoryService = new CategoryManager(new EFCategoryDal());
        }
        
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductID.Text);
            var delvalues = _productService.TGetById(id);
            _productService.TDelete(delvalues);
            MessageBox.Show("Silme İşlemi Başarılı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryID = int.Parse(comboCategory.SelectedValue.ToString());
            product.ProductName = txtProductName.Text;
            product.ProductPrice = decimal.Parse(txtProductPrice.Text);
            product.ProductStatus = int.Parse(txtProductStock.Text);
            product.ProductDescription = txtProductDescription.Text;
            _productService.TInsert(product);
            MessageBox.Show("Eklem İşlemi Başarılı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnGetbyID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductID.Text);
            var values = _productService.TGetById(id);
            dataGridView1.DataSource = values;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductID.Text);
            var updatedValue = _productService.TGetById(id);
            updatedValue.CategoryID = int.Parse(comboCategory.SelectedValue.ToString());
            updatedValue.ProductName = txtProductName.Text;
            updatedValue.ProductPrice = decimal.Parse(txtProductPrice.Text);
            updatedValue.ProductStatus = int.Parse(txtProductStock.Text);
            updatedValue.ProductDescription = txtProductDescription.Text;
            _productService.TUpdate(updatedValue);
            MessageBox.Show("Güncelleme İşlemi Başarılı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            comboCategory.DataSource = values;
            comboCategory.DisplayMember = "CategoryName";
            comboCategory.ValueMember = "CategoryID";
            

        }
    }
}
