using monapp.Services;

// Maymun Bilgi Sistemi Uygulaması
// .NET 9 ve C# 13 kullanılarak geliştirilmiştir

try
{
    // Ana menüyü başlat
    UserInterface.ShowMainMenu();
}
catch (Exception ex)
{
    Console.WriteLine($"Uygulama çalışırken bir hata oluştu: {ex.Message}");
    Console.WriteLine("Lütfen uygulamayı yeniden başlatın.");
    Console.ReadKey();
}
