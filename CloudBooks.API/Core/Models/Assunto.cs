public class Assunto
{
    public int CodAs { get; set; }
    public string Descricao { get; set; }

    public virtual ICollection<Livro_Assunto> Livro_Assuntos { get; set; }

    public Assunto()
    {
        Livro_Assuntos = new HashSet<Livro_Assunto>();
    }

    public Assunto(int codAs, string descricao) : this()
    {
        CodAs = codAs;
        Descricao = descricao;
    }

    public Assunto(string descricao) : this()
    {
        Descricao = descricao;
    }
}