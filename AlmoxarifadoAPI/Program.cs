using AlmoxarifadoDomain.NomeDaPasta;
using AlmoxarifadoInfrastructure.Data;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<xAlmoxarifadoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDBSQL")));

//Carregando Classes de Repositories
builder.Services.AddScoped<xAlmoxarifadoContext>();
builder.Services.AddScoped<IGrupoRepository,GrupoRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoInfrastructure.Data.Repositories;
using AlmoxarifadoServices;
using Microsoft.EntityFrameworkCore;
using static AlmoxarifadoInfrastructure.Data.Repositories.ConexaoBancoRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddSingleton<PrimeiraConexao>(sp => new PrimeiraConexao(builder.Configuration));
builder.Services.AddSingleton<ReplicaConexao>(sp => new ReplicaConexao(builder.Configuration));

builder.Services.AddSingleton<AlmoxarifadoInfrastructure.Data.ConexaoBancoService>();

builder.Services.AddDbContext<xAlmoxarifadoContext>((serviceProvider, options) =>
{
    var conexaoBancoService = serviceProvider.GetRequiredService<AlmoxarifadoInfrastructure.Data.ConexaoBancoService>();
    var connectionString = conexaoBancoService.GetConnectionString();
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<xAlmoxarifadoContext>();

builder.Services.AddScoped<IItensNotaRepository, ItensNotaRepository>();
builder.Services.AddScoped<ItensNotaService>();
builder.Services.AddScoped<IItensRequisicaoRepository, ItensRequisicaoRepository>();
builder.Services.AddScoped<ItensRequisicaoService>();
builder.Services.AddScoped<INotaFiscalRepository, NotasFiscaisRepository>();
builder.Services.AddScoped<NotaFiscalService>();
builder.Services.AddScoped<IRequisicoesRepository, RequisicoesRepository>();
builder.Services.AddScoped<RequisicaoService>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<EstoqueService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();