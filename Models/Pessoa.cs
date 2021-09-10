using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace api.Models
{
    public class Pessoa
    {
        
        [Key]
        
        public int Id { get; set; }

        public string Nome { get; set; } 

        public string Sobrenome { get; set; }

        public string Email { get; set; }

    }
}