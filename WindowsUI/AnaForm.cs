using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogicLayer;
using Entities;

namespace WindowsUI
{
    public partial class AnaForm : Form
    {
        BLL bll;
        public AnaForm()
        {
            InitializeComponent();
            bll = new BLL();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            ListeGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int sonuc = bll.YeniKayit(txt_isim.Text,txt_soyisim.Text,txt_telefonI.Text, txt_telefonII.Text, txt_telefonIII.Text,
               txt_aciklama.Text,txt_email.Text,txt_adres.Text,txt_webadres.Text
               );
            if(sonuc > 0)
            {
                MessageBox.Show("Yeni Kayıt Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ListeGetir();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ListeGetir()
        {
            List<Rehber> liste = bll.ListeGetir();
            if(liste.Count > 0 && Liste != null)
            {
                Liste.DataSource = liste;
            }
        }

        private void Liste_DoubleClick(object sender, EventArgs e)
        {
            ListBox item = (ListBox)sender;
            Rehber K = (Rehber)item.SelectedItem;
            txt_guncel_isim.Text = K.isim;
            txt_guncel_soyisim.Text=K.soyisim;
            txt_guncel_telefonI.Text = K.telefonI;
            txt_guncel_telefonII.Text = K.telefonII;
            txt_guncel_telefonIII.Text = K.telefonIII;
            txt_guncel_webadres.Text = K.webadres;
            txt_guncel_email.Text = K.emailadres;
            txt_guncel_aciklama.Text = K.aciklama;
            txt_guncel_adres.Text=K.adres;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Guid ID = ((Rehber)Liste.SelectedItem).ID;
            int sonuc = bll.KayitSil(ID);
            if(sonuc > 0)
            {
                ListeGetir();
                MessageBox.Show("Kayıt Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt Silinemedi","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guid ID = ((Rehber)Liste.SelectedItem).ID;
            int sonuc = bll.KayitDuzenle(ID,txt_guncel_isim.Text,txt_guncel_soyisim.Text,txt_guncel_telefonI.Text,txt_guncel_telefonII.Text,txt_guncel_telefonIII.Text
                ,txt_guncel_aciklama.Text,txt_guncel_email.Text,txt_guncel_adres.Text,txt_guncel_webadres.Text);
            if(sonuc > 0)
            {
                ListeGetir();
                MessageBox.Show("Güncelleme Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncelleme Başarısız","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
