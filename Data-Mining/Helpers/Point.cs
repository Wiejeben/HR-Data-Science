using Newtonsoft.Json;

namespace Data_Mining.Helpers
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y)
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