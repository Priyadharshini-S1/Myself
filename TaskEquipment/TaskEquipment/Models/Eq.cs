using System.ComponentModel.DataAnnotations;

namespace TaskEquipment.Models
{
    public class Eq
    {
        [Key]
        public int Eqpmt_Id{get;set;}
        public string Eqpmt_No { get; set; }

        public string Eqpmt_size { get; set; }

        public string Eqpmt_type { get; set; }

        public DateTime Manuf_date { get; set; }

        public string Equipment_owner { get; set; }

        public byte[] Equipment_photo { get; set; }
        public byte[] Isp_doc { get; set; }

    }
        
    }
