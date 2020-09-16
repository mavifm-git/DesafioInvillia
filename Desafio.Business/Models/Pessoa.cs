using System.Collections.Generic;

namespace Desafio.Business.Models
{
    public class Pessoa : Entity
    {  
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        /* EF Relation */
        public IEnumerable<Emprestimo> Emprestimo { get; set; }
    }
}