﻿using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Filme;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            this._context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(
                    nameof(RecuperaFilmePorId),
                    new { Id = filme.Id },
                    filme
                );
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes;
			if (classificacaoEtaria == null)
            {
				filmes = _context.Filmes.ToList();
			}
            else
            {
				filmes = _context.Filmes
	                .Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria)
	                .ToList();
			}

			if (filmes != null)
			{
				List<ReadFilmeDto> readFilmeDtos = _mapper.Map<List<ReadFilmeDto>>(filmes);
				return Ok(readFilmeDtos);
			}
			return NotFound();

		}

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                ReadFilmeDto readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
                readFilmeDto.HoraDaConsulta = DateTime.Now;
                return Ok(readFilmeDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();

            _mapper.Map(filmeDto, filme);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();


            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
