﻿namespace TaskEquipment.Models
{
    public class Equipment
    {
        public string Eqpmt_No { get; set; }

        public string Eqpmt_size { get; set; }

        public string Eqpmt_type { get; set; }

        public DateOnly Manuf_date { get; set; }

        public string Equipment_owner { get; set; }

        public string Equipment_photo { get; set; }
        public string Isp_doc { get; set; }
    }
}
