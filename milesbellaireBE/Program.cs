using MbCore.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* Entity Framework Configuration */
var mySqlConnectionString = builder.Configuration.GetConnectionString("MySQL");
builder.Services.AddDbContext<DatabaseContext>(options => {
    options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString));
});
builder.Services.AddScoped<DatabaseContext>();

// Add Cors
string _policyName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _policyName,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:5084",
                                "http://localhost:7229")
            .AllowAnyMethod()
            .AllowAnyHeader(); // add the allowed origins  
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseCors(_policyName);

app.Run();
