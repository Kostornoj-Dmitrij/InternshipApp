# Учет стажеров

Проект представляет собой веб-приложение для учета стажеров, разработанное на ASP.NET Core и Blazor.

### 1. Установка зависимостей

Убедитесь, что у вас установлены:
- .NET SDK 6.0 или выше
- EF Core Tools

### 2. Применение миграций
Перейдите в папку с проектом (task_for_66bit)
Для создания базы данных из миграции выполните команду:

dotnet ef database update

Будет создана база данных в корне проекта - app.db,
на всякий случай в проекте представлен sql-дамп базы с тестовыми данными (dump.sql)

### 3. Запуск проекта
После того, как получили базу данных, можно запускать проект

Запустите проект, выполнив команду:

dotnet run

Приложение будет доступно по одному из адресов: http://localhost:5003, https://localhost:7065
