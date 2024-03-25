using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Logistics_Api.Models
{
    public class Logistics
    {
        public int Id { get; set; }

        public string? Product_Name { get; set; }

        public int? Quantity { get; set; }

        public string? Ownername { get; set; }

        public int? Package_Id { get; set; }

        public DateTime? Packed_Date { get; set; }

        public DateTime? Expected_Date { get; set; }

        public decimal? Price { get; set; }

        public string? Delivery_Status { get; set; }

        public string? From_Location { get; set; }

        public string? To_Location { get; set; }
    }
}


