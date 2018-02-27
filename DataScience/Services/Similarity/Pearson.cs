using System;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    public class Pearson : Similarity
    {
        public Pearson(List<Tuple<double, double>> data) : base(data)
        {
        }

        public Pearson(IReadOnlyList<double> x, IReadOnlyList<double> y) : base(x, y)
        {
        }

        public override double Calculate()
        {
            var length = 0;
            double sumX = 0;
            double sumY = 0;
            double sumX2 = 0;
            double sumY2 = 0;

            double sumXY = 0;

            foreach (var value in Data)
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