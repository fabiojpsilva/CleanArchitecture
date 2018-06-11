using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanDemo.Core;

namespace CleanDemo.Entities
{
    public partial class Curso : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public decimal CargaHorariaHoras { get; set; }
    }
}
