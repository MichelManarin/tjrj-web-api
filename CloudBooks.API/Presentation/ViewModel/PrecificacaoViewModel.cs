using System.ComponentModel.DataAnnotations;

namespace CloudBooks.API.Presentation.ViewModel
{
    public class PrecificacaoViewModel
    {
        [Required(ErrorMessage = "O código do canal de venda é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código do canal deve ser um número inteiro positivo.")]
        public int CodCa { get; set; }

        [Required(ErrorMessage = "O código do livro é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O código do livro deve ser um número inteiro positivo.")]
        public int Codl { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        public PrecificacaoViewModel(int codCa, int codl, decimal preco)
        {
            CodCa = codCa;
            Codl = codl;
            Preco = preco;
        }
    }
}
