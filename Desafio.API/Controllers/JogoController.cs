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
    public class JogoController : ControllerBase
    {
        private readonly IJogoService _jogoService;
        private readonly IEmprestimoService _emprestimoService;
        private readonly IJogoRepository _jogoRepository;

        public JogoController(IJogoService jogoService, IEmprestimoService emprestimoService, IJogoRepository jogoRepository)
        {
            _jogoService = jogoService;
            _emprestimoService = emprestimoService;
            _jogoRepository = jogoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogo>>> ObterTodos()
        {
            try
            {
                return Ok(await _jogoService.BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Jogo>> ObterPorId(int id)
        {
            Jogo jogo;

            try
            {
                jogo = await _jogoService.BuscarPorID(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            if (jogo == null) return NotFound();

            return jogo;
        }


        [HttpPost]
        public async Task<ActionResult<Jogo>> Adicionar(Jogo jogo)
        {
            try
            {
                await _jogoService.Adicionar(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(jogo);
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar(Jogo jogo)
        {

            if (!_jogoRepository.Buscar(p => p.Id == jogo.Id).Result.Any())
            {
                return NotFound();
            }

            try
            {
                await _jogoService.Atualizar(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(jogo);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Jogo>> Excluir(int id)
        {
            if (!_jogoRepository.Buscar(p => p.Id == id).Result.Any())
            {
                return NotFound();
            }

            try
            {
                await _jogoService.Remover(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok("Excluido com Sucesso !!!");
        }


    }


}