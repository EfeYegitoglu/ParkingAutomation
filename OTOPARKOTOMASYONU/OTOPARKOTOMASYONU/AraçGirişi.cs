using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OTOPARKOTOMASYONU
{
    public partial class AraçGirişi : Form
    {
        public AraçGirişi()
        {
            InitializeComponent();
        }
        // Sql bağlantısı kurar
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QLFEP4N;Initial Catalog=OtoparOtomasyon;Integrated Security=True");

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void AraçGirişi_Load(object sender, EventArgs e)
        {
            // Boş araçlar metodunu çağırır.
            BoşAraçlar();

            // Marka metodunu çğırır
            Marka();
           

        }

        private void Marka()
        {
            baglanti.Open(); // Sql bağlantısını açar.
            SqlCommand komut = new SqlCommand("select marka from markabilgileri ", baglanti); // Markabilgileri bölümündeki markalara ulaşır 
            SqlDataReader read = komut.ExecuteReader(); // Verileri okur. 
            while (read.Read())
            {
                comboMARKA.Items.Add(read["marka"].ToString()); // Kutucuka markaları girer. 
            }
            baglanti.Close();
        }

        private void BoşAraçlar()
        {
            baglanti.Open(); //Sql bağlantısını açar.
            SqlCommand komut = new SqlCommand("select *from araçdurumu WHERE durumu='BOŞ'", baglanti); // araç durumuna bağlanır, durumu BOŞ olanları seçer.
            SqlDataReader read = komut.ExecuteReader(); // Verileri okur.
            while (read.Read())
            {
                comboPARK.Items.Add(read["parkyeri"].ToString()); // Park yeri bilgilerini kutuya ekler.
                
            }
            baglanti.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open(); // Sql bağlantısını açar.

            // Verileri parametre olarak alır ve araç_otopark_kaydı tablosuna ekler.
            SqlCommand komut = new SqlCommand("insert into araç_otopark_kaydı(tc,ad,soyad,telefon,email,plaka,marka,seri,renk,parkyeri,tarih) values(@tc,@ad,@soyad,@telefon,@email,@plaka,@marka,@seri,@renk,@parkyeri,@tarih)", baglanti);
            komut.Parameters.AddWithValue("@tc", TC.Text);
            komut.Parameters.AddWithValue("@ad", AD.Text);
            komut.Parameters.AddWithValue("@soyad", SOYAD.Text);
            komut.Parameters.AddWithValue("@telefon", TELEFON.Text);
            komut.Parameters.AddWithValue("@email", email.Text);          // Veriler parametre olarak alınır
            komut.Parameters.AddWithValue("@plaka", PLAKA.Text);
            komut.Parameters.AddWithValue("@marka", comboMARKA.Text);
            komut.Parameters.AddWithValue("@seri", comboSERİ.Text);
            komut.Parameters.AddWithValue("@renk", RENK.Text);
            komut.Parameters.AddWithValue("@parkyeri", comboPARK.Text);
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

            komut.ExecuteNonQuery();

            // Kayıt yapılırken park alanı seçilince veri tabanında durumunu günceller.
            SqlCommand komut2 = new SqlCommand("update araçdurumu set durumu='DOLU' where parkyeri='" + comboPARK.SelectedItem + "'", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close(); // Sql bağlantısını kapatır.
            MessageBox.Show("Araç Kaydı Oluşturuldu", "KAYIT"); //Ekranda uyarı kutucuku çıkar
            comboPARK.Items.Clear(); // kutunun içini temizler.
            BoşAraçlar();  // Metotu çağırır.
            comboMARKA.Items.Clear(); //tunun içini temizler.
            Marka(); // Metotu çağırır
            comboSERİ.Items.Clear(); //Kutunun içini temizler.
            foreach ( Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox3.Controls)      // Kayıt işleminden sonra kutuların içini temizler
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox3.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Marka ekleme formunu açar.
            Marka marka = new Marka();
            marka.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //Seri ekleme formunu açar.
            Seri seri = new Seri();
            seri.ShowDialog();
        }

        private void ComboMARKA_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboSERİ.Items.Clear();// İçini temizler
            baglanti.Open(); //Sql bağlantısı açar.

            // Seri bilgilerinden marka ve seri seçer 
            SqlCommand komut = new SqlCommand("select marka,seri from seribilgileri where marka='"+comboMARKA.SelectedItem+"' ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboSERİ.Items.Add(read["seri"].ToString());  // Seri ekleme işlemini yapar.
            }
            baglanti.Close();
        }

        private void comboPARK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
