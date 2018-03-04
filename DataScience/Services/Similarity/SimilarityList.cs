using System;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    public static class SimilarityList
    {
        /// <summary>
        /// Generate list with tuples for the similarity measurement.
        /// </summary>
        /// 
        /// TODO: Improve this by including a list of articles.
        /// 
        public static List<Tuple<double, double>> Create(IReadOnlyList<double> x, IReadOnlyList<double> y)
        {
            var values = new List<Tuple<double, double>>();

            // Merge two arrays into a single list with tuples
            var length = x.Count;
            if (length != y.Count) throw new Exception("Array lengths must be equal to be able to compare values.");

            for (var i = 1; i <= length; i++)
            {
                var index = i - 1;

                values.Add(new Tuple<double, double>(x[index], y[index]));
            }

            return values;
        }
    }
}