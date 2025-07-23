using monapp.Helpers;
using monapp.Models;

namespace monapp.Services;

/// <summary>
/// Kullanıcı arayüzü işlemlerini yöneten sınıf
/// </summary>
public static class UserInterface
{
    /// <summary>
    /// Eğlenceli ASCII sanatları koleksiyonu
    /// </summary>
    private static readonly string[] AsciiArts = new[]
    {
        // Maymun yüzü
        @"
    .-""--.
   /       \
  |  o   o  |
  |    >    |
  |   ___   |
   \       /
    `-----'
   🐒 Maymun!",

        // Muz
        @"
      .-.
     (   )
      '-'
     /   \
    |     |
    |     |
     \   /
      \ /
       |
   🍌 Muz Zamanı!",

        // Ağaç
        @"
       🌳
      /|\
     / | \
    /  |  \
   /   |   \
      |||
      |||
      |||
   Ağaç Evi!",

        // Güneş
        @"
    \   |   /
     \  |  /
   ---  ☀️  ---
     /  |  \
    /   |   \
   Güneşli Gün!",

        // Kalp
        @"
    ♥♥   ♥♥
  ♥    ♥    ♥
 ♥             ♥
♥               ♥
 ♥             ♥
  ♥           ♥
   ♥         ♥
    ♥       ♥
     ♥     ♥
      ♥   ♥
       ♥ ♥
        ♥
   Sevgi Dolu!",

        // Yıldız
        @"
        ⭐
       /|\
      / | \
     ⭐--⭐--⭐
      \ | /
       \|/
        ⭐
   Parlak Yıldız!",

        // Dans eden maymun
        @"
      o  o
       \/
    \  **  /
     \ __ /
      |  |
     /    \
    o      o
   Maymun Dansı!",

        // Çiçek
        @"
      🌸
     /|\
    🌸-🌺-🌸
     \|/
      🌸
      |
      |
   Güzel Çiçek!"
    };
    /// <summary>
    /// Rastgele eğlenceli ASCII sanatı gösterir
    /// </summary>
    private static void ShowRandomAsciiArt()
    {
        var random = new Random();
        var randomIndex = random.Next(AsciiArts.Length);
        var selectedArt = AsciiArts[randomIndex];
        
        Console.WriteLine();
        Console.WriteLine(selectedArt);
        Console.WriteLine();
    }

    /// <summary>
    /// Ana menüyü gösterir ve kullanıcı seçimini işler
    /// </summary>
    public static void ShowMainMenu()
    {
        bool exitRequested = false;

        while (!exitRequested)
        {
            Console.Clear();
            DisplayHeader();
            DisplayMenuOptions();

            var userChoice = GetUserChoice();

            switch (userChoice)
            {
                case "1":
                    ShowAllMonkeys();
                    break;
                case "2":
                    ShowRandomMonkey();
                    break;
                case "3":
                    SearchMonkeyByName();
                    break;
                case "4":
                    ShowStatistics();
                    break;
                case "5":
                    ShowGeographicalDistribution();
                    break;
                case "6":
                    exitRequested = true;
                    ShowExitMessage();
                    break;
                default:
                    ShowInvalidChoiceMessage();
                    break;
            }

            if (!exitRequested)
            {
                WaitForUserInput();
            }
        }
    }

    /// <summary>
    /// Uygulama başlığını gösterir
    /// </summary>
    private static void DisplayHeader()
    {
        Console.WriteLine("🐒 MAYMUN BİLGİ SİSTEMİ 🐒");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine();
    }

    /// <summary>
    /// Menü seçeneklerini gösterir
    /// </summary>
    private static void DisplayMenuOptions()
    {
        Console.WriteLine("Lütfen bir seçenek seçin:");
        Console.WriteLine();
        Console.WriteLine("1. 📋 Tüm maymunları listele");
        Console.WriteLine("2. 🎲 Rastgele maymun göster");
        Console.WriteLine("3. 🔍 İsime göre maymun ara");
        Console.WriteLine("4. 📊 İstatistikleri göster");
        Console.WriteLine("5. 🌍 Coğrafi dağılımı göster");
        Console.WriteLine("6. 🚪 Çıkış");
        Console.WriteLine();
        Console.Write("Seçiminiz (1-6): ");
    }

    /// <summary>
    /// Kullanıcı seçimini alır
    /// </summary>
    /// <returns>Kullanıcının seçimi</returns>
    private static string GetUserChoice()
    {
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }

    /// <summary>
    /// Tüm maymunları gösterir
    /// </summary>
    private static void ShowAllMonkeys()
    {
        Console.Clear();
        MonkeyHelper.DisplayMonkeysTable();
        ShowRandomAsciiArt();
    }

    /// <summary>
    /// Rastgele bir maymun gösterir
    /// </summary>
    private static void ShowRandomMonkey()
    {
        Console.Clear();
        var randomMonkey = MonkeyHelper.GetRandomMonkey();

        if (randomMonkey != null)
        {
            Console.WriteLine("🎲 RASTGELE MAYMUN 🎲");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();
            DisplayMonkeyDetails(randomMonkey);
        }
        else
        {
            Console.WriteLine("Rastgele maymun seçilemedi.");
        }
        
        ShowRandomAsciiArt();
    }

    /// <summary>
    /// İsme göre maymun arar
    /// </summary>
    private static void SearchMonkeyByName()
    {
        Console.Clear();
        Console.WriteLine("🔍 MAYMUN ARAMA 🔍");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine();
        
        Console.Write("Aramak istediğiniz maymunun adını girin: ");
        var searchName = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(searchName))
        {
            Console.WriteLine("Geçerli bir isim girmediniz.");
            return;
        }

        var foundMonkey = MonkeyHelper.GetMonkeyByName(searchName);

        if (foundMonkey != null)
        {
            Console.WriteLine();
            Console.WriteLine("✅ Maymun bulundu!");
            Console.WriteLine();
            DisplayMonkeyDetails(foundMonkey);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"❌ '{searchName}' isimli maymun bulunamadı.");
            Console.WriteLine();
            Console.WriteLine("Mevcut maymun isimleri:");
            var allMonkeys = MonkeyHelper.GetMonkeys();
            foreach (var monkey in allMonkeys)
            {
                Console.WriteLine($"• {monkey.Name}");
            }
        }
        
        ShowRandomAsciiArt();
    }

    /// <summary>
    /// İstatistikleri gösterir
    /// </summary>
    private static void ShowStatistics()
    {
        Console.Clear();
        Console.WriteLine("📊 MAYMUN İSTATİSTİKLERİ 📊");
        Console.WriteLine(new string('=', 50));
        MonkeyHelper.DisplayStatistics();
        ShowRandomAsciiArt();
    }

    /// <summary>
    /// Coğrafi dağılımı gösterir
    /// </summary>
    private static void ShowGeographicalDistribution()
    {
        Console.Clear();
        Console.WriteLine("🌍 COĞRAFYA DAĞILIMI 🌍");
        Console.WriteLine(new string('=', 50));
        MonkeyHelper.DisplayGeographicalDistribution();
        ShowRandomAsciiArt();
    }

    /// <summary>
    /// Tek bir maymunun detaylarını gösterir
    /// </summary>
    /// <param name="monkey">Gösterilecek maymun</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine($"🐒 {monkey.Name}");
        Console.WriteLine($"📍 Konum: {monkey.Location}");
        Console.WriteLine($"👥 Popülasyon: {monkey.Population:N0}");
        Console.WriteLine($"🗺️ Koordinatlar: {monkey.Coordinates}");
        Console.WriteLine($"📝 Açıklama: {monkey.Details}");
        Console.WriteLine($"🖼️ Resim: {monkey.Image}");
    }

    /// <summary>
    /// Geçersiz seçim mesajı gösterir
    /// </summary>
    private static void ShowInvalidChoiceMessage()
    {
        Console.Clear();
        Console.WriteLine("❌ Geçersiz seçim! Lütfen 1-6 arasında bir sayı girin.");
        ShowRandomAsciiArt();
    }

    /// <summary>
    /// Çıkış mesajı gösterir
    /// </summary>
    private static void ShowExitMessage()
    {
        Console.Clear();
        Console.WriteLine("👋 Maymun Bilgi Sistemi'ni kullandığınız için teşekkürler!");
        Console.WriteLine("Güle güle! 🐒");
        
        // Özel çıkış ASCII sanatı
        Console.WriteLine(@"
      👋
    \  o  /
     \ | /
      \|/
    ---😊---
      /|\
     / | \
    /  |  \
   🐒 Hoşça Kal! 🐒");
    }

    /// <summary>
    /// Kullanıcının devam etmesi için bekler
    /// </summary>
    private static void WaitForUserInput()
    {
        Console.WriteLine();
        Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
        Console.ReadKey();
    }
}
