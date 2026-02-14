# Fitness Calendar (ASP.NET Core MVC)

Simple workout tracker built with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server**.  
Displays training history and activity trends using **Chart.js**.

---

## Tech Stack

- .NET 8 — ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Chart.js (statistics & charts)
- Razor Views

---

## Features

- Create / edit / delete workout entries
- Browse workouts by date
- Visual statistics (Chart.js)
- SQL Server persistence via EF Core

---

## Requirements

- .NET 8 SDK
- SQL Server / LocalDB

---

## Setup

```bash
git clone https://github.com/igorksk/FitnessCalendar.git
cd FitnessCalendar
dotnet ef database update
dotnet run
