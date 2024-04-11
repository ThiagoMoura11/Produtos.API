using Microsoft.EntityFrameworkCore;
using Produto.Data.Context;
using Produto.Data.Repository;
using Produto.Domain.Interface;
using Produto.Service;
using Produto.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProdutoContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Conexaosqlite"));
});

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

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
