using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Projekt1.Models
{
    public class Hotel
    {
        [Index(0)]
        public int Lp { get; set; }

        [Index(1)]
        public string Name { get; set; } = "";

        [Index(2)]
        public string PhoneNumber { get; set; } = "";

        [Index(3)]
        public string Email { get; set; } = "";

        [Index(4)]
        public string Services { get; set; } = "";

        [Index(5)]
        public string Category { get; set; } = "";

        [Index(6)]
        public string Kind { get; set; } = "";

        [Index(7)]
        public string Adress { get; set; } = "";
    }
}
