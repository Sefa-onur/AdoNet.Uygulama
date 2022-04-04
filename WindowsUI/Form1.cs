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

namespace WindowsUI
{
    public partial class Form1 : Form
    {
        BLL bll;
        public Form1()
        {
            InitializeComponent();
            bll = new BLL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sonuc =  bll.SistemKontrol(txt_KullaniciAdi.Text, txt_Sifre.Text);
            if(sonuc > 0)
            {
                AnaForm anaForm = new AnaForm();
                anaForm.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
