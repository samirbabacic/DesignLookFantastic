using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lookFantastic.Models
{
    public class ClothingShop
    {
        [Key]
        public int Id { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string Name { get; set; }
        public float ReviewGrade { get; set; }
        public int NumberGrades { get; set; }
    }
}