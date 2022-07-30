using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Pid { get; set; }
        [Required(ErrorMessage ="Product name is required")]
        [Display(Name ="Product Name")]
        [DataType(DataType.Text)]
        public string Pname { get; set; }
        [Required(ErrorMessage ="Company name is required")]
        [Display(Name ="Company Name")]
        [DataType(DataType.Text)]       
        public string Company { get; set; }
        [Required(ErrorMessage ="Price is required")]
        public double Price { get; set; }
        public int Cid { get; set; }
        public int Uid { get; set; }
    }
}
