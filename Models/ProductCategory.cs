using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMadeFin.Models
{
    public class ProductCategory
{
        [Key]
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryExtraDescription { get; set; }
        public string CategoryImageUrl { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
