using Microsoft.EntityFrameworkCore;
using chessApi;
using ChessApi.Services;
using chessboard.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGameStateRepository, ChessGameRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

// Add services to the container.
builder.Services.AddControllers();

//in memory database
builder.Services.AddDbContext<ChessDbContext>(opt =>
    opt.UseInMemoryDatabase("chess"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
