using CloudBooks.API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ConnectionContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ConnectionContext(DbContextOptions<ConnectionContext> options, IConfiguration configuration)
            : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Assunto> Assuntos { get; set; }
    public DbSet<Livro_Autor> Livro_Autores { get; set; }
    public DbSet<Livro_Assunto> Livro_Assuntos { get; set; }
    public DbSet<LivrosPorAutorViewModel> LivrosPorAutorView { get; set; }
    public DbSet<Canal> Canais { get; set; }
    public DbSet<Precificacao> Precificacoes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Livro>()
            .HasKey(l => l.Codl);

        modelBuilder.Entity<Autor>()
            .HasKey(a => a.CodAu);

        modelBuilder.Entity<Assunto>()
            .HasKey(a => a.CodAs);

        modelBuilder.Entity<Livro_Autor>()
            .HasKey(la => new { la.Livro_Codl, la.Autor_CodAu });

        modelBuilder.Entity<Livro_Autor>()
            .HasOne(la => la.Livro)
            .WithMany(l => l.Livro_Autores)
            .HasForeignKey(la => la.Livro_Codl);

        modelBuilder.Entity<Livro_Autor>()
            .HasOne(la => la.Autor)
            .WithMany(a => a.Livro_Autores)
            .HasForeignKey(la => la.Autor_CodAu);

        modelBuilder.Entity<Livro_Assunto>()
            .HasKey(la => new { la.Livro_Codl, la.Assunto_CodAs });

        modelBuilder.Entity<Livro_Assunto>()
            .HasOne(la => la.Livro)
            .WithMany(l => l.Livro_Assuntos)
            .HasForeignKey(la => la.Livro_Codl);

        modelBuilder.Entity<Livro_Assunto>()
            .HasOne(la => la.Assunto)
            .WithMany(a => a.Livro_Assuntos)
            .HasForeignKey(la => la.Assunto_CodAs);

        modelBuilder.Entity<LivrosPorAutorViewModel>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("LivrosPorAutorView");
        });

        modelBuilder.Entity<Canal>()
           .HasKey(c => c.CodCa);

        modelBuilder.Entity<Precificacao>()
            .HasKey(p => p.CodPr);

        modelBuilder.Entity<Precificacao>()
            .HasOne(p => p.CanalVenda)
            .WithMany() 
            .HasForeignKey(p => p.CodCa);

        modelBuilder.Entity<Precificacao>()
            .HasOne(p => p.Livro)
            .WithMany()
            .HasForeignKey(p => p.Codl);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}