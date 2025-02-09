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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEF_TravelDBEntities db = new EgitimKampiEF_TravelDBEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Toplam lokasyon sayısı
            lblLocationCount.Text = db.LocationSet.Count().ToString();

            #endregion
            #region Toplam Kapasite Sayısı
            lbltotalCapacity.Text = db.LocationSet.Sum(x => x.Capacity).ToString();
            #endregion
            #region Toplam Rehber Sayısı
            lbltotalGuide.Text = db.Guide.Count().ToString();
            #endregion
            #region Tur Başına Ortalama Kapasite
            lblavgCapacity.Text = db.LocationSet.Average(x => x.Capacity).ToString();
            #endregion
            #region Tur Başına Ortalama Ücret
            lblavgtourPrice.Text = db.LocationSet.Average(x =>(decimal?) x.Price)?.ToString("0.00") + "₺";
            #endregion
            #region Eklenen Son Ülke
            int lastcountryid = db.LocationSet.Max(x => x.LocationID);
            lbladdedlastCountry.Text = db.LocationSet.Where(x => x.LocationID == lastcountryid).Select(y => y.Country).FirstOrDefault();
            #endregion
            #region Kapadokya Gezi Kapasitesi
            lblCapacodiaTourCapacity.Text = db.LocationSet.Where(x => x.City == "Nevşehir-Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            #endregion
            #region Türkiyedeki Ortalama Kapasite
            lblTurkiyeavgCapacity.Text = db.LocationSet.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();
            #endregion
            #region En Çok Tercih Edilen Rehber Adı
            int mostpreferredguideid = db.Guide.GroupBy(x => x.GuideID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            
            lblMostSelectetGuide.Text = db.Guide.Where(x => x.GuideID == mostpreferredguideid).Select(y => new
            {
                FullName = y.GuideName + " " + y.GuideSurname
            }).FirstOrDefault().FullName;


            #endregion
            #region En Yüksek Kapasiteli Tur
            var maxcapacitytourid = db.LocationSet.Max(x => x.Capacity);
            lblMaxCapacityTour.Text = db.LocationSet.Where(x => x.Capacity == maxcapacitytourid).Select(y => y.City+"/"+y.Country).FirstOrDefault();
            #endregion
            #region En Yüksek Ücretli Tur
            var maxpricetourid = db.LocationSet.Max(x => x.Price);
            lblMostExpensiveTour.Text = db.LocationSet.Where(x => x.Price == maxpricetourid).Select(y => y.City + "/" + y.Country).FirstOrDefault();
            #endregion
            #region En Düşük Ücretli Tur
            var minpricetourid = db.LocationSet.Min(x => x.Price);
            lblMostCheapTour.Text = db.LocationSet.Where(x => x.Price == minpricetourid).Select(y => y.City + "/" + y.Country).FirstOrDefault();
            #endregion
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblavgtourPrice_Click(object sender, EventArgs e)
        {

        }

        private void lblTurkiyeavgCapacity_Click(object sender, EventArgs e)
        {

        }

        private void lblMostCheapTour_Click(object sender, EventArgs e)
        {

        }
    }
}
