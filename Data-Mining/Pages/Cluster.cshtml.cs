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

        public void OnGet()
        {
            var data = new List<Point>();
            // Read dataset
            using (var reader = new StreamReader("datasets/WineData.csv"))
            {
                int height = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    int width = 0;
                    foreach (string value in values)
                    {
                        if (value == "1")
                        {
                            // Register coordinates of locations where the value is "1"
                            data.Add(new Point(width, height));
                        }

                        width++;
                    }

                    MaxWidth = width;
                    height++;
                }
                MaxHeight = height; 
            }

            Points = data;
        }

        /**
         * Output points as JSON array.
         */
        public string PointsToJson()
        {
            var result = "";

            foreach (var point in Points)
            {
                result += point.ToJson() + ",";
            }

            return "[" + result + "]";
        }

        public string RandomPositions(int amount)
        {
            var result = "";
            var random = new Random();

            for (int i = 0; i < amount; i++)
            {
                var point = new Point(random.Next(0, MaxWidth), random.Next(0, MaxHeight));

                result += point.ToJson() + ",";
            }

            return "[" + result + "]";
        }
    }
}