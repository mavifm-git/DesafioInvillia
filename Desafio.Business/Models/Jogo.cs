using System.Collections.Generic;


namespace Desafio.Business.Models
{
    public class Jogo : Entity
    {
        public string Nome { get; set; }

        public bool Emprestado { get; set; }

        /* EF Relation */
        public IEnumerable<Emprestimo> Emprestimo { get; set; }
    }
}
