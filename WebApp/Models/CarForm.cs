using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CarForm
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Type")]
        [Required]
        public string Type { get; set; }
        [Display(Name = "Consumption")]
        [Required]
        public double Consumption { get; set; }
        [Display(Name = "Price")]
        [Required]
        public int Price { get; set; }
        [Display(Name = "YearOfManufacture")]
        [Required]
        public int YearOfManufacture { get; set; }
        [Display(Name = "Tachometer")]
        [Required]
        public int Tachometer { get; set; }
        [Display(Name = "Fuel")]
        [Required]
        public string Fuel { get; set; }
    }
}
