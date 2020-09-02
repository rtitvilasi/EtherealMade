using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMadeFin.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductSubTitle { get; set; }
        public string ProductImage { get; set; }
        public string ProductPrice { get; set; }
        public string ProductWeight { get; set; }
        public string ProductDescription { get; set; }
        public string ProductThemeColour { get; set; }
        public string CheckoutLink { get; set; }
        public string Module1Title { get; set; }
        public string Module1Description { get; set; }
        public string Module1Image { get; set; }

        public virtual ProductCategory Productcategory { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
