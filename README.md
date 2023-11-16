# sbe-workshop-csharp

## Ideias

* Os principais tipos de teste (regra de negócio, rest, frontend, ..) no desafio 1, da lasanha
* Branches por usuário (tula, stela, misael, ...) e por encontro (2023-11-15, 2023-11-23, ...)
* Nos encontros, escolher um dos branches para codar colaborativamente
* Referência como link do conceito ou classe ou método ou função oficial da tecnologia próximo ao código fonte
* Do arquivo de feature para a interface exposta mesmo no legado
  * Sabendo adicionar um projeto specflow a qualquer solution .NET C#
* Todos conquistarem autonomia a cada desafio definido

## Mapa

| testes / desafios | lasanha (números inteiros) | 2? | 3? | 4? | 5? | 6? | 7? |
| :-------------- | :--------------- | :---: | :---: | :---: | :---: | :---: | :---: |
| documentação viva |  [ver](#challenge1_livingdoc) | ... | ... | ... | ... | ... | ... |
| testes unitários |  [ver](#challenge1_unit) | ... | ... | ... | ... | ... | ... |
| testes de api rest | [ver](#challenge1_rest) | ... | ... | ... | ... | ... | ... |
| testes de interface de usuário web | [ver](#challenge1_web) | ... | ... | ... | ... | ... | ... |
| testes de mutação | [ver](#challenge1_mutation) | ... | ... | ... | ... | ... | ... |
| testes de bases sql | não | ... | ... | ... | ... | ... | ... |
| testes de carga e desempenho | não | ... | ... | ... | ... | ... | ... |

## Desafios

### Desafio 1: Lasanha

* [cenários em inglês](./estimate_lasagna_times.feature)
* [cenários em português](./estimar_tempos_de_lasanha.feature)
  
## Colinhas

### 00 Confirmar ferramentas

* [ ] Git (https://git-scm.com/downloads)
* [ ] Warp (https://www.warp.dev) ou Hyper (https://hyper.is) ou Git Bash
* [ ] .NET (7|8) SDK
* [ ] Visual Studio Code
  * [ ] extensão C#
  * [ ] extensão C# Dev Kit
  * [ ] extensão .NET Extension Pack
  * [ ] extensão .NET Test Explorer
  * [ ] extensão Coverage Gutters
  * [ ] extensão Better Comments

### Criar projeto specflow

### Criar solução

```bash
mkdir lasagna_from_scratch
```

```csharp
dotnet new solution --name Workshop.Csharp.Lasagna --output . --dry-run
```

```csharp
dotnet new uninstall SpecFlow.Templates.DotNet
```

```csharp
dotnet new install SpecFlow.Templates.DotNet
```

```bash
dotnet new list specflowproject
```

```bash
dotnet new specflowproject -f net6.0 -t xunit -n Workshop.Csharp.Lasagna.Specs -o test/Workshop.Csharp.Lasagna.Specs --dry-run
```

```bash
open https://aka.ms/templating-exit-codes#73
```

```bash
dotnet sln add test/Workshop.Csharp.Lasagna.Specs/Workshop.Csharp.Lasagna.Specs.csproj
```

```bash
dotnet test
```

```bash
dotnet new webapi -f net7.0 --name Workshop.Csharp.Lasagna.WebApi --output src/Workshop.Csharp.Lasagna.WebApi --dry-run
```

```bash
dotnet sln add src/Workshop.Csharp.Lasagna.WebApi/Workshop.Csharp.Lasagna.WebApi.csproj
```

```bash
dotnet run --project src/Workshop.Csharp.Lasagna.WebApi/ 
```

```bash
curl -X 'GET' \
  'http://localhost:5280/WeatherForecast' \
  -H 'accept: text/plain'
```

```bash
dotnet add test/Workshop.Csharp.Lasagna.Specs/Workshop.Csharp.Lasagna.Specs.csproj reference src/Workshop.Csharp.Lasagna.WebApi/Workshop.Csharp.Lasagna.WebApi.csproj
```

```bash
dotnet tool uninstall --global dotnet-stryker
```

```bash
dotnet tool install --global dotnet-stryker
```

```bash
dotnet tool update --global dotnet-stryker
```

```bash
dotnet stryker --open-report
```

```bash
Initial testrun has more than 50% failing tests.

Add two numbers

TechTalk.SpecFlow.xUnit.SpecFlowPlugin.XUnitPendingStepException : Test pending: One or more step definitions are not implemented yet.
  CalculatorStepDefinitions.GivenTheFirstNumberIs(50)
```

```bash
dotnet tool uninstall --global SpecFlow.Plus.LivingDoc.CLI
```

```bash
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
```

```bash
livingdoc test-assembly test/Workshop.Csharp.Lasagna.Specs/bin/Debug/net7.0/Workshop.Csharp.Lasagna.Specs.dll -t test/Workshop.Csharp.Lasagna.Specs/bin/Debug/net7.0/TestExecution.json
```

```bash
open LivingDoc.html
```

```bash
dotnet tool install --global coverlet.console
```

```bash
coverlet test/Workshop.Csharp.Lasagna.Specs/bin/Debug/net7.0/Workshop.Csharp.Lasagna.Specs.dll --target "dotnet" --targetargs "test"
```

```bash
dotnet add package Microsoft.AspNetCore.Mvc.Testing --version 7.0.14
```

```bash
dotnet add package Microsoft.NET.Test.Sdk --version 17.8.0
```

```bash
public partial class Program {}
```

```bash
using System.Reflection;
```

```bash
using Microsoft.OpenApi.Models;
```

```bash
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
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
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
```


```bash
dotnet tool install --global coverlet.console
```
```bash
 dotnet add package coverlet.msbuild
```
```bash
  dotnet add package coverlet.collector
```

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info ./test/Workshop.Csharp.Lasagna.Specs/
```


```bash
  Calculating coverage result...
  Generating report './lcov.info'
```

```bash
 dotnet watch run --project src/Workshop.Csharp.Lasagna.WebApi/Workshop.Csharp.Lasagna.WebApi.csproj
```

```bash
 dotnet add package CucumberExpressions.SpecFlow.3-9 --version 1.0.7
```

## Referências

> contribuição de todos os participantes

### Conteúdo

* Specflow
* XUnit
* Stryker
* FluentAssertions
* MVC Testing
* OpenAPI/Swagger
* Selenium
* .NET SDK
* Visual Studio Code
* Git
* GitHub
  
### Experiência

* Sessões de Testing Dojo
  * 2023-11-15

### Pessoas + Redes

* John  Ferguson Smart
* Gaspar Nagy e Seb Rose
* Kamil Nicieja
* Lisa Crispin e Janet Gregory
* Alex Bretas
* Mike Rother
* Erika Andersen