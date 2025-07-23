namespace monapp.Models;

/// <summary>
/// Maymun türlerini temsil eden model sınıfı
/// </summary>
public class Monkey
{
    /// <summary>
    /// Maymunun adı
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Maymunun yaşadığı coğrafi konum
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Maymun hakkında detaylı açıklama
    /// </summary>
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Maymunun resim URL'si
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Maymunun popülasyon sayısı
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Maymunun bulunduğu lokasyonun enlem değeri
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Maymunun bulunduğu lokasyonun boylam değeri
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Maymunun koordinatlarını string formatında döndürür
    /// </summary>
    public string Coordinates => $"{Latitude:F2}, {Longitude:F2}";

    /// <summary>
    /// Kısaltılmış açıklama döndürür
    /// </summary>
    /// <param name="maxLength">Maksimum karakter sayısı</param>
    /// <returns>Kısaltılmış açıklama</returns>
    public string GetShortDescription(int maxLength = 50)
    {
        if (Details.Length <= maxLength)
            return Details;
        
        return Details.Substring(0, maxLength - 3) + "...";
    }
}
