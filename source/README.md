# webapi for backend

## Подключаем MySql коннектор
https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html

- dotnet add package MySql.Data.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet restore

## Сканируем базу и генерируем код
- dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=test;database=lofy" MySql.Data.EntityFrameworkCore -o Models -f