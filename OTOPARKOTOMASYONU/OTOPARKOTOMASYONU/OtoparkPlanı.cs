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
    public partial class OtoparkPlanı : Form
    {
        public OtoparkPlanı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QLFEP4N;Initial Catalog=OtoparOtomasyon;Integrated Security=True");

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Button46_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlDataReader oku;
        SqlCommand komut;
        private void OtoparkPlanı_Load(object sender, EventArgs e)
        {

            //DoluParkYeri();

            //Burası doğru çalışıyor
            //string deger = "";

            baglanti.Open();
            komut = new SqlCommand("select * from araç_otopark_kaydı", baglanti);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (oku["parkyeri"].ToString() == "A 1       ")
                {
                    A1.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 2       ")
                {
                    A2.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 3       ")
                {
                    A3.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 4       ")
                {
                    A4.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 5       ")
                {
                    A5.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 6       ")
                {
                    A6.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 7       ")
                {
                    A7.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 8       ")
                {
                    A8.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 9       ")
                {
                    A9.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 10      ")
                {
                    A10.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 11      ")
                {
                    A1.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 12      ")
                {
                    A12.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "A 13      ")
                {
                    A13.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 1       ")
                {
                    B1.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 2       ")
                {
                    B2.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 3       ")
                {
                    B3.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 4       ")
                {
                    B4.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 5       ")
                {
                    B5.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 6       ")
                {
                    B6.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 7       ")
                {
                    B7.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 8       ")
                {
                    B8.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 9       ")
                {
                    B9.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 10      ")
                {
                    B10.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 11      ")
                {
                    B11.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 12      ")
                {
                    B12.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 13      ")
                {
                    B13.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 14      ")
                {
                    B14.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 15      ")
                {
                    B15.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "B 16      ")
                {
                    B16.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 1       ")
                {
                    C1.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 2       ")
                {
                    C2.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 3       ")
                {
                    C3.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 4       ")
                {
                    C4.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 5       ")
                {
                    C5.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 6       ")
                {
                    C6.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 7       ")
                {
                    C7.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 8       ")
                {
                    C8.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 9       ")
                {
                    C9.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 10      ")
                {
                    C10.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 11      ")
                {
                    C11.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 12      ")
                {
                    C12.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 13      ")
                {
                    C13.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 14      ")
                {
                    C14.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 15      ")
                {
                    C15.BackColor = Color.Red;
                }
                if (oku["parkyeri"].ToString() == "C 16      ")
                {
                    C16.BackColor = Color.Red;
                }
            }
            baglanti.Close();
            
                /*baglanti.Open();
                komut = new SqlCommand("select * from araç_otopark_kaydı ", baglanti);
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    if (oku["parkyeri"].ToString() == "A 2       ")
                    {
                        A2.BackColor = Color.Red;
                    }

                }
                baglanti.Close();*/



                /* baglanti.Open();
                 SqlCommand komut = new SqlCommand("select * from araç_otopark_kaydı", baglanti);
                 SqlDataReader read = komut.ExecuteReader();
                 while (read.Read())
                 {
                     if(A1.Text==read["parkyeri"].ToString())
                     {
                         A1.BackColor = Color.Red;
                     }
                 }
                 baglanti.Close();*/


        }

            /*private void DoluParkYeri()
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from araçdurumu", baglanti);
                SqlDataReader read = komut.ExecuteReader();

                while (read.Read())
                {


                    foreach (Control item in Controls)
                    {

                        if (item.Text== read["parkyeri"].ToString()&&item.Text==read["durumu"].ToString())
                        {
                            if (item is Button)
                            {
                                item.BackColor = Color.Red;
                            }
                        }
                    }
                }
                baglanti.Close();
            }
            */
            private void Button10_Click(object sender, EventArgs e)
            {

            }

            private void Button2_Click(object sender, EventArgs e)
            {




            }
        }
    }



