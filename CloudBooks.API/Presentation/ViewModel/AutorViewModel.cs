using System.ComponentModel.DataAnnotations;

namespace CloudBooks.API.Presentation.ViewModel
{
    public class AutorViewModel
    {

        public int CodAu { get; set; }

        [Required(ErrorMessage = "Nome é requerido.")]
        [StringLength(200, ErrorMessage = "Nome não pode ser maior que 200 characters.")]
        public string Nome { get; set; }

       
        public AutorViewModel(int codAu, string nome)
        {
            Nome = nome;
            CodAu = codAu;
        }
    }
}
