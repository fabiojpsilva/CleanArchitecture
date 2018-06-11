using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanDemo.Core;

namespace CleanDemo.Entities
{
    public partial class Turma : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        [Required]
        public int CursoId { get; set; }

        public Curso Curso { get; set; }
    }
}
