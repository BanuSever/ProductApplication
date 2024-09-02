using ProductApp.Helpers;
using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    internal class Program
    {
        static void Main(string[]args)
        {
            var urun1 = new Product("Telefon", 7500, 1);
            var urun2 = new Product("Kulaklık", 1000, 5);
            var urun3 = new Product("Saat", 500);

            var urunler = new List<Product>();
            urunler.Add(urun1);
            urunler.Add(urun2);
            urunler.Add(urun3);

            Console.WriteLine(urun1.ToString());
            Console.WriteLine(urun2.ToString());
            Console.WriteLine(urun3.ToString());

            // ürünlerin kdv eklenmiş halini hesapla ve ekranda göster
            double toplam = ProductHelper.GetTotalBalance(urunler);
            Console.WriteLine("Toplam ödeme: "+ toplam);

            // dosyadan ürün oluşturma
            var urunlerDosyadan = ProductHelper.CreateItemsFromText("Products.txt");
            double toplamDosyadan = ProductHelper.GetTotalBalance(urunlerDosyadan);
            Console.WriteLine("Dosyadan Toplam Ödeme: " + toplamDosyadan);

            Console.ReadKey();
        }
    }
}
