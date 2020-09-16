using System;

namespace Desafio.Business.Models
{
    public class Emprestimo : Entity
    {
        public int JogoId { get; set; }
        public int PessoaId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }


        /* EF Relation */
        public Pessoa Pessoa { get; set; }
        public Jogo Jogo { get; set; }
    }
}
