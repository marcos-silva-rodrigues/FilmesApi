using AutoMapper;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
	public class GerenteProfiler: Profile
	{
		public GerenteProfiler()
		{
			CreateMap<CreateGerenteDTO, Gerente>();
			CreateMap<Gerente, ReadGerenteDTO>();
		}
	}
}
