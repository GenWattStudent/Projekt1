using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using Projekt1;

public class Program
{
    static void displayHotel(Hotel hotel)
    {
        Console.WriteLine($"Lp: {hotel.Lp,4} | Name: {hotel.Name,40} | Phone number: {hotel.PhoneNumber,16} | Hotel Category: {hotel.Category,6}");
    }
    static void DisplayHotels(IEnumerable<Hotel> hotels)
    {
        foreach (var hotel in hotels)
        {
            displayHotel(hotel);
        }
    }

    static void Main()
    {
        //  zad 1
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };

        using (var reader = new StreamReader("hotele.csv"))
        using (var csv = new CsvReader(reader, config))
        {
            var hotels = csv.GetRecords<Hotel>().ToList();
            // 3. Obliczyć ile hoteli ma charakter sezonowy
            var seasonHotelsCount = hotels.Where(h => h.Services == "sezonowy").Count();
            Console.WriteLine("3. Obliczyć ile hoteli ma charakter sezonowy");
            Console.WriteLine($"{seasonHotelsCount} hotele");
            // 6.Wyświetlić hotele, które pochodzą z okolicy Bielska - Białej(numer telefonu zaczyna się 33)
            var hotelsFromBielsko = hotels.Where(h => h.PhoneNumber.StartsWith("33"));
            Console.WriteLine("6. Wyświetlić hotele, które pochodzą z okolicy Bielska-Białej (numer telefonu zaczyna się 33)");
            DisplayHotels(hotelsFromBielsko);
            //7. Pogrupować hotele wg kategorii i zwrócić ile hoteli występuje w każdej grupie
            var hotelsCountInCategory = hotels
                .GroupBy(h => h.Category)
                .Select(h => new { Category = h.Key, hotelCount = h.Count() });
            Console.WriteLine("7. Pogrupować hotele wg kategorii i zwrócić ile hoteli występuje w każdej grupie");
            foreach (var item in hotelsCountInCategory)
            {
                Console.WriteLine($"Category name: {item.Category}, hotel count: {item.hotelCount}");
            }
        }
    }
}
