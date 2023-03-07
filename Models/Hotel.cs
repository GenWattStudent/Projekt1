using CsvHelper.Configuration;

namespace Projekt1.Models
{
    public sealed class HotelMap : ClassMap<Hotel>
    {
        public HotelMap()
        {
            Map(x => x.Lp).Index(0);
            Map(x => x.Name).Index(1);
            Map(x => x.PhoneNumber).Index(2);
            Map(x => x.Email).Index(3);
            Map(x => x.Services).Index(4);
            Map(x => x.Category).Index(5);
            Map(x => x.Kind).Index(6);
            Map(x => x.Adress).Index(7);
        }
    }
    public class Hotel
    {
        public int Lp { get; set; }
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string Services { get; set; } = "";
        public string Category { get; set; } = "";
        public string Kind { get; set; } = "";
        public string Adress { get; set; } = "";
    }
}
