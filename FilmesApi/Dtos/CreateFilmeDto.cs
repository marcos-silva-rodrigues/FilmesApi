using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Dtos
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
    }
}
