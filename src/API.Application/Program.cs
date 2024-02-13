using CrossCutting.DependencyInjection;
using CrossCutting.OthersConfiguration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesRepository(builder.Services);

ConfigureAuthentication.ConfigureDependenciesAuthentication(builder.Services, builder.Configuration);

ConfigureAutoMapper.ConfigureDependenciesAutoMapper(builder.Services);

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

    cs.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Entre com o Token JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    cs.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
    });
});

var app = builder.Build();

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
