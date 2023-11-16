using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
                                

        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        .AllowAnyOrigin()
        .AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "Workshop CSharp Lasagna API",
            Description = "...",
            TermsOfService = new Uri("http://www.github.com/praticandobdd/workshop/csharp/lasagna"),
            Contact = new OpenApiContact
            {
                Name = "NOME",
                Url = new Uri("http://www.github.com/praticandobdd/NOME")
            }
        }
    );

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors();

app.UseAuthorization();

app.Run();

[ExcludeFromCodeCoverage]
public partial class Program { }
