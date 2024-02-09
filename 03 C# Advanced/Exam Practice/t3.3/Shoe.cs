using System.Text;

namespace ShoeStore
{
    public class Shoe
    {
        public Shoe(string brand, string type, double size, string material)
        {
            Brand = brand;
            Type = type;
            Size = size;
            Material = material;
        }

        public string Brand { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
        public string Material { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Size {Size}, {Material} {Brand} {Type} shoe.");

            return result.ToString().Trim();
        }
    }
}
