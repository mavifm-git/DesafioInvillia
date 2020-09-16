using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using Desafio.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.Repository
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(DesafioDbContext context) : base(context)
        {

        }


        public async Task<Emprestimo> ObterEmprestimosPessoaJogo(int idEmprestimo)
        {
            return await Db.Emprestimo.AsNoTracking()
               .Include(e => e.Pessoa)
               .Include(e => e.Jogo)
               .FirstOrDefaultAsync(e => e.Id == idEmprestimo);

        }

        public async Task<IEnumerable<Emprestimo>> ObterTodosEmprestimosPessoaJogo()
        {
            return await Db.Emprestimo.AsNoTracking()
               .Include(e => e.Pessoa)
               .Include(e => e.Jogo)
               .OrderBy(e=>e.DataDevolucao)
               .ToListAsync();
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosPessoa(int idPessoa)
        {
            return await Db.Emprestimo.AsNoTracking()
               .Include(p => p.Pessoa)
               .Include(p => p.Jogo)
               .Where(p => p.PessoaId == idPessoa && p.DataDevolucao == null)
               .ToListAsync();
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimosJogo(int idJogo)
        {
            return await Db.Emprestimo.AsNoTracking()
                .Include(p => p.Pessoa)
                .Include(p => p.Jogo)
                .Where(p => p.JogoId == idJogo)
                .OrderBy(p=>p.DataDevolucao)
                .ToListAsync();
        }


    }
}
