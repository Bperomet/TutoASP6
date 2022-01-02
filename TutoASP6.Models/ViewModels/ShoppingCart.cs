using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoASP6.Models.ViewModels
{
    public class ShoppingCart
    {
        //prop
        public Product product { get; set; }

        [Range(1,1000, ErrorMessage ="Pleaz enter a value betweeen 1 and 1000")]
        public int Count { get; set; }
    }
}
