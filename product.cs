namespace store
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [Key]
        public int idProduct { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public byte[] image { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        [Required]
        [StringLength(50)]
        public string reference { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public int idCategory { get; set; }

        public virtual category category { get; set; }
    }
}
