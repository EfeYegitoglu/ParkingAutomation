using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTOPARKOTOMASYONU
{
    public partial class Satış : Form
    {
        public Satış()
        {
            InitializeComponent();
        }
        //Sql baglantısı kurulur
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QLFEP4N;Initial Catalog=OtoparOtomasyon;Integrated Security=True");
        DataSet daset = new DataSet();

        private void Satış_Load(object sender, EventArgs e)
        {
            SatışlarıListele();
            Hesapla();                   //Metotlar çağırılır
        }

        private void Hesapla()
        {
            baglanti.Open();
            //satıştan tutar çekilir ve toplam tutar olarak yazdırılır
            SqlCommand komut = new SqlCommand("select sum(tutar) from satış", baglanti);
            label1.Text = "Toplam Tutar: " + komut.ExecuteScalar() + " TL";
            baglanti.Close();
        }

        private void SatışlarıListele()
        {
            baglanti.Open();
            //Listeleme için gerekli bağlantı kurulur
            SqlDataAdapter adtr = new SqlDataAdapter("select *from satış", baglanti);
            adtr.Fill(daset, "satış");
            dataGridView1.DataSource = daset.Tables["satış"];
            baglanti.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();  //Sayfayı kapatır
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
