using NexApp.Core;
using NexApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NexApp.Controllers
{
    public class QuotesController : ApiController
    {
        private CsvReader csv = new CsvReader();
        private Filter filter = new Filter();

        public List<Feature> GetQuotes(Nullable<double> marketCap = null, Nullable<double> dailyChange = null, string currency = null)
        {
            List<Feature> features = csv.Read();
            if (marketCap != null)
            {
                features = filter.FilterByMarketCap(features, marketCap.Value);
            }

            if (dailyChange != null)
            {
                features = filter.FilterByDailyChange(features, dailyChange.Value);
            }

            if (currency != null)
            {
                features = filter.FilterByCurrency(features, currency);
            }

            return features;
        }
    }
}
