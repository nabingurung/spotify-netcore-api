using netcore_spotify_api.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add http client factory
builder.Services.AddHttpClient();

// add http services
builder.Services.AddScoped<IHttpService, HttpClientFactoryService>();

var app = builder.Build();
var secretKey = builder.Configuration["SpotifyClientId"];
Console.WriteLine();

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
