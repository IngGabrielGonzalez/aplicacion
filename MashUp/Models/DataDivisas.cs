using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MashUp.Models
{
    public partial class DataDivisas
    {
        public string Base { get; set; }


        public string Target { get; set; }


        public long BaseAmount { get; set; }


        public double ConvertedAmount { get; set; }

        public double ExchangeRate { get; set; }

        public long LastUpdated { get; set; }

        public Dictionary<string, double> ExchangeRates { get; set; }
    }
}