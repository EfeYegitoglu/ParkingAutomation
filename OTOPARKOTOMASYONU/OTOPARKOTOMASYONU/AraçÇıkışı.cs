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
    public partial class AraçÇıkışı : Form
    {
        public AraçÇıkışı()
        {
            InitializeComponent();
        }
        // Sql bağlantısını kurar.
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QLFEP4N;Initial Catalog=OtoparOtomasyon;Integrated Security=True");

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();// Bağlantıyı açar.
            // araç_otopark_kaydı tablosunun verilerine ulaşır.
            SqlCommand komut = new SqlCommand("select *from araç_otopark_kaydı where parkyeri='" + comboParkYeri.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtParkYeri2.Text = read["parkyeri"].ToString();
                txtTc.Text = read["tc"].ToString();
                txtAd.Text = read["ad"].ToString();
                txtSoyad.Text = read["soyad"].ToString();        // Park yerine ait bilgileri yazdırır
                txtMarka.Text = read["marka"].ToString();
                txtSeri.Text = read["seri"].ToString();
                txtPlaka.Text = read["plaka"].ToString();
                lblGirişTarihi.Text =read["tarih"].ToString();
            }
            
            baglanti.Close();
            DateTime geliş, çıkış;
            geliş = DateTime.Parse(lblGirişTarihi.Text); // Giriş tarihi
            çıkış = DateTime.Parse(lblÇıkşTarihi.Text);  // Çıkış tarihi
            TimeSpan fark;
            fark =  çıkış - geliş;
            lblSüre.Text = fark.TotalHours.ToString("0.00");        //Süre hesaplama

            lblToplamTutar.Text = (double.Parse(lblSüre.Text) * (1.5)).ToString("0.00");   // Toplam tutar hesaplama

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

       

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AraçÇıkışı_Load(object sender, EventArgs e)
        {
            DoluYerler(); // Metotu çağırır.
            Plakalar();  // Metotu çağırır
            timer1.Enabled = true;  // Zamanı döndürür.

        }

        private void Plakalar()
        {
            baglanti.Open();
            //araç_ototpark_kaydına ulaşır. 
            SqlCommand komut = new SqlCommand("select *from araç_otopark_kaydı ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboPlaka.Items.Add(read["plaka"].ToString());  //Park bilgilerine plaka aratır.
            }
            baglanti.Close();
        }

        private void DoluYerler()
        {
            baglanti.Open();
            // araç durumuna bağlanır durumu DOLU olanları alır
            SqlCommand komut = new SqlCommand("select *from araçdurumu where durumu='DOLU' ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboParkYeri.Items.Add(read["parkyeri"].ToString()); //Durumu dolu olan park alanını gösterir
            }
            baglanti.Close();
        }

        private void ComboPlaka_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            // araç_otopark_kaydı plakası girilenleri alır
            SqlCommand komut = new SqlCommand("select *from araç_otopark_kaydı where plaka='"+comboPlaka.SelectedItem+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtParkYeri.Text=read["parkyeri"].ToString();  //Park yeri bilgisini yazdırır
            }
            baglanti.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblÇıkşTarihi.Text = DateTime.Now.ToString(); //Zamanı gösterir
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            // plakayı veritabanından siler
            SqlCommand komut= new SqlCommand("delete from araç_otopark_kaydı where plaka='" + txtPlaka.Text + "' ",baglanti);
            komut.ExecuteNonQuery();
            //parkyerini BOŞ olarak günceller
            SqlCommand komut2 = new SqlCommand("update  araçdurumu set durumu='BOŞ' where parkyeri='" + txtParkYeri2.Text + "' ",baglanti);
            komut2.ExecuteNonQuery();
            // Çıkışı yapılan veriler satış llistesine aktarılır.
            SqlCommand komut3 = new SqlCommand("insert into satış(parkyeri,plaka,geliş_tarihi,çıkış_tarihi,süre,tutar) values(@parkyeri,@plaka,@geliş_tarihi,@çıkış_tarihi,@süre,@tutar)", baglanti);
            komut3.Parameters.AddWithValue("@parkyeri", txtParkYeri2.Text);
            komut3.Parameters.AddWithValue("@plaka", txtPlaka.Text);
            komut3.Parameters.AddWithValue("@geliş_tarihi", lblGirişTarihi.Text);  //Parametre olarak listelenir
            komut3.Parameters.AddWithValue("@çıkış_tarihi", lblÇıkşTarihi.Text);          
            komut3.Parameters.AddWithValue("@süre", double.Parse(lblSüre.Text));
            komut3.Parameters.AddWithValue("@tutar", double.Parse(lblToplamTutar.Text));
            komut3.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("ARAÇ ÇIKIŞI YAPILDI");
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                    txtParkYeri.Text = "";               //İşlemden sonra kutucuklar temizlenir
                    comboParkYeri.Text = "";
                    comboPlaka.Text = "";
                }
            }
            comboPlaka.Items.Clear();
            comboParkYeri.Items.Clear();
            DoluYerler();    //Metot çağırılır           //Bilgiler güncellenir.
            Plakalar();      // Metot çağırılır


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
