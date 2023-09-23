using AutoMapper;
using ZoobookSystemsLLC.Services.AutoMapper.Profiles;
using ZoobookSystemsLLC.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.LoadMyServices(connectionString: builder.Configuration.GetConnectionString("LocalDB"), 
                                validAudience: builder.Configuration["JWTKey:ValidAudience"], 
                                validIssuer: builder.Configuration["JWTKey:ValidIssuer"], 
                                JWTKey: builder.Configuration["JWTKey:Secret"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
