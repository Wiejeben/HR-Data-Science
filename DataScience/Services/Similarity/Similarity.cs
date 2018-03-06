using System;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    /// <summary>
    /// Base implementation for all similarity calculations.
    /// </summary>
    public abstract class Similarity
    {
        protected readonly SimilarityList Data;

        protected Similarity(SimilarityList data)
        {
            Data = data;
        }

        public abstract double Calculate();
    }
}