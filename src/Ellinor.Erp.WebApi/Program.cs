
using System;
using Serilog;
using Ellinor.Erp.Application.Extensions;
using Ellinor.Erp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Serilog To File
//var logger = new LoggerConfiguration()
//  .ReadFrom.Configuration(builder.Configuration)
//  .Enrich.FromLogContext()
//  .CreateLogger();


//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);


//Serilog To Database
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog();



// AddRecordAsync services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Project Reference
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
//End



//// AutoMapper:
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//// MediatR:
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

