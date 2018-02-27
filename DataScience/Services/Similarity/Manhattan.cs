using System;
using System.Collections.Generic;
using System.Linq;

namespace DataScience.Services.Similarity
{
    public class Manhattan : Similarity
    {
        public Manhattan(List<Tuple<double, double>> data) : base(data)
        {
        }

        public Manhattan(IReadOnlyList<double> x, IReadOnlyList<double> y) : base(x, y)
        {
        }

        public double Distance()
        {
            return (from value in Data select Math.Abs(value.Item1 - value.Item2)).Sum();
        }

        public override double Calculate()
        {
            return 1 / (1 + Distance());
        }
    }
}