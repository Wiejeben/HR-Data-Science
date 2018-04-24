using System;
using System.Collections.Generic;
using System.IO;
using Data_Mining.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace Data_Mining.Pages
{
    public class ClusterModel : PageModel
    {
        public List<Point> Points { get; private set; }
        public int MaxHeight { get; set; }
        public int MaxWidth { get; set; }
        public Cluster Cluster { get; set; }

        public void OnGet()
        {
            Cluster = GetInitialCluster("datasets/WineData.csv");
        }

        /**
         * Get initial cluster based on binary values.
         */
        private Cluster GetInitialCluster(string fileName)
        {
            Cluster = new Cluster("Initial", "lightgray");

            // Read dataset
            using (var reader = new StreamReader(fileName))
            {
                var height = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    MaxWidth = values.Length;

                    var width = 0;
                    foreach (var value in values)
                    {
                        // Register coordinates of locations where the value is "1"
                        if (value == "1")
                        {
                            Cluster.Add(new Point(width, height));
                        }

                        width++;
                    }

                    height++;
                }

                MaxHeight = height;
            }
        }
    }
}