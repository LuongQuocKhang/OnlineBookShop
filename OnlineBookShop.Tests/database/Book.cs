namespace OnlineBookShop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string BookId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Link { get; set; }

        [StringLength(255)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublishDay { get; set; }

        [StringLength(10)]
        public string Publisher { get; set; }

        [StringLength(10)]
        public string CoverType { get; set; }

        public double? Price { get; set; }

        public int? PageNum { get; set; }

        public int? Quantity { get; set; }

        [StringLength(10)]
        public string status { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Catagory { get; set; }

        public bool? isDeleted { get; set; }
    }
}
