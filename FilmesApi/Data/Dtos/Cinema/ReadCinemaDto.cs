using FilmesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }    
        public Endereco Endereco { get; set; }

        public Models.Gerente Gerente { get; set; }
    }
}
