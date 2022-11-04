using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Kiralama
{
    class Program
    {
        static void Main(string[] args)
        {
            string sec;
            do
            {
                Console.WriteLine("1.Listele");
                Console.WriteLine("2.Ekle");
                Console.WriteLine("3.Güncelle");
                Console.WriteLine("4.Sil");
                Console.WriteLine("Seçiminiz:");
                sec = Console.ReadLine();

                if (sec == "1")
                {
                    kirala nesne = new kirala();
                    nesne.Listele();
                }
                else if (sec == "2")
                {
                    kirala nesne = new kirala();
                    nesne.Ekle();
                    //nesne.Listele();
                    // Listele();
                }
                else if (sec == "3")
                {
                    kirala nesne = new kirala();
                    nesne.Güncelle();
                    //nesne.Listele();
                    // Listele();
                }
                else if (sec == "4")
                {
                    kirala nesne = new kirala();
                    nesne.Sil();
                    //nesne.Listele();
                    // Listele();
                }
                Console.ReadLine();
            } while (true);
        }
    }

    interface arac
    {
        void Ekle();
        void Listele();
        void Güncelle();

        void Sil();
    }

    class kirala : arac
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public void Ekle()
        {
            con = new SqlConnection();

            con.ConnectionString =
                ("Data Source=.\\SQLEXPRESS; Initial Catalog=kiralama; Integrated Security=True");
            con.Open();


            Console.WriteLine("Marka Giriniz: ");
            string Marka = Console.ReadLine();
            Console.WriteLine("Model Giriniz: ");
            string Model = Console.ReadLine();

            string komut = "insert into kiralama (Marka,Model) values ('" + Marka + "','" + Model + "')";

            cmd = new SqlCommand();
            cmd.CommandText = komut;
            cmd.Connection = con;
            int sonuc = cmd.ExecuteNonQuery();  
            if (sonuc == 1)
                Console.WriteLine("Veritabanına Eklendi");
            else
                Console.WriteLine("Eklenemedi!");
        }

        public void Listele()
        {
            con = new SqlConnection();

            con.ConnectionString =
                ("Data Source=.\\SQLEXPRESS; Initial Catalog=kiralama; Integrated Security=True");
            con.Open();

            string komut = "SELECT [Marka],[Model] FROM [kiralama].[dbo].[kiralama]";

            cmd = new SqlCommand();
            cmd.CommandText = komut;
            cmd.Connection = con;
            int sonuc = cmd.ExecuteNonQuery();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                Console.WriteLine(dr[0] + "  <->  " + dr[1] + "" );

            }
            con.Close();


        }

        public void Güncelle()
        {   
            con = new SqlConnection();

            con.ConnectionString =
                ("Data Source=.\\SQLEXPRESS; Initial Catalog=kiralama; Integrated Security=True");
            con.Open();

            Console.WriteLine("Marka Giriniz: ");
            string Marka = Console.ReadLine();

            Console.WriteLine("Model Giriniz: ");
            string Model = Console.ReadLine();  

            Console.WriteLine("Id Giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string komut = "update kiralama SET Marka='"+Marka+"', Model='"+Model+"' where id='"+id+"' ";

            cmd = new SqlCommand();
            cmd.CommandText = komut;
            cmd.Connection = con;
            int sonuc = cmd.ExecuteNonQuery();

            if (sonuc == 1)
                Console.WriteLine("Veritabanı Güncellendi!");
            else
                Console.WriteLine("Güncellenemedi...");


        }

        public void Sil()
        {   
            con = new SqlConnection();

            con.ConnectionString =
                ("Data Source=.\\SQLEXPRESS; Initial Catalog=kiralama; Integrated Security=True");
            con.Open();


            Console.WriteLine("İd Giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string komut = "delete from kiralama where id='" + id + "' ";

            cmd = new SqlCommand();
            cmd.CommandText = komut;
            cmd.Connection = con;
            int sonuc = cmd.ExecuteNonQuery();
            if (sonuc == 1)
                Console.WriteLine("Seçtiğiniz ID Silindi!");
            else
                Console.WriteLine("Silinemedi!");
        }
    }

}
