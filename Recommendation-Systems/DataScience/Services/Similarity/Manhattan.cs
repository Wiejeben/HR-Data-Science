using System;
using System.Collections.Generic;
using System.Linq;

namespace DataScience.Services.Similarity
{
    public class Manhattan : Similarity
    {
        public double Distance(SimilarityList data)
        {
            return (from value in data.Data select Math.Abs(value.Item1 - value.Item2)).Sum();
        }

        public double Calculate(SimilarityList data)
        {
            return 1 / (1 + Distance(data));
        }
    }
}