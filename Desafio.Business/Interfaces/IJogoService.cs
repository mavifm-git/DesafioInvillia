using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Business.Interfaces
{
    public interface IJogoService : IDisposable
    {
        Task<Jogo> BuscarPorID(int id);
        Task<IEnumerable<Jogo>> BuscarTodos();
        Task<Jogo> Adicionar(Jogo jogo);
        Task<Jogo> Atualizar(Jogo jogo);
        Task Remover(int id);

    }
}
