namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ticket
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string movie_id { get; set; }

        public int? customer_id { get; set; }

        public int staff_id { get; set; }

        public int seat_number { get; set; }

        public decimal price { get; set; }

        public DateTime? created_at { get; set; }

        public virtual customer customer { get; set; }

        public virtual user user { get; set; }
    }
}
