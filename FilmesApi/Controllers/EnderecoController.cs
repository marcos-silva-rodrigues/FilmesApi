using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data;
using AutoMapper;
using FilmesApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FilmesApi.Data.Dtos.Cinema;
using FluentResults;
using FilmesApi.Services;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService service;

		public EnderecoController(EnderecoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto endereco = service.Adiciona(enderecoDto);

			return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public List<ReadEnderecoDto> RecuperaEndereco()
        {
            return service.BuscaTodos();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            ReadEnderecoDto endereco = service.BuscaPorId(id);

            if (endereco != null)
            {
                return NotFound();
            }
            return Ok(endereco);
		}

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result = service.AtualizaEndereco(id, enderecoDto);

            if (result.IsFailed) return NotFound();

			return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
			Result result = service.DeletaPorId(id);

			if (result.IsFailed) return NotFound();

			return NoContent();
		}
    }
}
