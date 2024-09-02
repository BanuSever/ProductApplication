using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.IO; //Dosya işlemleri için eklenir.
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Helpers
{
    public static class ProductHelper
    {
        // .txt dosyasından ürünleri oluşturma
        public static List<Product> CreateItemsFromText(string dosyaYolu)
        {
            //Product nesnelerini saklayacak boş bir liste
            var urunler = new List<Product>();
            //Dosyadaki tüm satırları oku
            var satirlar = File.ReadAllLines(dosyaYolu);

            foreach (var satir in satirlar)
            {
                //Satırı virgüllerle ayırarak bir dizi oluşturma
                var parcalar = satir.Split(',');

                // İsim ve fiyat parçalarını kontrol etme
                //İsim ve fiyat olacağından 2 den büyük olma şartına bakılır
                if (parcalar.Length >= 2)
                {
                    string ad = parcalar[0];//ilk eleman ürün adı
                    double urunFiyati;
                    int miktar = 1; // Varsayılan miktar

                    // try ile hata olabilecek yeri kontrol eder
                    //ikinci elemanı double türüne dönüştürür
                    try
                    {
                        urunFiyati = Convert.ToDouble(parcalar[1]);
                    }
                    //Dönüştürme sıraısnda formatexecption hatası olursa çalışır
                    catch (FormatException)
                    {
                        Console.WriteLine("Fiyat değeri geçersiz: " + parcalar[1]);
                        continue;
                    }

                    // Miktarı kontrol et ve dönüştür
                    if (parcalar.Length >= 3)
                    {
                        try
                        {
                            //eğer parçalar 3'ten büyükse 
                            //3. eleman miktar değeridir
                            miktar = Convert.ToInt32(parcalar[2]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Miktar değeri geçersiz: " + parcalar[2]);
                        }
                    }
                    //Yeni bir product nesnesi oluşturuldu
                    var urun = new Product(ad, urunFiyati, miktar);
                    //nesne urunler listesine eklendi
                    urunler.Add(urun);
                }
            }
            return urunler;
        }
        // Ürünlerin toplam fiyatını hesaplayan metot
        public static double GetTotalBalance(List<Product> urunler)
        {
            // Ürünlerin toplam fiyatını hesapla
            double toplam = 0;

            foreach (var urun in urunler)
            {
                toplam += urun.GetTotalPrice();
            }

            // kdv oranı tanımla
            double kdv = 0.20;

            // kdv tutarı eklenmiş toplam fiyatı döndür
            return toplam * (1 + kdv);
        }

    }
}
