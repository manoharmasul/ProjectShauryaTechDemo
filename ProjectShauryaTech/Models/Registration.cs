using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.Models
{
    [Table("Users")]
    public class Registration
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Uid { get; set; }

        [Required(ErrorMessage ="Name is required")]

        public string Uname { get; set; }

        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        public int RId { get; set; }
    }
}
