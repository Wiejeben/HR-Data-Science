using System;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    public class Cosine : Similarity
    {
        public Cosine(List<Tuple<double, double>> data) : base(data)
        {
        }

        public Cosine(IReadOnlyList<double> x, IReadOnlyList<double> y) : base(x, y)
        {
        }

        public override double Calculate()
        {
            double multiSum = 0;
            double sumX2 = 0;
            double sumY2 = 0;

            foreach (var value in Data)
            {
                multiSum += value.Item1 * value.Item2;

                sumX2 += Math.Pow(value.Item1, 2);
                sumY2 += Math.Pow(value.Item2, 2);
            }

            return multiSum / (Math.Sqrt(sumX2) * Math.Sqrt(sumY2));
        }
    }
}