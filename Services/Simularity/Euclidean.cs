using System;
using System.Linq;
using System.Collections.Generic;

namespace DataScience.Services.Simularity
{
    public class Euclidean : Simularity
    {
        public Euclidean(List<Tuple<double, double>> values) : base(values)
        {
        }

        public Euclidean(IReadOnlyList<double> x, IReadOnlyList<double> y) : base(x, y)
        {
        }

        public double Distance()
        {
            return Math.Sqrt((from value in Values select Math.Pow(value.Item1 - value.Item2, 2)).Sum());
        }

        public override double Calculate()
        {
            return 1 / (1 + Distance());
        }
    }
}