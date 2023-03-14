using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace BOOKSTORE
{
    public class dbclass
    {

        static string adres = @"Data Source=LAPTOP-G26L2242;Initial Catalog=kutuphaneyeni;Integrated Security=True";
        static SqlConnection baglanti = new SqlConnection(adres);


        #region yazar
        public static DataSet vericek()
        {
            baglanti.Open();
            string sorgu = "select yazarno as YAZAR_NO,ad as İSİM, soyad as SOYAD from yazar";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            DataSet ds = new DataSet();
            da.Fill(ds);
            baglanti.Close();


            return ds;

        }
        public void kaydet(string i, string s)
        {
            baglanti.Open();
            string query = "insert into yazar(ad,soyad) values(@p1,@p2)";
            SqlCommand cmd = new SqlCommand(query, baglanti);

            cmd.Parameters.AddWithValue("@p1", i);
            cmd.Parameters.AddWithValue("@p2", s);


            cmd.ExecuteNonQuery();
            baglanti.Close();

        }
        public void guncelle(string iy, string sy, int ny)
        {
            baglanti.Open();
            string sorgu = "update yazar set ad=@p1,soyad=@p2 where yazarno=@p3 ";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@p1", iy);
            cmd.Parameters.AddWithValue("@p2", sy);
            cmd.Parameters.AddWithValue("@p3", ny);
            cmd.ExecuteNonQuery();
            baglanti.Close();




        }
        #endregion


        #region kitap
        public static DataSet vericekkitap()
        {
            baglanti.Close();
            baglanti.Open();
            string sorgu = "select * from kitap";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            DataSet ds2 = new DataSet();
            da.Fill(ds2);
            baglanti.Close();


            return ds2;

        }
        public static void kaydetkitap(string a, int s, int p, int yn, int t)
        {
            try
            {

                //baglanti.Open();
                //string sor = "select yazarno from yazar";
                //SqlCommand yazarkontrol = new SqlCommand(sor, baglanti);

                //SqlDataAdapter da = new SqlDataAdapter(yazarkontrol);
                //DataSet ds = new DataSet();
                //da.Fill(ds);


                //string yazarsayi = "select count(yazarno) from yazar";
                //SqlCommand yzr = new SqlCommand(yazarsayi, baglanti);
                //SqlDataReader sdr = yzr.ExecuteReader();
                //yazarsayisi = sdr[0].ToString();


                //baglanti.Close();


                baglanti.Open();
                string sql = "insert into kitap(ad,sayfasayisi,puan,yazarno,turno) values(@p1,@p2,@p3,@p4,@p5)";
                SqlCommand cmd = new SqlCommand(sql, baglanti);
                cmd.Parameters.AddWithValue("@p1", a);
                cmd.Parameters.AddWithValue("@p2", s);
                cmd.Parameters.AddWithValue("@p3", p);
                cmd.Parameters.AddWithValue("@p4", yn);
                cmd.Parameters.AddWithValue("@p5", t);

                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("BAŞARILI");



            }
            catch
            {
                MessageBox.Show("AYNI NO LU YAZARI GİRİYOR OLABİLİRSİN DEİLKANLI");

            }



        }
        public void kitapguncelle(string a, int s, int p, int yn, int t, int kn)
        {
            baglanti.Open();
            string sorgu = "update kitap set ad=@p1,sayfasayisi=@p2,puan=@p3,yazarno=@p5,turno=@p6 where kitapno=@p7";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@p1", a);
            cmd.Parameters.AddWithValue("@p2", s);
            cmd.Parameters.AddWithValue("@p3", p);
            cmd.Parameters.AddWithValue("@p4", yn);
            cmd.Parameters.AddWithValue("@p5", t);
            cmd.Parameters.AddWithValue("@p6", t);
            cmd.Parameters.AddWithValue("@p7", kn);

            cmd.ExecuteNonQuery();
            baglanti.Close();

        }
        public void sil(int kn)
        {
            baglanti.Open();

            string sql = "DELETE FROM kitap WHERE kitapno=@p1";
            SqlCommand cmd = new SqlCommand(sql, baglanti);
            cmd.Parameters.AddWithValue("@p1", kn);
            cmd.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("SİLİNDİ");

        }
        #endregion



        public bool giris(string ad, string sf)
        {
            baglanti.Open();
            string sorgu = "select* from tblpersonel where kullaniciadi=@p1 and sifre=@p2  ";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@p1", ad);
            cmd.Parameters.AddWithValue("@p2", sf);
            SqlDataReader dr = cmd.ExecuteReader();
            bool deger;
            if (dr.Read())
            {
                home hm = new home();
                hm.Show();
                login lgn = new login();
                lgn.Hide();

                deger = true;

            }
            else
            {
                MessageBox.Show("kullanıcı adı veya sifre hatalıdır...");

                deger = false;


            }
            baglanti.Close();
            return deger;








        }
       
      
        #region admin_işlem
        public void siladmin(int id)
        {
            baglanti.Open();
            string sor = "delete from tblpersonel where id=@p1";
            SqlCommand cmd = new SqlCommand(sor,baglanti);
            cmd.Parameters.AddWithValue("@p1",id);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("SİLİNDİ...");


        }
        public static DataSet yoneticigoster()
        {
            baglanti.Open();
            string sorgu = "select * from tblpersonel ";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            return ds;

        }
        public void kaydetyonetici(string k, string s)
        {
            baglanti.Open();
            string sorgu = "insert into tblpersonel(kullaniciadi,sifre) values(@p1,@p2)";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("@p1", k);
            cmd.Parameters.AddWithValue("@p2", s);

            cmd.ExecuteNonQuery();
            baglanti.Close();






        }
        public int kacpersonelvar()
        {
            baglanti.Open();
            int sayi = 0;
            string sorgu = "select count(sifre) from tblpersonel";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                sayi = Convert.ToInt32(dr[0]);
            }
            baglanti.Close();
            return sayi;
        }
        public void adminguncelle(string a,string p, int id)
        {
            baglanti.Open();
            string sor = "update tblpersonel set kullaniciadi=@p1, sifre=@p2 where id=@p3";
            SqlCommand cmd = new SqlCommand(sor,baglanti);
            cmd.Parameters.AddWithValue("@p1",a);
            cmd.Parameters.AddWithValue("@p2", p);
            cmd.Parameters.AddWithValue("@p3",id);
            cmd.ExecuteNonQuery();
            baglanti.Close();



        }


        #endregion



    }
}

