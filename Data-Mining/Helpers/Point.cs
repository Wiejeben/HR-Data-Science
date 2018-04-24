namespace Data_Mining.Helpers
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override string ToString()
        {
            return "{ x:  " + X + ", y: " + Y + " }";
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}