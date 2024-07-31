using System.ComponentModel.DataAnnotations;

namespace CloudBooks.API.Presentation.ViewModel
{
    public class AssuntoViewModel
    {
        public int CodAs { get; set; }

        [Required(ErrorMessage = "Descricao é requerida.")]
        [StringLength(200, ErrorMessage = "Descrição não pode ser maior que 200 characters.")]
        public string Descricao { get; set; }

        public AssuntoViewModel(int codAs, string descricao)
        {
            CodAs = codAs;
            Descricao = descricao;
        }
    }
}

