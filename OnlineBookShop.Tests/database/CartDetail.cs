namespace OnlineBookShop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartDetail
    {
        public int ID { get; set; }

        public int CartId { get; set; }

        public string BookId { get; set; }

        public int Quantity { get; set; }

        public string Voucher { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
