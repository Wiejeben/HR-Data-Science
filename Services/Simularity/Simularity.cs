using System;
using System.Collections.Generic;

namespace DataScience.Services.Simularity
{
    public abstract class Simularity
    {
        protected readonly List<Tuple<double, double>> Values;

        protected Simularity(List<Tuple<double, double>> values)
        {
            Values = values;
        }

        protected Simularity(IReadOnlyList<double> x, IReadOnlyList<double> y)
        {
            Values = SimularityList.Create(x, y);
        }
        
        public abstract double Calculate();
    }
}