using System;
using System.Linq;
using System.Collections.Generic;

namespace DataScience.Services.Simularity
{
    public class Manhattan : Simularity
    {
        public Manhattan(List<Tuple<double, double>> values) : base(values)
        {
        }

        public Manhattan(IReadOnlyList<double> x, IReadOnlyList<double> y) : base(x, y)
        {
        }

        public double Distance()
        {
            return (from value in Values select Math.Abs(value.Item1 - value.Item2)).Sum();
        }

        public override double Calculate()
        {
            return 1 / (1 + Distance());
        }
    }
}