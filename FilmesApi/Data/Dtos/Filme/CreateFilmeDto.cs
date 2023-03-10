using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Filme
{
    public class CreateFilmeDto
    {

        [Required(ErrorMessage = "o campo titulo é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "o campo diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração dever ter no mínimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }

		[Range(1, 18, ErrorMessage = "A Classificação dever ser no mínimo 1 e no máximo 18")]
		public int ClassificacaoEtaria { get; set; }
	}
}
