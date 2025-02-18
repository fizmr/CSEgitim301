using CSEgitim301_BussinesLayer.Abstract;
using CSEgitim301_BussinesLayer.Concrete;
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
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EFCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Kategori Başarıyla Eklendi!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryID.Text);
            var delvalues = _categoryService.TGetById(id);
            _categoryService.TDelete(delvalues);
            MessageBox.Show("Silme İşlemi Başarılı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtCategoryID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            int update = int.Parse(txtCategoryID.Text);
            var updatedValue = _categoryService.TGetById(update);
            updatedValue.CategoryName = txtCategoryName.Text;
            updatedValue.CategoryStatus = true;
            _categoryService.TUpdate(updatedValue);
            MessageBox.Show("Güncelleme İşlemi Başarılı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnGetbyID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryID.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1.DataSource = values;
        }
    }
}
