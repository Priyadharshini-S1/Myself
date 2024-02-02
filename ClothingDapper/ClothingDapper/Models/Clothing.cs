namespace ClothingDapper.Models
{
    public class Clothing
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int price { get; set; }

        public string size { get; set; }

        public string color { get; set; }

        public string gender { get; set; }

        public bool InStock { get; set; }

        public int count { get; set; }

        public DateTime AddedDate { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
