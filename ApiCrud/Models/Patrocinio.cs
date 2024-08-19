using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCrud.NewFolder
{
    public class Patrocinio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que el valor es autogenerado
        [Column("Id")]
        public int Id { get; set; } // Número de Identificación Tributaria (clave primaria)


        [Column("Empresa")]
        [Required]
        [StringLength(255)] // Asume una longitud máxima, ajusta si es necesario
        public string Empresa { get; set; } // Nombre de la empresa

        [Column("NIT")]
        [Required]
        public int NIT { get; set; } // Número de Identificación Tributaria

        [Column("Representante")]
        [Required]
        [StringLength(255)] // Asume una longitud máxima, ajusta si es necesario
        public string Representante { get; set; } // Nombre del representante

        [Column("Telefono")]
        [Required]
        public int Telefono { get; set; } // Número de teléfono

        [Column("Pais")]
        [Required]
        [StringLength(100)] // Asume una longitud máxima, ajusta si es necesario
        public string Pais { get; set; } // País de la empresa
    }
}

