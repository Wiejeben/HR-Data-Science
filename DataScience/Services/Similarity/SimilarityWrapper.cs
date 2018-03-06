using System;
using System.Collections.Generic;
using DataScience.Models.UserItem;

namespace DataScience.Services.Similarity
{
    /// <summary>
    /// Collects all the different similarity strategies for easy result comparison.
    /// </summary>
    public class SimilarityWrapper
    {
        /// <summary>
        /// Two complete lists that are to be compared.
        /// </summary>
        protected readonly SimilarityList Data;

        /// <summary>
        /// Converts two lists together based on the articles.
        /// </summary>
        public SimilarityWrapper(SimilarityList data)
        {
            Data = data;
        }

        /// <summary>
        /// Calculate similarity based on euclidean.
        /// </summary>
        public double Euclidean()
        {
            var similarity = new Euclidean(Data);
            return similarity.Calculate();
        }

        /// <summary>
        /// Calculate similarity based on manhattan.
        /// </summary>
        public double Manhattan()
        {
            var similarity = new Manhattan(Data);
            return similarity.Calculate();
        }

        /// <summary>
        /// Calculate similarity based on pearson correlation coefficient.
        /// </summary>
        public double Pearson()
        {
            var similarity = new Pearson(Data);
            return similarity.Calculate();
        }

        /// <summary>
        /// Calculate similarity based on Cosine.
        /// </summary>
        public double Cosine()
        {
            var similarity = new Cosine(Data);
            return similarity.Calculate();
        }
    }
}