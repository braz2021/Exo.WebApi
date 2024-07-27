using System.ComponentModel.DataAnnotations;

namespace Exo.WebApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }  = string.Empty;

        [Required]
        public string Senha { get; set; }  = string.Empty;
    }
}
