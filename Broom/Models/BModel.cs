using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broom.Models
{
    public class BModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Model of Bike")]
        [Display(Name = "Model")]
        [StringLength(255)]
        public string Name { get; set; }

        public Make Make { get; set; }

        [ForeignKey("Make")]
        public int MakeId { get; set; }
    }
}
