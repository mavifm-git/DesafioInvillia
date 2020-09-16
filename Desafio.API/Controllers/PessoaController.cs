using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Business.Interfaces;
using Desafio.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IEmprestimoService _emprestimoService;
        private readonly IPessoaRepository _pessoaRepository;
        

        public PessoaController(IPessoaService pessoaService, IPessoaRepository pessoaRepository, IEmprestimoService emprestimoService)
        {
            _pessoaService = pessoaService;
            _pessoaRepository = pessoaRepository;
            _emprestimoService = emprestimoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> ObterTodos()
        {
            try
            {
                return Ok(await _pessoaService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pessoa>> ObterPorId(int id)
        {
            Pessoa pessoa;

            try
            {
                pessoa = await _pessoaService.BuscarPorID(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            if (pessoa == null) return NotFound();

            return pessoa;
        }


        [HttpPost]
        public async Task<ActionResult<Pessoa>> Adicionar(Pessoa pessoa)
        {
            try
            {
                await _pessoaService.Adicionar(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(pessoa);
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar(Pessoa pessoa)
        {

            if (!_pessoaRepository.Buscar(p => p.Id == pessoa.Id).Result.Any())
            {
                return NotFound();
            }

            try
            {
                await _pessoaService.Atualizar(pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(pessoa);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pessoa>> Excluir(int id)
        {
            if (!_pessoaRepository.Buscar(p => p.Id == id).Result.Any())
            {
                return NotFound();
            }

            try
            {
                await _pessoaService.Remover(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok("Excluido com Sucesso !!!");
        }



    }


}