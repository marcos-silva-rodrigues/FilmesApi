using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Filme;
using FilmesApi.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
	public class FilmeService
	{
		private AppDbContext _context;
		private IMapper _mapper;

		public FilmeService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
		{
			Filme filme = _mapper.Map<Filme>(filmeDto);
			this._context.Filmes.Add(filme);
			_context.SaveChanges();

			return _mapper.Map<ReadFilmeDto>(filme);
		}

		public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
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
				return readFilmeDtos;
			}

			return null;
		}

		public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
		{
			Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

			if (filme != null)
			{
				_mapper.Map(filmeDto, filme);
				_context.SaveChanges();
				return Result.Ok();
			}

			return Result.Fail("Filme não encontrado");

		}

		public ReadFilmeDto RecuperaFilmePorId(int id)
		{
			Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
			if (filme != null)
			{
				ReadFilmeDto readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
				readFilmeDto.HoraDaConsulta = DateTime.Now;
				return readFilmeDto;
			}

			return null;
			
		}

		public Result DeletaFilme(int id)
		{
			Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

			if (filme == null) return Result.Fail("Filme não encontrado");


			_context.Remove(filme);
			_context.SaveChanges();

			return Result.Ok();
		}
	}
}
