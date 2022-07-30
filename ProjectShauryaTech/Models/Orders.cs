using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Oid { get; set; }
        public int Uid { get; set; }
        public int Pid { get; set; }
        public int Qty { get; set; }
    }
}
