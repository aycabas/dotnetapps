using System.Text.Json;
using monapp.Models;

namespace monapp.Helpers;

/// <summary>
/// Maymun verilerini yöneten statik yardımcı sınıf
/// </summary>
public static class MonkeyHelper
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    /// Maymun verilerini JSON formatında saklayan alan
    /// Bu normalde bir API'den veya veritabanından gelecek
    /// </summary>
    private static readonly string MonkeyDataJson = """
    [
        {"Name":"Baboon","Location":"Africa & Asia","Details":"Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg","Population":10000,"Latitude":-8.783195,"Longitude":34.508523},
        {"Name":"Capuchin Monkey","Location":"Central & South America","Details":"The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg","Population":23000,"Latitude":12.769013,"Longitude":-85.602364},
        {"Name":"Blue Monkey","Location":"Central and East Africa","Details":"The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg","Population":12000,"Latitude":1.957709,"Longitude":37.297204},
        {"Name":"Squirrel Monkey","Location":"Central & South America","Details":"The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg","Population":11000,"Latitude":-8.783195,"Longitude":-55.491477},
        {"Name":"Golden Lion Tamarin","Location":"Brazil","Details":"The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg","Population":19000,"Latitude":-14.235004,"Longitude":-51.92528},
        {"Name":"Howler Monkey","Location":"South America","Details":"Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg","Population":8000,"Latitude":-8.783195,"Longitude":-55.491477},
        {"Name":"Japanese Macaque","Location":"Japan","Details":"The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg","Population":1000,"Latitude":36.204824,"Longitude":138.252924},
        {"Name":"Mandrill","Location":"Southern Cameroon, Gabon, and Congo","Details":"The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg","Population":17000,"Latitude":7.369722,"Longitude":12.354722},
        {"Name":"Proboscis Monkey","Location":"Borneo","Details":"The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg","Population":15000,"Latitude":0.961883,"Longitude":114.55485},
        {"Name":"Sebastian","Location":"Seattle","Details":"This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Google Pixel 9!","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg","Population":1,"Latitude":47.606209,"Longitude":-122.332071},
        {"Name":"Henry","Location":"Phoenix","Details":"An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone Xs!","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg","Population":1,"Latitude":33.448377,"Longitude":-112.074037},
        {"Name":"Red-shanked douc","Location":"Vietnam","Details":"The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest.","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg","Population":1300,"Latitude":16.111648,"Longitude":108.262122},
        {"Name":"Mooch","Location":"Seattle","Details":"An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. Her favorite platform is iOS by far and is excited for the new iPhone 16!","Image":"https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG","Population":1,"Latitude":47.608013,"Longitude":-122.335167}
    ]
    """;

    /// <summary>
    /// Tüm maymunları getirir
    /// </summary>
    /// <returns>Maymun listesi</returns>
    public static List<Monkey> GetMonkeys()
    {
        try
        {
            var monkeys = JsonSerializer.Deserialize<List<Monkey>>(MonkeyDataJson, JsonOptions);
            return monkeys ?? new List<Monkey>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Maymun verileri yüklenirken hata oluştu: {ex.Message}");
            return new List<Monkey>();
        }
    }

    /// <summary>
    /// Belirli bir isimde maymun getirir
    /// </summary>
    /// <param name="name">Maymun adı</param>
    /// <returns>Bulunan maymun veya null</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        var monkeys = GetMonkeys();
        return monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Rastgele bir maymun getirir
    /// </summary>
    /// <returns>Rastgele seçilen maymun</returns>
    public static Monkey? GetRandomMonkey()
    {
        var monkeys = GetMonkeys();
        if (monkeys.Count == 0) return null;

        var random = new Random();
        var randomIndex = random.Next(monkeys.Count);
        return monkeys[randomIndex];
    }

    /// <summary>
    /// Tüm maymunları tablo formatında yazdırır
    /// </summary>
    public static void DisplayMonkeysTable()
    {
        var monkeys = GetMonkeys();
        
        if (monkeys.Count == 0)
        {
            Console.WriteLine("Gösterilecek maymun verisi bulunamadı.");
            return;
        }

        Console.WriteLine("🐒 MAYMUN BİLGİ SİSTEMİ 🐒");
        Console.WriteLine(new string('=', 140));
        Console.WriteLine();

        // Tablo başlığı
        Console.WriteLine($"{"No",-3} | {"Maymun Adı",-20} | {"Konum",-30} | {"Popülasyon",-12} | {"Koordinatlar",-20} | {"Açıklama",-50}");
        Console.WriteLine(new string('-', 140));

        // Her maymun için bilgileri yazdır
        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            var shortDescription = monkey.GetShortDescription(47);
            
            Console.WriteLine($"{i + 1,-3} | {monkey.Name,-20} | {monkey.Location,-30} | {monkey.Population,-12:N0} | {monkey.Coordinates,-20} | {shortDescription,-50}");
        }

        Console.WriteLine(new string('-', 140));
        Console.WriteLine($"Toplam {monkeys.Count} maymun türü listelendi.");
    }

    /// <summary>
    /// Maymun istatistiklerini gösterir
    /// </summary>
    public static void DisplayStatistics()
    {
        var monkeys = GetMonkeys();
        
        if (monkeys.Count == 0)
        {
            Console.WriteLine("İstatistik gösterilecek veri bulunamadı.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("📊 İSTATİSTİKLER:");
        Console.WriteLine($"• Toplam popülasyon: {monkeys.Sum(m => m.Population):N0}");
        Console.WriteLine($"• En kalabalık tür: {monkeys.OrderByDescending(m => m.Population).First().Name} ({monkeys.Max(m => m.Population):N0})");
        Console.WriteLine($"• En az sayıda olan tür: {monkeys.OrderBy(m => m.Population).First().Name} ({monkeys.Min(m => m.Population):N0})");
        
        // Ortalama popülasyon
        var averagePopulation = monkeys.Average(m => m.Population);
        Console.WriteLine($"• Ortalama popülasyon: {averagePopulation:N0}");
    }

    /// <summary>
    /// Coğrafi dağılımı gösterir
    /// </summary>
    public static void DisplayGeographicalDistribution()
    {
        var monkeys = GetMonkeys();
        
        if (monkeys.Count == 0)
        {
            Console.WriteLine("Coğrafi dağılım gösterilecek veri bulunamadı.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("🌍 COĞRAFYA BÖLGELERE GÖRE DAĞILIM:");
        
        var locationGroups = monkeys.GroupBy(m => 
        {
            var location = m.Location.ToLower();
            if (location.Contains("africa")) return "Afrika";
            if (location.Contains("america") || location.Contains("brazil")) return "Amerika";
            if (location.Contains("asia") || location.Contains("japan")) return "Asya";
            if (location.Contains("borneo")) return "Asya (Borneo)";
            if (location.Contains("vietnam")) return "Asya (Vietnam)";
            if (location.Contains("seattle") || location.Contains("phoenix")) return "Kuzey Amerika";
            return "Diğer";
        });

        foreach (var group in locationGroups.OrderBy(g => g.Key))
        {
            var totalPopulation = group.Sum(m => m.Population);
            Console.WriteLine($"• {group.Key}: {group.Count()} tür, Toplam popülasyon: {totalPopulation:N0}");
        }
    }
}
