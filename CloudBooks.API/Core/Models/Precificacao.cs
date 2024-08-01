using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CloudBooks.API.Core.Models
{
    public class Precificacao
    {
        [Key]
        public int? CodPr { get; set; } 

        [ForeignKey("Canal")]
        public int CodCa { get; set; }

        [ForeignKey("Livro")]
        public int Codl { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public decimal Preco { get; set; } = 0;

        public virtual Canal CanalVenda { get; set; } 
        public virtual Livro Livro { get; set; }

        public Precificacao(int? codPr, int codCa, int codl, decimal preco)
        {
            CodPr = codPr;
            CodCa = codCa;
            Codl = codl;
            Preco = preco;
            DataCriacao = DateTime.UtcNow;
        }

    }
}
