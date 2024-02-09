using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }
        public int Count { get { return Shoes.Count; } }

        public string AddShoe(Shoe shoe)
        {
            if (Count < StorageCapacity)
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            return "No more space in the storage room.";
        }
        public int RemoveShoes(string material)
        {
            List<Shoe> shoeMaterial = Shoes.Where(s => s.Material == material).ToList();
            int count = shoeMaterial.Count;
            foreach (Shoe shoe in shoeMaterial)
            {
                Shoes.Remove(shoe);
            }
            return count;
        }
        
        public List<Shoe> GetShoesByType(string type)
        {
            type = type.ToLower();
            List<Shoe> shoes = Shoes.Where(t => t.Type == type).ToList();

            return shoes;
        }

        public Shoe GetShoeBySize(double size)
        {
            Shoe shoe = Shoes.Where((t) => t.Size == size).FirstOrDefault();
            return shoe;
        }

        public string StockList(double size, string type)
        {
            StringBuilder result = new StringBuilder();

            List<Shoe> shoe = Shoes.Where(t => t.Size == size)
                .Where(t => t.Type == type).ToList();
            
            if (shoe.Count == 0)
            {
                return "No matches found!";
            }

            result.AppendLine($"Stock list for size {size} - {type} shoes:");

            foreach (var s in shoe)
            {
                result.AppendLine(s.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
