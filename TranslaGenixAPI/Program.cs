using DL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

ConfigurationManager Config = builder.Configuration;
var pol = "allowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: pol,
        policy => {
            policy.WithOrigins("https://translagenix.azurewebsites.net/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        }
        );
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = Config.GetConnectionString("SQLDatabase");

builder.Services.AddDbContext<TGContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IPointsRepo, PointsRepo>();
builder.Services.AddScoped<IWordsRepo, WordsRepo>();
//builder.Services.AddScoped<ISimpleUserRepo, SimpleUserRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(pol);
app.UseAuthorization();
app.MapControllers();

app.Run();
