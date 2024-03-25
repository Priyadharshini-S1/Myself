namespace Logistics_Api.Models
{
    public class Package
    {
        public string? Product_name { get; set; }
        public int? Quantity { get; set;}
        public string? Ownername { get; set; }

        public DateTime? Packed_date { get; set; }

        public DateTime? Expected_date { get; set;}

        public int? Price { get; set; }

        
    }
}
