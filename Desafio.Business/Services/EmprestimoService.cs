using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Business.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IJogoRepository _jogoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, IJogoRepository jogoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _jogoRepository = jogoRepository;
        }


        public async Task<Emprestimo> Adicionar(Emprestimo emprestimo)
        {
            await _emprestimoRepository.Adicionar(emprestimo);

            var jogo = await _jogoRepository.ObterPorId(emprestimo.JogoId);
            jogo.Emprestado = true;

            await _jogoRepository.Atualizar(jogo);

            return emprestimo;
        }


        public async Task<Emprestimo> Atualizar(Emprestimo emprestimo)
        {
            await _emprestimoRepository.Atualizar(emprestimo);
            return emprestimo;
        }


        public async Task<IEnumerable<Emprestimo>> BuscarTodos()
        {
            return await _emprestimoRepository.ObterTodos();
        }


        public async Task<Emprestimo> BuscarPorID(int id)
        {
            return await _emprestimoRepository.ObterPorId(id);
        }


        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosPessoa(int idPessoa)
        {
            return await _emprestimoRepository.ObterEmprestimosPessoa(idPessoa);
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosJogo(int idJogo)
        {
            return await _emprestimoRepository.ObterEmprestimosJogo(idJogo);
        }


        public async Task<Emprestimo> ObterEmprestimosPessoaJogo(int idEmprestimo)
        {
            return await _emprestimoRepository.ObterEmprestimosPessoaJogo(idEmprestimo);
        }

        public async Task<IEnumerable<Emprestimo>> ObterTodosEmprestimosPessoaJogo()
        {
            return await _emprestimoRepository.ObterTodosEmprestimosPessoaJogo();
        }


        public async Task Remover(int id)
        {
            var emprestimo = await _emprestimoRepository.ObterEmprestimosPessoaJogo(id);

            var jogo = emprestimo.Jogo;
            jogo.Emprestado = false;

             await _jogoRepository.Atualizar(jogo);

             await _emprestimoRepository.Remover(emprestimo);
        }


        public async Task<Emprestimo> Devolver(Emprestimo emprestimo)
        {
            await _emprestimoRepository.Atualizar(emprestimo);

            var jogo = await _jogoRepository.ObterPorId(emprestimo.JogoId);
            jogo.Emprestado = false;

            await _jogoRepository.Atualizar(jogo);

            return emprestimo;
        }


        public void Dispose()
        {
            _emprestimoRepository.Dispose();
        }

    }
}
