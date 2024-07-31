using CloudBooks.API.Presentation.ViewModel;

public class Livro
{
    public int Codl { get; set; }
    public string Titulo { get; set; }
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; }

    public virtual ICollection<Livro_Autor> Livro_Autores { get; set; }
    public virtual ICollection<Livro_Assunto> Livro_Assuntos { get; set; }

    public Livro()
    {
        Livro_Autores = new HashSet<Livro_Autor>();
        Livro_Assuntos = new HashSet<Livro_Assunto>();
    }

    public Livro(
        int codl, 
        string titulo, 
        string editora, 
        int edicao, 
        string anoPublicacao
    ) : this()
    {
       Codl = codl;
       Titulo = titulo;
       Editora = editora;
       Edicao = edicao;
       AnoPublicacao = anoPublicacao;
    }

    public Livro(
        string titulo, 
        string editora, 
        int edicao, 
        string anoPublicacao
    ) : this()
    {
        Titulo = titulo;
        Editora = editora;
        Edicao = edicao;
        AnoPublicacao = anoPublicacao;
    }
}