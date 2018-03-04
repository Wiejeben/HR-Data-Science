using System;
using System.Collections.Generic;
using DataScience.Models.UserItem;

namespace DataScience.Services.Similarity
{
    /// <summary>
    /// Collects all the different similarity strategies for easy result comparison.
    /// </summary>
    public class SimilarityWrapper
    {
        /// <summary>
        /// Two complete lists that are to be compared.
        /// </summary>
        protected readonly List<Tuple<double, double>> Data;

        /// <summary>
        /// Two lists that are to be compered, where empty values are set to zero.
        /// </summary>
        protected readonly List<Tuple<double, double>> ZerodData;

        /// <summary>
        /// Converts two lists together based on the articles.
        /// </summary>
        public SimilarityWrapper(IReadOnlyDictionary<int, float> xRatings, IReadOnlyDictionary<int, float> yRatings,
            SortedDictionary<int, Article> articles)
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

        /// <summary>
        /// Calculate similarity based on euclidean.
        /// </summary>
        public double Euclidean()
        {
            var similarity = new Euclidean(Data);
            return similarity.Calculate();
        }

        /// <summary>
        /// Calculate similarity based on manhattan.
        /// </summary>
        public double Manhattan()
        {
            var similarity = new Manhattan(Data);
            return similarity.Calculate();
        }

        /// <summary>
        /// Calculate similarity based on pearson correlation coefficient.
        /// </summary>
        public double Pearson()
        {
            var similarity = new Pearson(Data);
            return similarity.Calculate();
        }

        /// <summary>
        /// Calculate similarity based on Cosine.
        /// </summary>
        public double Cosine()
        {
            var similarity = new Cosine(ZerodData);
            return similarity.Calculate();
        }
    }
}