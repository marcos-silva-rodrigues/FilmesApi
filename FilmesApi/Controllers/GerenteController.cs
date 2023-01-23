using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Filme;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FilmesApi.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class GerenteController : ControllerBase

	{
		private GerenteService service;

		public GerenteController(GerenteService service)
		{
			this.service = service;
		}

		[HttpPost]
		public IActionResult AdicionaGerente(CreateGerenteDTO dto)
		{
			ReadGerenteDTO novoGerente =  service.Adiciona(dto);

			return CreatedAtAction(
				nameof(RecuperaGerentePorId),
				new { Id = novoGerente.Id },
				novoGerente
			);
		}

		[HttpGet("/{id}")]
		private IActionResult RecuperaGerentePorId(int id)
		{
			ReadGerenteDTO resultado = service.BuscaPorId(id);

			if (resultado == null) return NotFound();

			return Ok(resultado);
		}

		[HttpDelete("/{id}")]
		private IActionResult DeletaGerentePorId(int id)
		{
			Result resultado = service.DeletaPorId(id);

			if (resultado.IsFailed) return NotFound();

			return NoContent();

		}
	}
}
