using DotnetPersonAPI.Data;
using Microsoft.EntityFrameworkCore;
using DotnetPersonAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.People.Any())
    {
        db.People.AddRange(
            new Person { Name = "Anna", Age = 28 },
            new Person { Name = "Mads", Age = 31 },
            new Person { Name = "Sara", Age = 24 }
        );

        db.SaveChanges();
    }
}


app.MapGet("/", () => "Person API is running");

app.MapGet("/people", (AppDbContext db) =>
{
    return Results.Ok(db.People.ToList());
});

app.MapGet("/people/{id}", (int id, AppDbContext db) =>
{
    var person = db.People.Find(id);
    return person is not null ? Results.Ok(person) : Results.NotFound();
});

app.MapPost("/people", (Person person, AppDbContext db) =>
{
    db.People.Add(person);
    db.SaveChanges();
    return Results.Created($"/people/{person.Id}", person);
});

app.MapPut("/people/{id}", (int id, Person updatedPerson, AppDbContext db) =>
{
    var person = db.People.Find(id);

    if (person is null)
        return Results.NotFound();

    person.Name = updatedPerson.Name;
    person.Age = updatedPerson.Age;

    db.SaveChanges();
    return Results.Ok(person);
});

app.MapDelete("/people/{id}", (int id, AppDbContext db) =>
{
    var person = db.People.Find(id);

    if (person is null)
        return Results.NotFound();

    db.People.Remove(person);
    db.SaveChanges();

    return Results.NoContent();
});

app.Run();