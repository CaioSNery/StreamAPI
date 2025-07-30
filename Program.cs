using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stream.Data;
using Stream.Interfaces;
using Stream.Services;
using StreamAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IViewService, ViewService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ISerieService, SerieService>();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEpisodioService, EpisodioService>();
builder.Services.AddScoped<ITemporadaService, TemporadaService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();


app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();





app.Run();

