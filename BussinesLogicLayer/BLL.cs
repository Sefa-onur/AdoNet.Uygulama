using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLogicLayer;
using Entities;

namespace BussinesLogicLayer
{
    public class BLL
    {
        DLL dll;
        public BLL()
        {
            dll = new DLL();
        }
        public int YeniKayit(string isim,string soyisim,string telefonI, string telefonII, string telefonIII,string aciklama,
            string emailadres,string adres, string webadres)
        {
            int sonuc = 0;
            if(!string.IsNullOrEmpty(isim) && !string.IsNullOrEmpty(soyisim) && !string.IsNullOrEmpty(telefonI))
            {
                Rehber kayit = new Rehber();
                kayit.ID = Guid.NewGuid();
                kayit.isim = isim;
                kayit.soyisim = soyisim;
                kayit.telefonI = telefonI;
                kayit.telefonII = telefonII;
                kayit.telefonIII = telefonIII;
                kayit.aciklama = aciklama;
                kayit.webadres = webadres;
                kayit.emailadres = emailadres;
                kayit.adres = adres;
                sonuc = dll.YeniKayit(kayit);
            }
            else
            {
                sonuc = -1;
            }
            return sonuc;
        }
        public int SistemKontrol(string KullaniciAdi,string Sifre)
        {
            int sonuc = 0;
            if(!string.IsNullOrEmpty (KullaniciAdi) && !string.IsNullOrEmpty(Sifre))
            {
                Kullanici K = new Kullanici();
                K.Kullaniciadi = KullaniciAdi;
                K.Sifre = Sifre;
                sonuc = dll.SistemKontrol(K);
            }
            else
            {
                sonuc = -1;
            }
            return sonuc;
        }

        public int KayitDuzenle(Guid ID,string isim, string soyisim, string telefonI, string telefonII, string telefonIII, string aciklama,
            string emailadres, string adres, string webadres)
        {
            int sonuc = 0;
            if (!string.IsNullOrEmpty (isim) && !string.IsNullOrEmpty (soyisim) && !string.IsNullOrEmpty (telefonI) && ID != Guid.Empty)
            {
                Rehber kayit = new Rehber();
                kayit.isim = isim;
                kayit.soyisim = soyisim;
                kayit.telefonI = telefonI;
                kayit.telefonII = telefonII;
                kayit.telefonIII = telefonIII;
                kayit.aciklama = aciklama;
                kayit.webadres = webadres;
                kayit.emailadres = emailadres;
                kayit.adres = adres;
                sonuc = dll.KayitDuzenle (kayit);
            }
            else
            {
                sonuc = -1;
            }
            return sonuc;
        }
        public int KayitSil(Guid ID)
        {
            int sonuc = 0;
            if(ID != Guid.Empty)
            {
                sonuc = dll.KayitSil(ID);
                return sonuc;
            }
            else
            {
                sonuc = -1;
            }
            return sonuc;
        }
        public List<Rehber> ListeGetir()
        { 
            List<Rehber> list = new List<Rehber>();
            try
            {
                SqlDataReader data = dll.ListeGetir();                
                while (data.Read())
                {
                    Rehber k = new Rehber();
                    k.ID = data.IsDBNull(0) ? Guid.Empty : data.GetGuid(0);
                    k.isim = data.IsDBNull(1)?String.Empty : data.GetString(1);
                    k.soyisim = data.IsDBNull(2)?String.Empty : data.GetString(2);
                    k.telefonI = data.IsDBNull(3)?String.Empty : data.GetString(3);
                    k.telefonII = data.IsDBNull(3) ? String.Empty : data.GetString(4);
                    k.telefonIII = data.IsDBNull(4) ? String.Empty : data.GetString(4);
                    k.aciklama = data.IsDBNull(5) ? String.Empty : data.GetString(5);
                    k.webadres = data.IsDBNull(6) ? String.Empty : data.GetString(6);
                    k.adres = data.IsDBNull(7) ? String.Empty : data.GetString(7);
                    k.emailadres = data.IsDBNull(8) ? String.Empty : data.GetString(8);
                    list.Add(k);
                }
                data.Close();
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                dll.BaglatiAyarla();
            }
            return list;
        }

        public Rehber ListeGetirID(Guid ID)
        {
            Rehber item = new Rehber();
            try
            {
                SqlDataReader data = dll.ListeGetirID(ID);
                while (data.Read())
                {
                    Rehber k = new Rehber();
                    k.ID = data.IsDBNull(0) ? Guid.Empty : data.GetGuid(0);
                    k.isim = data.IsDBNull(1) ? String.Empty : data.GetString(1);
                    k.soyisim = data.IsDBNull(2) ? String.Empty : data.GetString(2);
                    k.telefonI = data.IsDBNull(3) ? String.Empty : data.GetString(3);
                    k.telefonII = data.IsDBNull(3) ? String.Empty : data.GetString(4);
                    k.telefonIII = data.IsDBNull(4) ? String.Empty : data.GetString(4);
                    k.aciklama = data.IsDBNull(5) ? String.Empty : data.GetString(5);
                    k.webadres = data.IsDBNull(6) ? String.Empty : data.GetString(6);
                    k.adres = data.IsDBNull(7) ? String.Empty : data.GetString(7);
                    k.emailadres = data.IsDBNull(8) ? String.Empty : data.GetString(8);
                    item = k;
                }
                data.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.BaglatiAyarla();
            }
            return item;
        }
    }
}
