using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace zasylogicApi.Models
{
    public class AtencionCliente
    {
        [Key]
        public int AtencionClienteId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nombre { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Apellidos { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Celular { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string Sexo { get; set; }

        [Column(TypeName = "nvarchar(1)")]
        public string Motivo { get; set; }

        public DateTime Fecha_Alta { get; set; }
    }
}
