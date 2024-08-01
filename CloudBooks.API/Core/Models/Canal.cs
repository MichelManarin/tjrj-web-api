using System.ComponentModel.DataAnnotations;

namespace CloudBooks.API.Core.Models
{
    public class Canal
    {
        [Key]
        public int CodCa { get; set; }

        [Required]
        public string Nome { get; set; } 

    }
}
