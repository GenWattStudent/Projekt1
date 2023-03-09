using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using Projekt1;

public class Program
{
    //Utility functions
    static void DisplayHotel(Hotel hotel)
    {
        Console.WriteLine($"Lp: {hotel.Lp,4} | Name: {hotel.Name,60} | Phone number: {hotel.PhoneNumber,16} | Hotel Category: {hotel.Category,6}");
    }
    static void DisplayHotels(IEnumerable<Hotel> hotels)
    {
        foreach (var hotel in hotels)
        {
            DisplayHotel(hotel);
        }
    }

    static void DisplaySpacer()
    {
        Console.WriteLine("\n------------------\n");
    }

    static void Main()
    {
        //[AR]1. Wczytać dane z pliku hotele.csv z użyciem biblioteki CsvHelper
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };

        const string csvFile = "hotele.csv";

        using (var reader = new StreamReader(csvFile))
        using (var csv = new CsvReader(reader, config))
        {
            List<Hotel> hotels = csv.GetRecords<Hotel>().ToList();

            Console.WriteLine($"Info: Załadowano {hotels.Count()} pozycji z pliku {csvFile}");

            DisplaySpacer();

            //[MZ]2. Wyszukać wszystkie hotele, których nazwa zaczyna się na literę 's'

            Console.WriteLine("Zadanie 2. Wyszukać wszystkie hotele, których nazwa zaczyna się na literę 's'\n");

            var hotlesStartingWithS = hotels
                .Where(r => r.Name.ToLower().StartsWith("s"));

            Console.WriteLine("Hotele hotele, których nazwa zaczyna się na literę 's':");

            DisplayHotels(hotlesStartingWithS);

            DisplaySpacer();

            //[AR]3. Obliczyć ile hoteli ma charakter sezonowy

            const string searchedKind = "sezonowy";

            var seasonHotelsCount = hotels
                .Where(h => h.Services.ToLower() == searchedKind)
                .Count();

            Console.WriteLine("Zadnanie 3. Obliczyć ile hoteli ma charakter sezonowy\n");
            Console.WriteLine($"Hoteli sezonowych jest: {seasonHotelsCount}");

            DisplaySpacer();

            //[MZ]4.Wyświetlić wszystkie typy charakterów usług bez powtórzeń

            Console.WriteLine("Zadanie 4. Wyświetlić wszystkie typy charakterów usług bez powtórzeń\n");

            var distinctServices = hotels
                .Select(r => r.Services)
                .Distinct();

            Console.WriteLine("Charaktery usług:");

            foreach(var service in distinctServices)
            {
                Console.WriteLine($"\t{service}");
            }

            DisplaySpacer();

            //[AR]6.Wyświetlić hotele, które pochodzą z okolicy Bielska - Białej(numer telefonu zaczyna się 33)

            const string bielskoBialaAreaCode = "33";

            var hotelsFromBielsko = hotels
                .Where(h => h.PhoneNumber.StartsWith(bielskoBialaAreaCode));

            Console.WriteLine("Zadanie 6. Wyświetlić hotele, które pochodzą z okolicy Bielska-Białej (numer telefonu zaczyna się 33)\n");
            Console.WriteLine("Hotele z okolicy Bielska-Białej:");

            DisplayHotels(hotelsFromBielsko);

            DisplaySpacer();

            //[AR]7. Pogrupować hotele wg kategorii i zwrócić ile hoteli występuje w każdej grupie

            var hotelsCountInCategory = hotels
                .GroupBy(h => h.Category)
                .Select(h => new {
                    Category = h.Key,
                    hotelCount = h.Count()
                });

            Console.WriteLine("Zadanie 7. Pogrupować hotele wg kategorii i zwrócić ile hoteli występuje w każdej grupie\n");

            Console.WriteLine("Kategorie i ich liczebnosć:");

            foreach (var item in hotelsCountInCategory)
            {
                Console.WriteLine($"Category name: {item.Category,8}, hotel count: {item.hotelCount,4}");
            }

            DisplaySpacer();
        }
    }
}
