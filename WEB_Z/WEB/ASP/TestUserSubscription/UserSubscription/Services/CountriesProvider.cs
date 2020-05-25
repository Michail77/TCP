using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSubscription.Services
{
    public class CountriesProvider
    {
        public CountriesProvider()
        {
            EUMembers = new Dictionary<string, string>
            {
                { "BE", "Belgique/België" },
                { "BG", "Bulgarija" },
                { "CZ", "Česko" },
                { "DK", "Danmark" },
                { "DE", "Deutschland" },
                { "EE", "Eesti" },
                { "IE", "Éire" },
                { "EL", "Elláda" },
                { "ES", "España" },
                { "FR", "France" },
                { "HR", "Hrvatska" },
                { "IT", "Italia" },
                { "CY", "Kýpros" },
                { "LV", "Latvija" },
                { "LT", "Lietuva" },
                { "LU", "Luxembourg" },
                { "HU", "Magyarország" },
                { "MT", "Malta" },
                { "NL", "Nederland" },
                { "AT", "Österreich" },
                { "PL", "Polska" },
                { "PT", "Portugal" },
                { "RO", "România" },
                { "SI", "Slovenija" },
                { "SK", "Slovensko" },
                { "FI", "Suomi/Finland" },
                { "SE", "Sverige" },
                { "UK", "United Kingdom" }
            };
            EFTA = new Dictionary<string, string>
            {
                { "IS", "Ísland" },
                { "LI", "Liechtenstein" },
                { "NO", "Norge" },
                { "CH", "Schweiz/Suisse/Svizzera" },
            };
        }

        public Dictionary<string,string> EUMembers { get; set; }
        public Dictionary<string, string> EFTA { get; set; }
    }
}
