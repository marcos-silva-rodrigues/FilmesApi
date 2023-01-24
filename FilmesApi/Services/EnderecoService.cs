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
	public class EnderecoService
	{

		private AppDbContext _context;
		private IMapper _mapper;

		public EnderecoService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public ReadEnderecoDto Adiciona(CreateEnderecoDto dto)
		{
			Endereco endereco = _mapper.Map<Endereco>(dto);
			_context.Enderecos.Add(endereco);
			_context.SaveChanges();

			return _mapper.Map<ReadEnderecoDto>(endereco);
		}

		public ReadEnderecoDto BuscaPorId(int id)
		{
			Endereco endereco = _context.Enderecos.FirstOrDefault(gerente => gerente.Id == id);

			if (endereco != null)
			{
				ReadEnderecoDto readEnderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
				return readEnderecoDto;
			}

			return null;
		}

		public List<ReadEnderecoDto> BuscaTodos()
		{
			List<Endereco> listaDeEndercos = _context.Enderecos.ToList();
			return _mapper.Map<List<ReadEnderecoDto>>(listaDeEndercos);
		}

		public Result AtualizaEndereco(int id, UpdateEnderecoDto updateEndereco)
		{
			Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

			if (endereco == null) return Result.Fail("Endereco não encontrado");

			_mapper.Map(updateEndereco, endereco);
			_context.SaveChanges();
			return Result.Ok();
		}

		public Result DeletaPorId(int id)
		{
			Endereco endereco = _context.Enderecos.FirstOrDefault(gerente => gerente.Id == id);

			if (endereco == null)
			{
				return Result.Fail("Endereço não foi encontrado");

			}
			_context.Remove(endereco);
			_context.SaveChanges();
			return Result.Ok();
		}
	}
}
