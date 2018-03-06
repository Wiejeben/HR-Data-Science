using System;
using System.Collections.Generic;

namespace DataScience.Services.Similarity
{
    /// <summary>
    /// Base implementation for all similarity calculations.
    /// </summary>
    public interface Similarity
    {
        double Calculate(SimilarityList data);
    }
}