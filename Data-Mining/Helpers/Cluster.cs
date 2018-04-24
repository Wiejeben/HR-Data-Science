using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Data_Mining.Helpers
{
    public class Cluster : List<Point>
    {
        public string Label { get; set; }
        public string Color { get; set; }
        public Point Centroid { get; set; }

        public Cluster(string label, string color, Point centroid = null)
        {
            Label = label;
            Color = color;
            Centroid = centroid;
        }

        public string ToJson()
        {
            var data = "";
            foreach (var point in this)
            {
                data += point.ToJson() + ",";
            }

            var centroidData = "";
            if (Centroid != null)
            {
                centroidData = @"{
                    label: '" + Label + @" - Centroid',
                    backgroundColor: '" + Color + @"',
                    borderWidth: 0,
                    pointRadius: 10,
                    data: [" + Centroid.ToJson() + @"],
                },";
            }
            
            return centroidData + @"
                {
                    label: '" + Label + @"',
                    backgroundColor: '" + Color + @"',
                    borderWidth: 0,
                    pointRadius: 5,
                    data: [" + data + @"],
                }
            ";
        }
    }
}