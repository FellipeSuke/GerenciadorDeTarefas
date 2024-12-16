using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [Required]
        public string Status { get; set; } = "Pendente"; // Valores: "Pendente" ou "Concluída" como solicitado (sem prazos de expiração)
    }
}
