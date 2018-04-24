using System.Collections.Generic;
using System.IO;
using Data_Mining.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Data_Mining.Pages
{
    public class ClusterModel : PageModel
    {
        public List<Point> Points { get; private set; }

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

                    height++;
                }
            }

            Points = data;
        }

        public string PointsToJson()
        {
            var result = "";

            foreach (var point in Points)
            {
                result += point.ToJson() + ",";
            }

            return "[" + result + "]";
        }
    }
}