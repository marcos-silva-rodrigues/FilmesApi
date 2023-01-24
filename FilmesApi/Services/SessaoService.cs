using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using FluentResults;
using System.Linq;

namespace FilmesApi.Services
{
	public class SessaoService
	{

		private AppDbContext _context;
		private IMapper _mapper;

		public SessaoService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadSessaoDto Adiciona(CreateSessaoDto dto)
		{
			Sessao sessao = _mapper.Map<Sessao>(dto);
			_context.Sessoes.Add(sessao);
			_context.SaveChanges();

			return _mapper.Map<ReadSessaoDto>(sessao);
		}

		public ReadSessaoDto BuscaPorId(int id)
		{
			Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
			if (sessao != null)
			{
				return _mapper.Map<ReadSessaoDto>(sessao);
			}
			return null;
		}

	}
}
