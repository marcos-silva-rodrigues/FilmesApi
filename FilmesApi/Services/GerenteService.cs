using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using FluentResults;
using System.Linq;

namespace FilmesApi.Services
{
	public class GerenteService
	{

		private AppDbContext _context;
		private IMapper _mapper;

		public GerenteService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadGerenteDTO Adiciona(CreateGerenteDTO dto)
		{
			Gerente gerente = _mapper.Map<Gerente>(dto);
			_context.Gerentes.Add(gerente);
			_context.SaveChanges();

			return _mapper.Map<ReadGerenteDTO>(gerente);
		}

		public ReadGerenteDTO BuscaPorId(int id)
		{
			Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

			if (gerente != null)
			{
				ReadGerenteDTO readGerenteDto = _mapper.Map<ReadGerenteDTO>(gerente);
				return readGerenteDto;
			}

			return null;
		}

		public Result DeletaPorId(int id)
		{
			Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

			if (gerente == null)
			{
				return Result.Fail("Gerente não foi encontrado");

			}
			_context.Remove(gerente);
			_context.SaveChanges();
			return Result.Ok();
		}
	}
}
