using System;
using System.Linq;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    public class Euclidean : Similarity
    {
        public double Distance(SimilarityList data)
        {
            return Math.Sqrt((from value in data.Data select Math.Pow(value.Item1 - value.Item2, 2)).Sum());
        }

        public double Calculate(SimilarityList data)
        {
            return 1 / (1 + Distance(data));
        }
    }
}