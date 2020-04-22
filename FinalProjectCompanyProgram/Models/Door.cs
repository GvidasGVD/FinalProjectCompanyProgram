using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCompanyProgram.Models
{
    public class Door
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } //Inside, Outside, 

        [Required]
        public string Model { get; set; } //Feneruotos, Dazytos, Specialios
        [Display(Name = "Door Leaf")]
        public string DoorLeaf { get; set; } // framework from spruce or pine wood, fibre board, veneer, a stuff-paper grating.
        [Display(Name = "Door Jamb")]
        public string DoorJamb { get; set; } // spruce or pine wood, fibreboard, veneer, thickness*width - 40*94 mm (standart), seal in jamb.

        public string Hinges { get; set; } // produced by Finland, Spain or Switzerland.

        public string Finish { get; set; } // varnish;

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        [Display(Name = "Height in cm")]
        public int Height { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        [Display(Name = "Width in cm")]
        public int Width { get; set; }

        [Required]
        [Range(0.01, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        [Display(Name = "Price in cents")]
        public float Price { get; set; }
        public string Additions { get; set; } // glass, seal in jumb, stain;
    }
}
