
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UI.Model
{
    public class MBInvestment
    {
        
        public class ABDDOLARI
        {
            private string alis;
            public string Alış
            {
                get
                {
                    return (Convert.ToDecimal(alis.Replace(",", "."), CultureInfo.InvariantCulture) + 0.07M).ToString();
                }
                set
                {
                    alis = value;
                }
            }
            public string Satış { get; set; }
            public string Tür { get; set; }
        }

        public class GramAltın
        {
            private string alis;
            public string Alış
            {
                get
                {
                    return (Convert.ToDecimal(alis.Replace(",", "."), CultureInfo.InvariantCulture) + 3.0M).ToString();
                }
                set
                {
                    alis = value;
                }
            }
            public string Satış { get; set; }
            public string Tür { get; set; }
        }

        public class EURO
        {
            private string alis;
            public string Alış
            {
                get
                {
                    return (Convert.ToDecimal(alis.Replace(",", "."), CultureInfo.InvariantCulture) + 0.07M).ToString();
                }
                set
                {
                    alis = value;
                }
            }
            public string Satış { get; set; }
            public string Tür { get; set; }
        }
       
        [JsonPropertyName("Güncelleme Tarihi")]
        public string GüncellemeTarihi { get; set; }
        [JsonPropertyName("ABD DOLARI")]
        public ABDDOLARI Dolar { get; set; }
        [JsonPropertyName("Gram Altın")]
        public GramAltın Altin { get; set; }
        [JsonPropertyName("EURO")]
        public EURO Euro { get; set; }
    }
}
