namespace OnlineBookShop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminAccount")]
    public partial class AdminAccount
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(15)]
        public string AdminName { get; set; }

        [StringLength(15)]
        public string AdminPassword { get; set; }
    }
}
