using RingCentral.Reporting.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RingCentral.Reporting.Data.Repository.Interfaces;
using RingCentral.Reporting.Models.Interfaces;
using RingCentral.Reporting.Data.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Hangfire;
using Hangfire.SqlServer;
using RingCentral.Reporting.API.Controllers;
using RingCentral.Reporting.API;
using RingCentral.Reporting.Data.Repository.DAL.DeleteAllData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();
RingCentralSettings.ENGAGE_DIGITAL_SERVER_URL = configuration.GetValue<string>("RingCentralSettings:ENGAGE_DIGITAL_SERVER_URL");
RingCentralSettings.ENGAGE_DIGITAL_ACCESS_TOKEN = configuration.GetValue<string>("RingCentralSettings:ENGAGE_DIGITAL_ACCESS_TOKEN");

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IThreadRepo, ThreadRepo>();
builder.Services.AddScoped<IInterventionRepo, InterventionRepo>();
builder.Services.AddScoped<IInterventionCommentRepo, InterventionCommentRepo>();
builder.Services.AddScoped<IIdentitiesRepo, IdentitiesRepo>();
builder.Services.AddScoped<IIdentityGroupRepo, IdentityGroupRepo>();
builder.Services.AddScoped<IgetCount, InterventionRepo>();
builder.Services.AddScoped<ISourceRepo, SourceRepo>();
builder.Services.AddScoped<ICategoriesRepo, CategorieseRepo>();
builder.Services.AddScoped<IDeleteRepo, DeleteRepo>();
builder.Services.AddScoped<ISyncAllData, IntegrationProcess>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
var HangfireConnection = builder.Configuration.GetConnectionString("DBConnectionString");
builder.Services.AddHangfire(configuration => configuration
     .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
     .UseSimpleAssemblyNameTypeSerializer()
     .UseRecommendedSerializerSettings()
     .UseSqlServerStorage(HangfireConnection, new SqlServerStorageOptions
     {
         CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
         SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
         QueuePollInterval = TimeSpan.Zero,
         UseRecommendedIsolationLevel = true,
         DisableGlobalLocks = true
     }));

builder.Services.AddHangfireServer();

//https://localhost:7023/



var app = builder.Build();
app.UseHangfireDashboard();

// integrationProcess = new IntegrationProcess();

RecurringJob.AddOrUpdate<ISyncAllData>("Savetodb",syncService =>  syncService.CallAsync(), "09 * * * *");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHangfireDashboard();

app.Run();
