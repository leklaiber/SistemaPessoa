using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entity
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Data de Nascimento obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Range(0, 999)]
        public int Idade { get; set; }

        public decimal Dinheiro { get; set; }
    }
}
