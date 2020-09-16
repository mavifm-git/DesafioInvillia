using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Business.Interfaces
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {

        Task<IEnumerable<Emprestimo>> ObterEmprestimosJogo(int idJogo);

        Task<IEnumerable<Emprestimo>> ObterTodosEmprestimosPessoaJogo();

        Task<IEnumerable<Emprestimo>> ObterEmprestimosPessoa(int idPessoa);

        Task<Emprestimo> ObterEmprestimosPessoaJogo(int idEmprestimo);

    }
}
