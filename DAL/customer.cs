namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            tickets = new HashSet<ticket>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string full_name { get; set; }

        [Required]
        [StringLength(15)]
        public string phone_number { get; set; }

        public int? points { get; set; }

        public DateTime? created_at { get; set; }

        public string password { get; set; }
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> tickets { get; set; }
    }
}
