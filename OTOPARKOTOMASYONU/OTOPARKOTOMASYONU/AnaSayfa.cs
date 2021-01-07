using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTOPARKOTOMASYONU
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Otomasyonu kapatır
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Araç giriş sayfasına yönlendirir.
            this.Hide();
            AraçGirişi giriş = new AraçGirişi();
            giriş.ShowDialog();
            this.Show();
            
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            OtoparkPlanı otoparkPlanı = new OtoparkPlanı();
            otoparkPlanı.ShowDialog();
            this.Show();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Araç çıkış sayfasına yönlendirir.
            this.Hide();
            AraçÇıkışı araccıksı = new AraçÇıkışı();
            araccıksı.ShowDialog();
            this.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {

           

        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            // Satış sayfasına yönlendirir.
            this.Hide();
            Satış satış = new Satış();
            satış.ShowDialog();
            this.Show();
        }

       
    }
}
