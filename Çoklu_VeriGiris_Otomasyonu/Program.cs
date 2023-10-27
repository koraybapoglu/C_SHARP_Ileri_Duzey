using System.Reflection;

namespace Deneme456
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object[] degerler=new object[] 
            {
               1,
               "Koray",
               "Bapoğlu",
               "jkhkjklj",
               "hgfjhgjhh"
            };
            Deneme deneme=new Deneme();
            PropertyInfo[] properties = typeof(Deneme).GetProperties();
            try
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    // Değerleri doğru türe dönüştürmeye çalışın
                    object value = Convert.ChangeType(degerler[i], properties[i].PropertyType);
                    properties[i].SetValue(deneme, value);
                }
            }
            catch (FormatException ex)
            {
                // Dönüşüm hatası (örneğin, sayısal bir değeri string olarak ayarlamaya çalışmak)
                // Burada hatayı işleyebilirsiniz.
                Console.WriteLine("Veri dönüştürme hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Diğer türde hataları ele almak için genel bir hata yakalayıcı
                // Burada hatayı işleyebilirsiniz.
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
            Console.WriteLine(deneme.ID);
            Console.WriteLine(deneme.Adi);
            Console.WriteLine(deneme.Soyadi);
            Console.WriteLine(deneme.Deneme123);
            Console.WriteLine(deneme.Deneme321);
            Console.ReadLine();
        }
       
    }
    public class Deneme
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Deneme123 { get; set; }
        public string Deneme321 { get; set; }
    }
}
