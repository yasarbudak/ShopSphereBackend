using ShopSphere.UserService.Application;
using ShopSphere.UserService.Infrastructure;
using ShopSphere.UserService.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Register services from different layers
builder.Services.AddApplicationServices(); //Application layer
builder.Services.AddInfrastructureServices(); //Infrastructure layer
builder.Services.AddPersistenceServices(builder.Configuration); //Persistence layer

//Add other services (e.g., controllers, authentication)
builder.Services.AddControllers();
builder.Services.AddAuthentication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Build and run the app
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