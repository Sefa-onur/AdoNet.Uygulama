using Entities;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogicLayer
{
    public class DLL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        int returnvalue;

        public DLL()
        {
            con = new SqlConnection("data source=.; initial catalog = TelefonRehberi; user Id = sa;password=3394320;");
        }
        public void BaglatiAyarla()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }

        public int YeniKayit(Rehber k)
        {
            try
            {
                cmd = new SqlCommand("insert into Rehber (ID,isim,soyisim,telefonI,telefonII,telefonIII,aciklama,adres,webadres,emailadres) values (@ID,@isim,@soyisim,@telefonI,@telefonII,@telefonIII,@aciklama,@adres,@webadres,@emailadres)", con);
                cmd.Parameters.Add("ID",SqlDbType.UniqueIdentifier).Value = k.ID;
                cmd.Parameters.Add("isim", SqlDbType.NVarChar).Value = k.isim;
                cmd.Parameters.Add("soyisim", SqlDbType.NVarChar).Value = k.soyisim;
                cmd.Parameters.Add("telefonI",SqlDbType.NVarChar).Value = k.telefonI;
                cmd.Parameters.Add("telefonII", SqlDbType.NVarChar).Value = k.telefonII;
                cmd.Parameters.Add("telefonIII",SqlDbType.NVarChar).Value = k.telefonIII;
                cmd.Parameters.Add("aciklama",SqlDbType.NVarChar).Value=k.aciklama;
                cmd.Parameters.Add("adres", SqlDbType.NVarChar).Value = k.adres;
                cmd.Parameters.Add("webadres", SqlDbType.NVarChar).Value = k.webadres;
                cmd.Parameters.Add("emailadres", SqlDbType.NVarChar).Value = k.emailadres;
                BaglatiAyarla();
                returnvalue = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglatiAyarla();
            }
            return returnvalue;
        }
        public int SistemKontrol(Kullanici K)
        {
            try
            {
                BaglatiAyarla();
                cmd = new SqlCommand("select count(*) from kisiler where KullaniciAdi = @KullaniciAdi and Sifre = @Sifre",con);
                cmd.Parameters.Add("KullaniciAdi", SqlDbType.NVarChar).Value = K.Kullaniciadi;
                cmd.Parameters.Add("Sifre", SqlDbType.NVarChar).Value = K.Sifre;
                returnvalue = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                BaglatiAyarla();
            }
            return returnvalue;
        }

        public int KayitDuzenle(Rehber K)
        {
            try
            {
                
                cmd = new SqlCommand("update Rehber set isim = @isim, soyisim = @soyisim, telefonI = @telefonI, telefonII = @telefonII, telefonIII = @telefonIII, aciklama = @aciklama, webadres = @webadres,adres = @adres,emailadres = @emailadres where ID = @ID",con);
                cmd.Parameters.Add("isim", SqlDbType.NVarChar).Value = K.isim;
                cmd.Parameters.Add("soyisim", SqlDbType.NVarChar).Value = K.soyisim;
                cmd.Parameters.Add("telefonI", SqlDbType.NVarChar).Value = K.telefonI;
                cmd.Parameters.Add("telefonII", SqlDbType.NVarChar).Value = K.telefonII;
                cmd.Parameters.Add("telefonIII", SqlDbType.NVarChar).Value = K.telefonIII;
                cmd.Parameters.Add("aciklama", SqlDbType.NVarChar).Value = K.aciklama;
                cmd.Parameters.Add("webadres", SqlDbType.NVarChar).Value = K.webadres;
                cmd.Parameters.Add("adres", SqlDbType.NVarChar).Value = K.adres;
                cmd.Parameters.Add("emailadres", SqlDbType.NVarChar).Value = K.emailadres;
                cmd.Parameters.Add("ID", SqlDbType.UniqueIdentifier).Value = K.ID;
                BaglatiAyarla();
                returnvalue = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                BaglatiAyarla();
            }
            return returnvalue;
        }

        public int KayitSil(Guid ID)
        {
            int sonuc = 0;
            try
            {
                BaglatiAyarla();
                cmd = new SqlCommand("delete Rehber where ID = @ID",con);
                cmd.Parameters.Add("ID", SqlDbType.UniqueIdentifier).Value = ID;
                sonuc = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                BaglatiAyarla();
            }
            return sonuc;
        }

        public SqlDataReader ListeGetir()
        {
                BaglatiAyarla();
                cmd = new SqlCommand("select * from Rehber", con);
                return cmd.ExecuteReader();
        }

        public SqlDataReader ListeGetirID(Guid ID)
        {
            cmd = new SqlCommand("select * from Rehber where ID = @ID", con);
            cmd.Parameters.Add("ID",SqlDbType.UniqueIdentifier).Value = ID;
            BaglatiAyarla();
            return cmd.ExecuteReader();
        }
    }
}
