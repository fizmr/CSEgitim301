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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EgitimKampiEF_TravelDBEntities db = new EgitimKampiEF_TravelDBEntities();
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EgitimKampiEF_TravelDBEntities db = new EgitimKampiEF_TravelDBEntities();
            Guide guide = new Guide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Eklendi !");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EgitimKampiEF_TravelDBEntities db = new EgitimKampiEF_TravelDBEntities();
            int id = Convert.ToInt32(txtID.Text);
            var updateguide = db.Guide.Find(id);
            updateguide.GuideName = txtName.Text;
            updateguide.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Güncellendi !","UYARI !",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            EgitimKampiEF_TravelDBEntities db = new EgitimKampiEF_TravelDBEntities();
            int id = Convert.ToInt32(txtID.Text);
            var delguide = db.Guide.Find(id);
            db.Guide.Remove(delguide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Silindi !");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            EgitimKampiEF_TravelDBEntities db = new EgitimKampiEF_TravelDBEntities();
            int id = Convert.ToInt32(txtID.Text);
            var values =db.Guide.Where(x => x.GuideID == id).ToList();
            dataGridView1.DataSource = values;


        }
    }
}
