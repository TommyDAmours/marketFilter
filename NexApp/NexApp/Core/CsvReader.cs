using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.VisualBasic.FileIO;
using NexApp.Models;

namespace NexApp.Core
{
    public class CsvReader
    {
        public List<Feature> Read()
        {

            List<Feature> features = new List<Feature>();
            using (TextFieldParser csvParser = new TextFieldParser(GenerateStreamFromString(Properties.Resources.quotes)))
            {
                csvParser.CommentTokens = new string[] { "" };
                csvParser.Delimiters = new string[] { "," };
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    Feature feature = new Feature();

                    string[] csvFile = csvParser.ReadFields();
                    feature.Symbol = csvFile[0];
                    feature.Name = csvFile[1];
                    feature.MarketCap = Parse(csvFile[2]);
                    feature.Price = Parse(csvFile[3]);
                    feature.DailyChange = Parse(csvFile[5]);
                    feature.DailyChangePercent = Parse(csvFile[5]);
                    feature.Currency = csvFile[6];
                    feature.Date = DateTime.Parse(csvFile[7]);
                    features.Add(feature);
                }
            }
            return features;
        }

        public MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }

        private double Parse(string value)
        {
            return double.Parse(value, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo);
        }
    }
}