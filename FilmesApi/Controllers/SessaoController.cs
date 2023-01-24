using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SessaoController: ControllerBase
	{
		private SessaoService service;

		public SessaoController(SessaoService service)
		{
			this.service = service;
		}

		[HttpPost]
		public IActionResult AdicionaSessao(CreateSessaoDto dto)
		{
			ReadSessaoDto sessao = service.Adiciona(dto);

			return CreatedAtAction(nameof(RecuperaSessaoPorId),
				new { Id = sessao.Id, }, sessao);
		}

		[HttpGet("{id}")]
		public IActionResult RecuperaSessaoPorId(int id)
		{
			ReadSessaoDto sessao = service.BuscaPorId(id);

			if (sessao != null)
			{
				return Ok(sessao);
			}
			return NotFound();
		}
	}
}
