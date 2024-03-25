namespace Logistics_Api.Models
{
    public class Track
    {
        public string Product_name { get; set; }
        public DateTime? Packed_date { get; set; }
        public DateTime? Expected_date { get; set; }
        public string Delivery_status { get; set; }

        public string From_location { get; set; }
        public string To_location { get; set;}

    }
}
