using System;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    public class Pearson : Similarity
    {
        public Pearson(SimilarityList data) : base(data)
        {
        }

        public override double Calculate()
        {
            var length = 0;
            double sumX = 0;
            double sumY = 0;
            double sumX2 = 0;
            double sumY2 = 0;

            // ReSharper disable once InconsistentNaming
            double sumXY = 0;

            foreach (var value in Data.Data)
            {
                sumX += value.Item1;
                sumY += value.Item2;

                sumX2 += Math.Pow(value.Item1, 2);
                sumY2 += Math.Pow(value.Item2, 2);

                sumXY += value.Item1 * value.Item2;

                length++;
            }

            var numerator = sumXY - sumX * sumY / length;
            var denominator = Math.Sqrt(sumX2 - Math.Pow(sumX, 2) / length) *
                              Math.Sqrt(sumY2 - Math.Pow(sumY, 2) / length);

            return numerator / denominator;
        }
    }
}