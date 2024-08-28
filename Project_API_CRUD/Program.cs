using Microsoft.EntityFrameworkCore;
using Project_API_CRUD.Models;

//create entry point for configure
var builder = WebApplication.CreateBuilder(args);

// create config for webapp retrive it
var connectionString = builder.Configuration.GetConnectionString("CollegeDB");

// here allocate where db data going to use -- collegeDbContext is service 
builder.Services.AddDbContextPool<CollegeDbContext>(option =>
option.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();