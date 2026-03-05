using Microsoft.EntityFrameworkCore;
using EMROOM_emproj.Data;
using EMROOM_emproj.Repositories;
using EMROOM_emproj.Services;
using EMROOM_emproj.Strategies;
using EMROOM_emproj.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<EMROOM_DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EMROOM_DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IEMROOM_Patient_Repository, EMROOM_Patient_Repository>();
builder.Services.AddScoped<IEMROOM_Emergency_Repository, EMROOM_Emergency_Repository>();
builder.Services.AddScoped<IEMROOM_Triage_Repository, EMROOM_Triage_Repository>();
builder.Services.AddScoped<IEMROOM_User_Repository, EMROOM_User_Repository>();

// Register Services
builder.Services.AddScoped<IEMROOM_Patient_Service, EMROOM_Patient_Service>();
builder.Services.AddScoped<IEMROOM_Emergency_Service, EMROOM_Emergency_Service>();
builder.Services.AddScoped<IEMROOM_Triage_Service, EMROOM_Triage_Service>();

// Register Strategies
builder.Services.AddScoped<EMROOM_Basic_Triage_Strategy>();
builder.Services.AddScoped<EMROOM_Advanced_Triage_Strategy>();

// Register Factory
builder.Services.AddScoped<EMROOM_Triage_Strategy_Factory>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
