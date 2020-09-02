using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EtherealMadeFin.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentCreated { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public virtual Product Product { get; set; }
    }
}
