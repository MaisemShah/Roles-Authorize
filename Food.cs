using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Data
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FID { get; set; }
        public string Fruits { get; set; }
        public string Veggies { get; set; }
        public string Meats { get; set; }
        public int DID { get; set; }
        [ForeignKey("DID")]
        public Drink Drinks { get; set; }
    }
}
