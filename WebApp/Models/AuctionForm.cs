using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class AuctionForm
    {
        public int id { get; set; }
        [Display(Name = "Částka")]
        [Required]
        public int bid { get; set; }
    }
}
