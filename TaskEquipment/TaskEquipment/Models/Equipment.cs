using System.ComponentModel.DataAnnotations;

namespace TaskEquipment.Models
{
    public class Equipment
    {
        [Key]
        public int Eqpmt_Id{get;set;}
        public string Eqpmt_No { get; set; }

        public int Eqpmt_size { get; set; }

        public string Eqpmt_type { get; set; }

        public DateTime Manuf_date { get; set; }

        public string Equipment_owner { get; set; }

        public IFormFile Equipment_photo { get; set; }
        public IFormFile Isp_doc { get; set; }

    }
}