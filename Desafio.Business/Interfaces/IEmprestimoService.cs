using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Business.Interfaces
{
    public interface IEmprestimoService : IDisposable
    {
        Task<Emprestimo> BuscarPorID(int id);
        Task<IEnumerable<Emprestimo>> BuscarTodos();
        Task<Emprestimo> Adicionar(Emprestimo emprestimo);
        Task<Emprestimo> Atualizar(Emprestimo emprestimo);
        Task Remover(int id);

        Task<IEnumerable<Emprestimo>> ObterEmprestimosJogo(int idJogo);

        Task<IEnumerable<Emprestimo>> ObterEmprestimosPessoa(int idPessoa);

        Task<Emprestimo> ObterEmprestimosPessoaJogo(int idEmprestimo);

        Task<IEnumerable<Emprestimo>> ObterTodosEmprestimosPessoaJogo();

        Task<Emprestimo> Devolver(Emprestimo emprestimo);
    }
}