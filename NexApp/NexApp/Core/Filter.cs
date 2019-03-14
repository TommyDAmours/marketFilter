using NexApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NexApp.Core
{
    public class Filter
    {
        
        public List<Feature> FilterByMarketCap(List<Feature> features, double marcketCap)
        {
            // Using another list to preserve the original.
            List<Feature> filteredFeatures = new List<Feature>();
            foreach (Feature feature in features)
            {
                if (feature.MarketCap > marcketCap)
                {
                    filteredFeatures.Add(feature);
                }
            }
            return filteredFeatures;
        }

        public List<Feature> FilterByDailyChange(List<Feature> features, double dailyChange)
        {
            List<Feature> filteredFeatures = new List<Feature>();
            foreach (Feature feature in features)
            {
                if (feature.DailyChange > dailyChange)
                {
                    filteredFeatures.Add(feature);
                }
            }
            return filteredFeatures;
        }

        public List<Feature> FilterByCurrency(List<Feature> features, string currency)
        {
            List<Feature> filtredFeatures = new List<Feature>();
            foreach (Feature feature in features)
            {
                if (feature.Currency.Equals(currency))
                {
                    filtredFeatures.Add(feature);
                }
            }
            return filtredFeatures;
        }
    }
}