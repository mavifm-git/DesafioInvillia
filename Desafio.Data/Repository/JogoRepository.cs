using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using Desafio.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Desafio.Data.Repository
{
    public class JogoRepository : Repository<Jogo>, IJogoRepository
    {
        public JogoRepository(DesafioDbContext context) : base(context)
        {

        }

    }
}
