using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Desafio.Business.Interfaces
{
    public interface IPessoaService : IDisposable
    {
        Task<Pessoa> BuscarPorID(int id);
        Task<IEnumerable<Pessoa>> BuscarTodos();
        Task<Pessoa> Adicionar(Pessoa contato);
        Task<Pessoa> Atualizar(Pessoa contato);
        Task Remover(int id);


    }
}