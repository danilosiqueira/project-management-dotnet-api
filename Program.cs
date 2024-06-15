using ProjectManagement.Business;
using ProjectManagement.Repositories;

DapperConfig.ConfigureDapper();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddNpgsqlDataSource(builder.Configuration.GetConnectionString("Default"));

//Repositories
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ProjectRepository>();
builder.Services.AddScoped<ResourceTypeRepository>();
builder.Services.AddScoped<ResourceRepository>();
builder.Services.AddScoped<TaskRepository>();

//Business
builder.Services.AddScoped<UserBusiness>();
builder.Services.AddScoped<ProjectBusiness>();
builder.Services.AddScoped<ResourceTypeBusiness>();
builder.Services.AddScoped<ResourceBusiness>();
builder.Services.AddScoped<TaskBusiness>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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