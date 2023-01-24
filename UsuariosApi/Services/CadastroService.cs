using System;
using UsuariosApi.Data.Dto;
using FluentResults;
using AutoMapper;
using UsuariosApi.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace UsuariosApi.Services
{
	internal class CadastroService
	{
		private IMapper _mapper;
		private UserManager<IdentityUser<int>> _userManager;
		public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager)
		{
			_mapper = mapper;
			_userManager = userManager;
		}

		internal Result CadastroUsuario(CreateUsuarioDto dto)
		{
			Usuario usuario = _mapper.Map<Usuario>(dto);
			IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
			Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(usuarioIdentity, dto.Password);

			if (resultadoIdentity.Result.Succeeded) return Result.Ok();

			return Result.Fail("Falha ao cadastrar o usuário");
		}
	}
}