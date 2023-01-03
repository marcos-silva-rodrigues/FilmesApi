﻿using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoFK { get; set; }
        public int GerenteFK { get; set; }
    }
}
