using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public ICollection<AppUser>? Users { get; set; }
    }
}
