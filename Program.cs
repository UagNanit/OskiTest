using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OskiTest.Data;
using OskiTest.Data.Abstract;
using OskiTest.Data.Repositories;
using OskiTest.Services.Abstraction;
using OskiTest.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("OskiTestContext");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("OskiTest", new OpenApiInfo
    {
        Version = "v1",
        Title = "OskiTest API",
        Description = "An ASP.NET Core Web API for user testing application. ",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Contact",
            Url = new Uri("https://www.linkedin.com/in/oleg-kravchenko-667785203/")
        }
        
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = false,  // укзывает, будет ли валидироваться издатель при валидации токена
            //ValidIssuer = AuthOptions.ISSUER,  // строка, представляющая издателя
            ValidateAudience = false,    // будет ли валидироваться потребитель токена           
            //ValidAudience = AuthOptions.AUDIENCE,  // установка потребителя токена      
            ValidateLifetime = true,  // будет ли валидироваться время существования          
            ValidateIssuerSigningKey = true, // будет ли валидация ключа безопасности        
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),  // установка ключа безопасности
        };
    });

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IAuthService>(new AuthService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "OskiTest");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors(options => options
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
          //.AllowCredentials()
          );

app.UseAuthorization();

app.MapControllers();

app.Run();
