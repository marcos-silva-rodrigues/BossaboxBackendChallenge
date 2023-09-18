using BossaboxBackendChallenge.Data;
using BossaboxBackendChallenge.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IToolService, ToolService>();
builder.Services.AddDbContext<ToolContext>(opt => opt.UseSqlite($"Data Source=../challenge.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Desafio BossaBox",
            Description = "Desafio para treinar em dotnet",
            TermsOfService = new Uri("https://github.com/marcos-silva-rodrigues/BossaboxBackendChallenge"),
            Contact = new OpenApiContact
            {
                Name = "Marcos Rodrigues",
                Url = new Uri("https://github.com/marcos-silva-rodrigues")
            },
    }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
