using Aplicacao.Interfaces;
using Aplicacao.Services;
using Aplicacao.Dtos;
using AutoMapper;
using Dominio;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Infraestrutura.Interfaces;
using Infraestrutura.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["ConnectionStrings:MySQL"];

builder.Services.AddDbContext<MySQLContext>(options => options.
                UseMySql(connection,
                        new MySqlServerVersion(
                            new Version(8, 0, 27))));

var config = new AutoMapper.MapperConfiguration(cfg =>
    {
        cfg.CreateMap<ReceitaDto, ReceitaDominio>().ReverseMap();
        cfg.CreateMap<DespesaDto, DespesaDominio>().ReverseMap();
        cfg.CreateMap<ResumoDto, ResumoDominio>().ReverseMap();
    });

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IReceitaService, ReceitaService>();

builder.Services.AddScoped<IReceitaRepository, ReceitaRepository>();

builder.Services.AddScoped<IDespesaService, DespesaService>();

builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();

builder.Services.AddScoped<IResumoService, ResumoService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
