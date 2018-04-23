using System;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    public class Cosine : Similarity
    {
        public double Calculate(SimilarityList data)
        {
            double multiSum = 0;
            double sumX2 = 0;
            double sumY2 = 0;

            foreach (var value in data.ZerodData)
            {
                multiSum += value.Item1 * value.Item2;

                sumX2 += Math.Pow(value.Item1, 2);
                sumY2 += Math.Pow(value.Item2, 2);
            }

            return multiSum / (Math.Sqrt(sumX2) * Math.Sqrt(sumY2));
        }
    }
}