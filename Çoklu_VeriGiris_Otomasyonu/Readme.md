# Çoklu Veri Giriş Otomasyonu

Bu örnek, C# programlama dilinde bir çoklu veri girişi otomasyonunu uygulamak için kullanılabilir. Bu otomasyon, farklı veri tiplerini içeren bir dizi değeri, belirli bir sınıfın özelliklerine dönüştürmek amacıyla kullanılır. Ayrıca, veri dönüşümü sırasında hataları ele almak ve kullanıcıya geri bildirim sağlamak için try-catch blokları kullanılır.

## Nasıl Çalışır

Bu örnekte, `Deneme` adlı bir sınıfı kullanarak çoklu veri giriş otomasyonunu gösteriyoruz. İşte nasıl çalıştırılır:

1. `Deneme` sınıfını tanımlayın ve bu sınıfın özelliklerini (properties) ve veri tiplerini belirleyin. Örnek bir `Deneme` sınıfı aşağıdaki gibidir:

```csharp
public class Deneme
{
    public int ID { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public int Deneme123 { get; set; }
    public string Deneme321 { get; set; }
}

object[] degerler = new object[]
{
    1,
    "Koray",
    "Bapoğlu",
    "jkhkjklj",
    "hgfjhgjhh"
};

Deneme deneme = new Deneme();
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

Verilerin doğru bir şekilde dönüştürüldüğünü ve hataların ele alındığını kontrol etmek için Deneme sınıfının özelliklerini kullanın:


Console.WriteLine(deneme.ID);
Console.WriteLine(deneme.Adi);
Console.WriteLine(deneme.Soyadi);
Console.WriteLine(deneme.Deneme123);
Console.WriteLine(deneme.Deneme321);