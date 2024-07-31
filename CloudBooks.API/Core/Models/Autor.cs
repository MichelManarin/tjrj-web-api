public class Autor
{
    public int CodAu { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<Livro_Autor> Livro_Autores { get; set; }

    public Autor()
    {
        Livro_Autores = new HashSet<Livro_Autor>();
    }
    public Autor(int codAu, string nome) : this()
    {
        CodAu = codAu;
        Nome = nome;
    }

    public Autor(string nome) : this()
    {
        Nome = nome;
    }
}