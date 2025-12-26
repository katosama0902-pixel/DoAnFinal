namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class movie
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string movie_id { get; set; }

        [Required]
        [StringLength(200)]
        public string movie_name { get; set; }

        [StringLength(50)]
        public string genre { get; set; }

        public decimal price { get; set; }

        public int capacity { get; set; }

        [StringLength(500)]
        public string movie_image { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
