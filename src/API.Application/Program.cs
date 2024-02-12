using CrossCutting.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cs =>
{
    cs.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Curso de API em DDD com .NET 8",
        Description = "Utilizando .NET Core 8 na prática para o desenvolvimento de uma API na arquitetura DDD (Domain Driven Design)",
        TermsOfService = new Uri("https://github.com/carl0sR0ma0/Curso_API_NetCore_DDD"),
        Contact = new OpenApiContact
        {
            Name = "Carlos Vinícius Pereira Romão",
            Email = "cvpromao@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/carlos-rom%C3%A3o-22ba15bb/")
        },
        License = new OpenApiLicense
        {
            Name = "Termo de Licença de uso",
        }
    });
});

ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesRepository(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(cs =>
    {
        cs.SwaggerEndpoint("/swagger/v1/swagger.json", "API - v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
