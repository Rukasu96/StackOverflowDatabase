using Microsoft.EntityFrameworkCore;
using StackOverflowDatabase.Entities;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StackOverflowContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("StackOverflowConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<StackOverflowContext>();

var pendingMigrations = dbContext.Database.GetPendingMigrations();

if (pendingMigrations.Any())
{
    dbContext.Database.Migrate();
}

var users = dbContext.Users.ToList();
if (!users.Any())
{
    var user1 = new User
    {
        UserNick = "Rukasu",
        FullName = "Rukasu User",
        Email = "rukasu@test.com",
    };

    var user2 = new User
    {
        UserNick = "Vikai",
        FullName = "Vikai User",
        Email = "viaki@test.com",
    };

    dbContext.Users.AddRange(user1, user2);
    dbContext.SaveChanges();
}

app.MapPost("AddQuestion", async (StackOverflowContext db) =>
{
    var user = await db.Users.FirstAsync(x => x.UserNick == "Rukasu");

    var questionToAdd = new Question
    {
        Topic = "Test Question One??",
        Description = "Test Description....",
        User = user,
    };

    db.Questions.Add(questionToAdd);
    await db.SaveChangesAsync();

    return questionToAdd;
});

app.MapPost("AddComment", async (StackOverflowContext db) =>
{
    var question = await db.Questions.FirstAsync(x => x.Id == 1);
    var user = await db.Users.FirstAsync(x => x.Questions.Contains(question));

    var commentToAdd = new Comment
    {
        Message = "Test Question response...",
        User = user,
        Question = question,
    };

    db.Comments.Add(commentToAdd);
    await db.SaveChangesAsync();

    return commentToAdd;
});

app.MapPost("UpdateLikes", async (StackOverflowContext db) =>
{
    var IsIncreased = true;
    
    var question = await db.Questions.FirstAsync(x => x.Id == 1);
    
    if (IsIncreased)
    {
        question.Likes++;
    }
    else
    {
        question.Likes--;
    }

    await db.SaveChangesAsync();

    return question;
});

app.Run();
