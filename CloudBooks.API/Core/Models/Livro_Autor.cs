using System;

public class Livro_Autor
{
    public int Livro_Codl { get; set; }
    public int Autor_CodAu { get; set; }

    public virtual Livro Livro { get; set; }
    public virtual Autor Autor { get; set; }
}