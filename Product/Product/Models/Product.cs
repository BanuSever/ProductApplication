using System;

namespace ProductApp.Models
{
    public class Product
    {
        private string adi; 
        private double fiyat; 
        private int miktar;  

        // Varsayılan metot
        public Product():this("")
        {

        }

        // adı belirleyen metot
        public Product(string adi):this(adi,0)
        {
            Console.WriteLine("Product oluşturuldu: " + this.adi + " " + DateTime.Now);
        }

        // adı ve fiyatı belirleyen yapıcı metot
        public Product(string adi, double fiyat):this(adi, fiyat, 1)
        {
            Console.WriteLine("Product oluşturuldu: " + this.adi + " " + DateTime.Now);
        }

        // adı, fiyatı ve miktarı belirleyen yapıcı metot
        public Product(string adi, double fiyat, int miktar)
        {
            this.Adi = adi;
            this.Fiyat = fiyat;
            this.Miktar = miktar; // miktarı geçerli bir değerle ayarla
            Console.WriteLine("Product oluşturuldu: " + this.adi +" "+ DateTime.Now);
        }

        // ürünün toplam fiyatını hesaplama
        public double GetTotalPrice()
        {
            return this.Fiyat * this.Miktar;
        }

        // ad kapsüllenmiş olarak erişilebilir
        //Adi isimli property 'adi' aslı gizli bir değişkeni kontrol eder
        public string Adi
        {
            get { return adi; }
            set // adi değişkenine bir değer atmak istendiğinde
            {
                if (value.Length >= 3 && value.Length <= 10)
                    adi = value;
                else
                    Console.WriteLine("İsim 3-10 karakter aralığında olmalıdır.");
            }
        }

        // Fiyat kapsüllenmiş olarak erişilebilir
        public double Fiyat
        {
            get { return fiyat; }
            set
            {
                if (value >= 0)
                    fiyat = value;
                else
                    Console.WriteLine("Fiyat en az 0 olmalıdır.");
            }
        }

        // Miktar kapsüllenmiş olarak erişilebilir
        public int Miktar
        {
            get { return miktar; }
            set
            {
                if (value >= 1)
                    miktar = value;
                else
                    Console.WriteLine("Miktar en az 1 olmalıdır.");
            }
        }

        // ToString() metodunu geçersiz kılma
        public override string ToString()
        {
            return $"Ürün: {adi}, Fiyatı: {fiyat}, Miktarı: {miktar}";
        }
    }
}
