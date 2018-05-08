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

        public Cluster(string color, Point centroid = null)
        {
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
                    backgroundColor: '" + Color + @"',
                    borderWidth: 0,
                    pointHoverBorderWidth: 0,
                    pointRadius: 10,
                    pointHoverRadius: 10,
                    data: [" + Centroid.ToJson() + @"],
                },";
            }

            return centroidData + @"{
                backgroundColor: '" + Color + @"',
                borderWidth: 0,
                pointHoverBorderWidth: 0,
                pointRadius: 5,
                pointHoverRadius: 5,
                data: [" + data.TrimEnd(',') + @"]
            }";
        }
    }
}