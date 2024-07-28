using System.ComponentModel.DataAnnotations;

namespace TesteMvc.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public string CPF { get; set; } = string.Empty;

        [Required]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Endereco { get; set; } = string.Empty;
    }
}
