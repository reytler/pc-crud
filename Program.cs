using crudpcapi;
using crudpcapi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes(Config.Secret);

// Add services to the container.
builder.Services.AddScoped<IUserDB, UserDB>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{
    DotNetEnv.Env.TraversePath().Load("local.env");
    builder.Configuration.AddEnvironmentVariables();
    Config.LoadConfig(builder.Configuration);
}

builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddDbContext<MysqlContext>(options =>
{
    var dataBase = builder.Configuration["DATABASE_NAME"];
    var host = builder.Configuration["DATABASE_HOST"];
    var port = builder.Configuration["DATABASE_PORT"];
    var user = builder.Configuration["DATABASE_USER"];
    var password = builder.Configuration["DATABASE_PASSWORD"];
    var vaConnectionString = $"Server={host};Database={dataBase};User={user};Password={password};";
    options.UseMySql(vaConnectionString, ServerVersion.AutoDetect(vaConnectionString));
});

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(app =>
{
    app.SwaggerDoc("v1", new OpenApiInfo { Title = "crud_api" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.MapControllers();

app.Run();
