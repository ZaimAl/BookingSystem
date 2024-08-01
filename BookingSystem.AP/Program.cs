using BookingSystem.DataAccsess.Models;
using BookingSystem.Master.Provider;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   
builder.Services.AddScoped<BookingCodeProvider>();
builder.Services.AddScoped<LocationProvider>();
builder.Services.AddScoped<MstResourceProvider>();
builder.Services.AddScoped<MenuProvider>();
builder.Services.AddScoped<RoomProvider>();
builder.Services.AddScoped<BookingSystemContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
