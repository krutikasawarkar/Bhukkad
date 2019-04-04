using System.ComponentModel.DataAnnotations;

namespace Bhulakkad.Model
{
    public class LoginDetail
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Provide Site Name")]
        [MaxLength(10)]
        public string Site { get; set; }

        [Required(ErrorMessage = "Provide User Name")]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Provide Password")]
        [MaxLength(100)]
        public string Password { get; set; }

    }
}