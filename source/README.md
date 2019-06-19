# webapi for backend

## Подключаем MySql коннектор в проект
https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html

- dotnet add package MySql.Data.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet restore


       "ConnectionStrings": {
        "LofyConnection": "server=localhost;port=3306;user=root;password=test;database=lofy;"
      }

## Сканируем базу и генерируем код модели
- dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=test;database=lofy;" MySql.Data.EntityFrameworkCore -o Models -f -DataAnnotations

## Устанавливаем генератор кода
- dotnet tool install --global dotnet-aspnet-codegenerator
- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

## Генерация кода контроллера
Взято из
https://stackoverflow.com/questions/41011700/how-to-generate-controller-using-dotnetcore-command-line

Упрощенно
- dotnet aspnet-codegenerator --project . controller -name HelloController -m Author -dc WebAPIDataContext

Со всеми параметрами
- dotnet aspnet-codegenerator --project . controller -name HelloController -m Author -dc WebAPIDataContext

Целиком

    Get-ChildItem "C:\Users\root\Documents\future\source\webapi\Models" -Filter *.cs | 
    Foreach-Object {
        $scaffoldCmd = 
        'dotnet-aspnet-codegenerator ' + 
        '-p "C:\Users\root\Documents\future\source\webapi" ' +
        'controller ' + 
        '-name ' + $_.BaseName + 'Controller ' +
        '-api ' + 
        '-m webapi.Models.' + $_.BaseName + ' ' +
        '-dc lofyContext ' +
        '-outDir Controllers ' +
        '-namespace webapi.Controllers'

        # List commands for testing:
        $scaffoldCmd

        # Excute commands (uncomment this line):
        iex $scaffoldCmd
    }


dotnet-aspnet-codegenerator -p "C:\Users\root\Documents\future\source\webapi" controller -name ContactforPersonController -api -m webapi.Models.ContactforPerson -dc lofyContext -outDir Controllers -namespace webapi.Controllers

# установка генератора документации Swagger

https://github.com/domaindrivendev/Swashbuckle.AspNetCore


1. Install the standard Nuget package into your ASP.NET Core application.

    ```
    Package Manager : Install-Package Swashbuckle.AspNetCore
    CLI : dotnet add package Swashbuckle.AspNetCore
    ```

2. In the _ConfigureServices_ method of _Startup.cs_, register the Swagger generator, defining one or more Swagger documents.

    ```csharp
    using Swashbuckle.AspNetCore.Swagger;
    
    services.AddMvc();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
    });
    ```

3. Ensure your API actions and non-route parameters are decorated with explicit "Http" and "From" bindings.

    ```csharp
    [HttpPost]
    public void CreateProduct([FromBody]Product product)
    ...

    [HttpGet]
    public IEnumerable<Product> SearchProducts([FromQuery]string keywords)
    ...
    ```

    _NOTE: If you omit the explicit parameter bindings, the generator will describe them as "query" params by default._

4. In the _Configure_ method, insert middleware to expose the generated Swagger as JSON endpoint(s)

    ```csharp
    app.UseSwagger();
    ```

    _At this point, you can spin up your application and view the generated Swagger JSON at "/swagger/v1/swagger.json."_

5. Optionally insert the swagger-ui middleware if you want to expose interactive documentation, specifying the Swagger JSON endpoint(s) to power it from.

    ```csharp
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
    ```

    _Now you can restart your application and check out the auto-generated, interactive docs at "/swagger"._
    

**установка cli**

    npm install -g @angular/cli
