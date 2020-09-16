using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Business.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<Jogo> Adicionar(Jogo jogo)
        {
            await _jogoRepository.Adicionar(jogo);
            return jogo;
        }

        public async Task<Jogo> Atualizar(Jogo jogo)
        {
            await _jogoRepository.Atualizar(jogo);
            return jogo;
        }

        public async Task<Jogo> BuscarPorID(int id)
        {
            return await _jogoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Jogo>> BuscarTodos()
        {
            return await _jogoRepository.ObterTodos();
        }



        public async Task Remover(int id)
        {

            var jogo = await _jogoRepository.ObterPorId(id);
            await _jogoRepository.Remover(jogo);
        }

        public void Dispose()
        {
            _jogoRepository.Dispose();
        }
    }
}
