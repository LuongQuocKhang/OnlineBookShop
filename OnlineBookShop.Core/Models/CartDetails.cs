using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Core.Models
{
    public class CartDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public string Voucher { get; set; } = "";
        public virtual Cart Cart { get; set; } 
    }
}
