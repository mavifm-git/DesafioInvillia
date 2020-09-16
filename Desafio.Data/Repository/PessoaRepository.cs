using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using Desafio.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
 
        public PessoaRepository(DesafioDbContext context) : base(context)
        {
            
        }

    }
}
