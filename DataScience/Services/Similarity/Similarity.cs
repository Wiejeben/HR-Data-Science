using System;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    public abstract class Similarity
    {
        protected readonly List<Tuple<double, double>> Data;

        protected Similarity(List<Tuple<double, double>> data)
        {
            Data = data;
        }

        protected Similarity(IReadOnlyList<double> x, IReadOnlyList<double> y)
        {
            Data = SimilarityList.Create(x, y);
        }

        public abstract double Calculate();
    }
}