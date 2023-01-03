using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Cinema
{
    public class ReadEnderecoDto
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }    
        public object Endereco { get; set; }
    }
}
