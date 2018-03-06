using System;
using System.Collections.Generic;
using DataScience.Models.UserItem;

namespace DataScience.Services.Similarity
{
    public class SimilarityList
    { 
        /// <summary>
        /// Two complete lists that are to be compared.
        /// </summary>
        public List<Tuple<double, double>> Data { get; }

        /// <summary>
        /// Two lists that are to be compered, where empty values are set to zero.
        /// </summary>
        public List<Tuple<double, double>> ZerodData { get; }
        
        public SimilarityList(IReadOnlyDictionary<int, float> xRatings, IReadOnlyDictionary<int, float> yRatings, SortedDictionary<int, Article> articles)
        {
            Data = new List<Tuple<double, double>>();
            ZerodData = new List<Tuple<double, double>>();

            foreach (var article in articles)
            {
                var complete = true;
                if (!xRatings.TryGetValue(article.Key, out var x))
                {
                    x = 0.0f;
                    complete = false;
                }

                if (!yRatings.TryGetValue(article.Key, out var y))
                {
                    y = 0.0f;
                    complete = false;
                }

                // Only include complete datasets
                if (complete)
                {
                    Data.Add(new Tuple<double, double>(x, y));
                }

                ZerodData.Add(new Tuple<double, double>(x, y));
            }
        }
    }
}