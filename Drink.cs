using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Data
{
    public class Drink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        public string Sodas { get; set; }
        public string Juices { get; set; }
        [Display(Name = "Energy Drinks")]
        public string EDrinks { get; set; }
    }
}
