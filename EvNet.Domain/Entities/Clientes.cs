using System.ComponentModel.DataAnnotations;

namespace EvNet.Domain.Entities
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El domicilio es obligatorio.")]
        public string Domicilio { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato de email no es válido.")]
        public string Email { get; set; } = string.Empty;

        public string? Password { get; set; }

        public int IdCiudad { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<Facturas> Facturas { get; set; } = [];
    }
}
