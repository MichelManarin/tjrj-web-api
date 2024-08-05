using CloudBooks.API.Core.Services;
using CloudBooks.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json");
ConfigureServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowLocalhost");

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    );

    services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000", 
                                    "https://tjrj-react-production.up.railway.app")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });

    services.AddTransient<IAssuntoRepository, AssuntoRepository>();
    services.AddTransient<IReportRepository, ReportRepository>();
    services.AddTransient<IAutorRepository, AutorRepository>(); 
    services.AddTransient<ILivroRepository, LivroRepository>();
    services.AddTransient<IAutorService, AutorService>();
    services.AddTransient<IAssuntoService, AssuntoService>();
    services.AddTransient<ILivroService, LivroService>();
    services.AddTransient<IReportService, ReportService>();
    services.AddTransient<ICanalRepository, CanalRepository>();
    services.AddTransient<IPrecificacaoRepository, PrecificacaoRepository>();
    services.AddTransient<ICanalService, CanalService>();
    services.AddTransient<IPrecificacaoService, PrecificacaoService>();
}
