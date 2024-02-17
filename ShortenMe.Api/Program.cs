using ShortenMe.Api;
using ShortenMe.Api.Services;
using ShortenMe.Database;

var builder = WebApplication.CreateBuilder(args);

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>() ?? new();

ShortenMe.Database.Program.RunMigrations(connectionStrings.ShortenMeDB);

builder.Services.AddControllers();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
    });
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ShortenUrlSvc, ShortenUrlSvc>();
builder.Services.AddSingleton<Repository, Repository>(s => new Repository(connectionStrings.ShortenMeDB));
builder.Services.AddSingleton<TokenSvc, TokenSvc>();

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
