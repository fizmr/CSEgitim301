using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSEgitim301.EFProject
{
    public partial class FrmLocation : Form
    {

        EgitimKampiEF_TravelDBEntities db = new EgitimKampiEF_TravelDBEntities();

        public FrmLocation()
        {
            InitializeComponent();
        }       
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.LocationSet.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {                
                FullName = x.GuideName + " " + x.GuideSurname,x.GuideID
            }).ToList();
            comboGuide.DisplayMember = "FullName";
            comboGuide.ValueMember = "GuideID";
            comboGuide.DataSource = values;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Capacity = Convert.ToByte(numCapacity.Value.ToString());
            location.Price = Convert.ToDecimal(txtPrice.Text);
            location.DayNight = txtDN.Text;
            location.GuideID = int.Parse(comboGuide.SelectedValue.ToString());
            db.LocationSet.Add(location);
            db.SaveChanges();
            MessageBox.Show("Location Added Successfully !", "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var dellocation = db.LocationSet.Find(id);
            db.LocationSet.Remove(dellocation);
            db.SaveChanges();
            MessageBox.Show("Location Deleted Successfully !", "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            var updatelocation = db.LocationSet.Find(id);
            updatelocation.City = txtCity.Text;
            updatelocation.Country = txtCountry.Text;
            updatelocation.Capacity = Convert.ToByte(numCapacity.Value.ToString());
            updatelocation.Price = Convert.ToDecimal(txtPrice.Text);
            updatelocation.DayNight = txtDN.Text;
            updatelocation.GuideID = int.Parse(comboGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Location Updated Successfully !", "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtDN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
