using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexApp.Models
{
    public class Feature
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double MarketCap { get; set; }
        public double Price { get; set; }
        public double DailyChange { get; set; }
        public double DailyChangePercent { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
    }
}