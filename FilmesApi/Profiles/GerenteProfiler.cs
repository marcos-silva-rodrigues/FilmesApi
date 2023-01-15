using AutoMapper;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using System.Linq;

namespace FilmesApi.Profiles
{
	public class GerenteProfiler: Profile
	{
		public GerenteProfiler()
		{
			CreateMap<CreateGerenteDTO, Gerente>();
			CreateMap<Gerente, ReadGerenteDTO>()
				.ForMember(gerente => gerente.Cinemas, opts => opts
				.MapFrom(gerente => gerente.Cinemas.Select
				(c => new { c.Id, c.Nome, c.Endereco })));
		}
	}
}
