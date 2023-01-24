using Microsoft.AspNetCore.Mvc;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Filme;
using AutoMapper;
using FilmesApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FilmesApi.Data.Dtos.Cinema;
using Castle.Core.Internal;
using FilmesApi.Services;
using FluentResults;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService service;

        public CinemaController(CinemaService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto cinema = service.Adiciona(cinemaDto);

            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> cinemas = service.BuscaCinemas(nomeDoFilme);
            if (cinemas == null) return NotFound();
            return Ok(cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
			ReadCinemaDto cinema = service.BuscaPorId(id);

            if (cinema == null) return NotFound();
            return Ok(cinema);   
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
			Result resultado = service.AtualizaCinema(id, cinemaDto);
			if (resultado.IsFailed) return NotFound();

			return NoContent();
		}

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = service.DeletaPorId(id);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }
    }
}
