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
        public string Type { get; set; } //Vidaus, Isores, Nestandartines

        [Required]
        public string Model { get; set; } //Feneruotos, Dazytos, Specialios
        public string DoorLeaf { get; set; } // framework from spruce or pine wood, fibre board, veneer, a stuff-paper grating.

        public string DoorJamb { get; set; } // spruce or pine wood, fibreboard, veneer, thickness*width - 40*94 mm (standart), seal in jamb.

        public string Hinges { get; set; } // produced by Finland, Spain or Switzerland.

        public string Finish { get; set; } // varnish;
        public int Height { get; set; }
        public int Width { get; set; }

        [Required]
        public int Price { get; set; }
        public string Additions { get; set; } // glass, seal in jumb, stain;
    }
}
