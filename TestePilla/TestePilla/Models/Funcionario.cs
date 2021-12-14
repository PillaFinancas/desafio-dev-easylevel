using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestePilla.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo número é obrigatório")] 
        public string Nome { get; set; }   
        [Required(ErrorMessage = "O campo número é obrigatório")]
        [Display(Name = "Salário")]
        [DataType(DataType.Currency)]
        public string Salario { get; set; }
    }
}
