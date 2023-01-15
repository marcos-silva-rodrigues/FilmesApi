﻿using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Filme;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FilmesApi.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class GerenteController : ControllerBase

	{
		private AppDbContext _context;
		private IMapper _mapper;

		public GerenteController(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpPost]
		public IActionResult AdicionaGerente(CreateGerenteDTO dto)
		{
			Gerente gerente = _mapper.Map<Gerente>(dto);
			_context.Gerentes.Add(gerente);
			_context.SaveChanges();

			return CreatedAtAction(
				nameof(RecuperaGerentePorId),
				new { Id = gerente.Id },
				gerente
			);
		}

		[HttpGet("/{id}")]
		private IActionResult RecuperaGerentePorId(int id)
		{
			Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

			if (gerente != null)
			{
				ReadGerenteDTO readGerenteDto = _mapper.Map<ReadGerenteDTO>(gerente);
				return Ok(readGerenteDto);
			}

			return NotFound();
		}

		[HttpDelete("/{id}")]
		private IActionResult DeletaGerentePorId(int id)
		{
			Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

			if (gerente == null)
			{
				return NotFound();

			}
			_context.Remove(gerente);
			_context.SaveChanges();
			return NoContent();

		}
	}
}
