using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace  Desafio.Business.Services
{

    public class PessoaService : IPessoaService
    {

        private readonly IPessoaRepository _pessoaRepository;
        
        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
            
            await _pessoaRepository.Adicionar(pessoa);
            return pessoa;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            
            await _pessoaRepository.Atualizar(pessoa);
            return pessoa;
        }

        public async Task<Pessoa> BuscarPorID(int id)
        {
           return await _pessoaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Pessoa>> BuscarTodos()
        {
           return await _pessoaRepository.ObterTodos();
        }

        public async Task Remover(int id)
        {
            var pessoa = await _pessoaRepository.ObterPorId(id);

            await _pessoaRepository.Remover(pessoa);
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
        }

    }


}