﻿using System.Collections.Generic;
using System.IO;

namespace DataScience.Services
{
    public static class DataSetLoader
    {
        /// <summary>
        /// Get dataset by filename from the datasets directory.
        /// </summary>
        public static List<string[]> Load(string fileName)
        {
            var result = new List<string[]>();

            using (var reader = new StreamReader("Datasets/" + fileName + ".data"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line != null) result.Add(line.Split(','));
                }
            }

            return result;
        }
    }
}