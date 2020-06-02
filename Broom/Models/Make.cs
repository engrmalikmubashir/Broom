using System.ComponentModel.DataAnnotations;

namespace Broom.Models
{
    public class Make
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Make of Bike")]
        [Display(Name = "Make")]
        [StringLength(255)]
        public string Name { get; set; }

    }
}
