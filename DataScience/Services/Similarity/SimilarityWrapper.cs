using System;
using System.Collections.Generic;
using DataScience.Models.UserItem;

namespace DataScience.Services.Similarity
{
    public class SimilarityWrapper
    {
        protected readonly List<Tuple<double, double>> Data;
        protected readonly List<Tuple<double, double>> ZerodData;

        public SimilarityWrapper(List<Tuple<double, double>> data)
        {
            Data = data;
        }

        public SimilarityWrapper(IReadOnlyList<double> x, IReadOnlyList<double> y)
        {
            Data = SimilarityList.Create(x, y);
        }

        public SimilarityWrapper(IReadOnlyDictionary<int, float> xRatings, IReadOnlyDictionary<int, float> yRatings, SortedDictionary<int, Article> articles)
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

                if (complete)
                {
                    Data.Add(new Tuple<double, double>(x, y));
                }
                
                ZerodData.Add(new Tuple<double, double>(x, y));
            }
        }

        public double Euclidean()
        {
            var similarity = new Euclidean(Data); // TODO: Decide whether to use the zerod data
            return similarity.Calculate();
        }

        public double Manhattan()
        {
            var similarity = new Manhattan(Data); // TODO: Decide whether to use the zerod data
            return similarity.Calculate();
        }

        public double Pearson()
        {
            var similarity = new Pearson(Data); // TODO: Decide whether to use the zerod data
            return similarity.Calculate();
        }
        
        public double Cosine()
        {
            var similarity = new Cosine(Data); // TODO: Decide whether to use the zerod data
            return similarity.Calculate();
        }
    }
}