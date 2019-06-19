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

# angular

**установка cli**

    npm install -g @angular/cli
