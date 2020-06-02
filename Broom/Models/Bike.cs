using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Broom.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        [RegularExpression("^[1-9]*$",ErrorMessage = "Select Manufecturer")]
   [Display(Name = "Manufecturer")]
        public int MakeID { get; set; }

        public BModel BModel { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Model")]
        [Display(Name = "Model")]
        public int BModelID { get; set; }

        [Required(ErrorMessage = "Year Is Required!")]
        [Range(1, int.MaxValue, ErrorMessage = "Provide Valid Mileage")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Mileage Is Required!")]
        [Range(1,int.MaxValue,ErrorMessage = "Provide Valid Mileage")]
        public int Mileage { get; set; }

        public string Features { get; set; }

        [Display(Name = "Seller Name")]
        [Required(ErrorMessage = "Seller Name Is Required!")]
        public string SellerName { get; set; }

        [Display(Name = "Seller Email")]
        public string SellerEmail { get; set; }

        [Display(Name = "Seller Phone")]
        [Required(ErrorMessage = "Seller Phone Is Required!")]
        public string SellerPhone { get; set; }

        [Required(ErrorMessage = "Price Is Required!")]
        public int Price { get; set; }

        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Currency Is Required!")]
        [Display(Name = "Currency")]
        public string Currency { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

    }
}
