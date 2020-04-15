using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectCompanyProgram.Models
{

    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is required")]
        //[Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        //[Required]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
