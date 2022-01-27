using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using MovePara.Model;

var builder = WebApplication.CreateBuilder(args);



var appConnectionString = builder.Configuration.GetConnectionString("AzureAppconfiguration");

//For Feature Flag
builder.Configuration.AddAzureAppConfiguration(options => options.Connect(appConnectionString).UseFeatureFlags());
builder.Services.AddFeatureManagement().AddFeatureFilter<PercentageFilter>();
builder.Services.AddAzureAppConfiguration();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ParaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
builder.Services.AddCors();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();


app.UseCors(options => options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader()
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAzureAppConfiguration();
app.UseAuthorization();

app.MapControllers();

app.Run();
