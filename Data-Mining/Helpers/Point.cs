using Newtonsoft.Json;

namespace Data_Mining.Helpers
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        /**
         * Converts current object to a JSON object.
         */
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this).ToLower();
        }
    }
}