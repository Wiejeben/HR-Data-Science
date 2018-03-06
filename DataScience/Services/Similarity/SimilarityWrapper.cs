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
            return Calculate(new Euclidean());
        }

        /// <summary>
        /// Calculate similarity based on manhattan.
        /// </summary>
        public double Manhattan()
        {
            return Calculate(new Manhattan());
        }

        /// <summary>
        /// Calculate similarity based on pearson correlation coefficient.
        /// </summary>
        public double Pearson()
        {
            return Calculate(new Pearson());
        }

        /// <summary>
        /// Calculate similarity based on Cosine.
        /// </summary>
        public double Cosine()
        {
            return Calculate(new Cosine());
        }

        /// <summary>
        /// Performs calculation on similarity service.
        /// </summary>
        private double Calculate(Similarity similarity)
        {
            return similarity.Calculate(Data);
        }
    }
}