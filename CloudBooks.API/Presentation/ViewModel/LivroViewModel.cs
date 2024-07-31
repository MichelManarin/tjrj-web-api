using System.ComponentModel.DataAnnotations;

namespace CloudBooks.API.Presentation.ViewModel
{
    public class LivroViewModel
    {
        public int Codl { get; set; }

        [Required(ErrorMessage = "Título é requerido.")]
        [StringLength(200, ErrorMessage = "Título não pode ser maior que 200 characters.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Editora é requerido.")]
        [StringLength(200, ErrorMessage = "Editora não pode ser maior que 200 characters.")]
        public string Editora { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Edição deve ser maior que 0.")]
        public int Edicao { get; set; }

        [Required(ErrorMessage = "Ano de publicação é requerido.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Ano de publicação deve estar no formato yyyy.")]
        public string AnoPublicacao { get; set; }

        [MinLength(1, ErrorMessage = "Pelo menos um autor deve ser selecionado.")]
        public List<int> AutoresIds { get; set; } = new List<int>();

        [MinLength(1, ErrorMessage = "Pelo menos um assunto deve ser selecionado.")]

        public List<int> AssuntosIds { get; set; } = new List<int>();

        public List<Assunto> Assuntos { get; set; } = new List<Assunto>();

        public List<Autor> Autores { get; set; } = new List<Autor>();

        public LivroViewModel()
        {
        }

        public LivroViewModel(
            int codl,
            string titulo,
            string editora,
            int edicao,
            string anoPublicacao,
            List<Assunto> assuntos,
            List<Autor> autores
        )
        {
            Codl = codl;
            Titulo = titulo;
            Editora = editora;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            Assuntos = assuntos;
            Autores = autores;
        }
    }
}
