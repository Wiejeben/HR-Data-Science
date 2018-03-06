using System;
using System.Collections.Generic;
using System.Linq;

namespace DataScience.Services.Similarity
{
    public class Manhattan : Similarity
    {
        public Manhattan(SimilarityList data) : base(data)
        {
        }

        public double Distance()
        {
            return (from value in Data.Data select Math.Abs(value.Item1 - value.Item2)).Sum();
        }

        public override double Calculate()
        {
            return 1 / (1 + Distance());
        }
    }
}