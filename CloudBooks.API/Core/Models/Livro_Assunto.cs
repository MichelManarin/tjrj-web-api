using System;

public class Livro_Assunto
{
    public int Livro_Codl { get; set; }
    public int Assunto_CodAs { get; set; }

    public virtual Livro Livro { get; set; }
    public virtual Assunto Assunto { get; set; }
}