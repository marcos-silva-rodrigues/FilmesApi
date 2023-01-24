using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Cinema;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
	public class CinemaService
	{

		private AppDbContext _context;
		private IMapper _mapper;

		public CinemaService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadCinemaDto Adiciona(CreateCinemaDto dto)
		{
			Cinema cinema = _mapper.Map<Cinema>(dto);
			_context.Cinemas.Add(cinema);
			_context.SaveChanges();

			return _mapper.Map<ReadCinemaDto>(cinema);
		}

		public List<ReadCinemaDto> BuscaCinemas(string? nomeDoFilme)
		{
			List<Cinema> cinemas = _context.Cinemas.ToList();
			if (cinemas != null)
			{
				if (string.IsNullOrEmpty(nomeDoFilme))
				{
					IEnumerable<Cinema> query = from cinema in cinemas
												where cinema.Sessoes.Any(sessao =>
												sessao.Filme.Titulo == nomeDoFilme)
												select cinema;
					cinemas = query.ToList();
				}
				return _mapper.Map<List<ReadCinemaDto>>(cinemas);
			}

			return null;
		}

		public ReadCinemaDto BuscaPorId(int id)
		{
			Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

			if (cinema != null) return _mapper.Map<ReadCinemaDto>(cinema);

			return null;
		}

		public Result AtualizaCinema(int id, UpdateCinemaDto updateCinema)
		{
			Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
			if (cinema == null)
			{
				return Result.Fail("Cinema não encontrado");
			}

			_mapper.Map(updateCinema, cinema);
			_context.SaveChanges();
			return Result.Ok();
		}

		public Result DeletaPorId(int id)
		{
			Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
			if (cinema == null)
			{
				return Result.Fail("Cinema não encontrado");
			}
			_context.Remove(cinema);
			_context.SaveChanges();

			return Result.Ok();
		}
	}
}
