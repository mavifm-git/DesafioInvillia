using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Business.Models;
using Desafio.Business.Interfaces;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly IEmprestimoRepository _emprestimoRepository;


        public EmprestimoController(IEmprestimoService emprestimoService, IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoService = emprestimoService;;
            _emprestimoRepository = emprestimoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> ObterTodos()
        {
            try
            {
                return Ok(await _emprestimoService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Emprestimo>> ObterPorId(int id)
        {
            Emprestimo emprestimo;

            try
            {
                emprestimo = await _emprestimoService.BuscarPorID(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            if (emprestimo == null) return NotFound();

            return emprestimo;
        }


        [HttpPost]
        public async Task<ActionResult<Emprestimo>> Adicionar(Emprestimo emprestimo)
        {
            try
            {
                await _emprestimoService.Adicionar(emprestimo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(emprestimo);
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar(Emprestimo emprestimo)
        {

            if (!_emprestimoRepository.Buscar(p => p.Id == emprestimo.Id).Result.Any())
            {
                return NotFound();
            }

            try
            {
                await _emprestimoService.Atualizar(emprestimo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(emprestimo);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pessoa>> Excluir(int id)
        {
            if (!_emprestimoRepository.Buscar(p => p.Id == id).Result.Any())
            {
                return NotFound();
            }

            try
            {
                await _emprestimoService.Remover(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok("Excluido com Sucesso !!!");
        }




    }
}