using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data_Mining.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Data_Mining.Pages
{
    public class ClusterModel : PageModel
    {
        public int MaxHeight { get; set; }
        public int MaxWidth { get; set; }
        public List<Cluster> Dataset { get; set; }

        public void OnGet()
        {
            Dataset = new List<Cluster>();
            Dataset.Add(GetInitialCluster("datasets/WineData.csv"));

            // Add random clusters
            var kCount = HttpGetQuery("k");
            var seedQuery = HttpGetQuery("seed");
            if (kCount != "" && seedQuery != "")
            {
                var successOne = Int16.TryParse(kCount, out var amount);
                var successTwo = Int16.TryParse(seedQuery, out var seed);
                if (successOne && successTwo)
                {
                    GenerateClusters(amount, seed);
                }
            }

            if (HttpGetQuery("assign") == "true")
            {
                var points = new List<Point>();
                var clusters = new List<Cluster>();

                // Flatten all clusters
                foreach (var cluster in Dataset)
                {
                    points = points.Concat(cluster).ToList();
                    if (cluster.Centroid != null)
                    {
                        clusters.Add(new Cluster(cluster.Color, cluster.Centroid));
                    }
                }

                // Assign points to cluster
                foreach (var point in points)
                {
                    double? closestDistance = null;
                    Cluster closestCluster = null;

                    // Check for the closest cluster to the current point position.
                    foreach (var cluster in clusters)
                    {
                        var distance = Math.Sqrt(Math.Pow(cluster.Centroid.X - point.X, 2) +
                                                 Math.Pow(cluster.Centroid.Y - point.Y, 2));

                        if (closestDistance == null || distance < closestDistance)
                        {
                            closestDistance = distance;
                            closestCluster = cluster;
                        }
                    }

                    if (closestDistance != null && closestCluster != null)
                    {
                        closestCluster.Add(point);
                    }
                }

                // Apply centroids to new clusters collection.
                Dataset = clusters;
            }
        }

        private void GenerateClusters(int amount, int seed)
        {
            // Define 10 unique, easily distinguishable colors.
            var colors = new string[]
            {
                "red",
                "green",
                "blue",
                "orange",
                "purple",
                "yellow",
                "brown",
                "lime",
                "pink",
                "brass",
                "aero"
            };

            var random = new Random(seed);
            for (var i = 0; i < amount; i++)
            {
                var centroid = new Point(random.Next(0, MaxWidth), random.Next(0, MaxHeight));
                Dataset.Add(new Cluster(colors[i % (colors.Length - 1)], centroid));
            }
        }

        private string HttpGetQuery(string key)
        {
            return HttpContext.Request.Query[key].ToString();
        }

        /**
         * Get initial cluster based on binary values.
         */
        private Cluster GetInitialCluster(string fileName)
        {
            var cluster = new Cluster("lightgray");

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
                            cluster.Add(new Point(width, height));
                        }

                        width++;
                    }

                    height++;
                }

                MaxHeight = height;
            }

            return cluster;
        }
    }
}