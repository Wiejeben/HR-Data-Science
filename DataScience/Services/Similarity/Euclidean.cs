using System;
using System.Linq;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    public class Euclidean : Similarity
    {
        public Euclidean(List<Tuple<double, double>> data) : base(data)
        {
        }

        public Euclidean(IReadOnlyList<double> x, IReadOnlyList<double> y) : base(x, y)
        {
        }

        public double Distance()
        {
            return Math.Sqrt((from value in Data select Math.Pow(value.Item1 - value.Item2, 2)).Sum());
        }

        public override double Calculate()
        {
            return 1 / (1 + Distance());
        }
    }
}