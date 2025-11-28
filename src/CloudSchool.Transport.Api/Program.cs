using CloudSchool.Transport.Api.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
// get connection string from app settings development
var connectionString = builder.Configuration.GetConnectionString("Database");
// Add HttpContext accessor for request context access
builder.Services.AddHttpContextAccessor();

// Add services to the container
builder.Services.AddControllers();

// Clean architecture registrations
builder.Services.AddCloudSchoolTransport(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

var allowedOriginsRaw = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
var allowedOrigins = allowedOriginsRaw.Select(ExpandEnvPlaceholder).ToArray();
builder.Services.AddCors(options =>
{
    options.AddPolicy("SsoCorsPolicy", policy => 
    {
        if (allowedOrigins.Any())
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        }
        else
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    });
});

static string ExpandEnvPlaceholder(string input)
{
    if (string.IsNullOrWhiteSpace(input)) return input;
    var match = Regex.Match(input, @"^\$\{([^:}]+):([^}]+)\}$");
    if (!match.Success) return input;
    var envName = match.Groups[1].Value;
    var defaultValue = match.Groups[2].Value;
    var envValue = Environment.GetEnvironmentVariable(envName);
    return string.IsNullOrWhiteSpace(envValue) ? defaultValue : envValue!;
}

builder.Services.AddSwaggerGen(c =>
{
    var description =$"School management API with SSO integration for transport operations<br/>" +
                     
                     $"API ENDPOINT STATUS: <br/>" +
                     $" 🟡 **BETA** - Public API, but may change.<br/>" +
                     $"🟠 **EXPERIMENTAL** - New feature, may change.<br/>" +
                     $"🔴 **DRAFT** - Under active development, may change without notice.<br/>" +
                     $"🟢 **STABLE** - Fully tested and supported for production use.<br/>";
    
    c.SwaggerDoc("v1", new() { 
        Title = "CloudSchool.Core Transport API", 
        Version = "v1",
        Description = description
    });

    // Include XML comments for API documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CloudSchool.Core Transport API v1");
        c.RoutePrefix = string.Empty;
        
        // Enable deep linking for better navigation
        c.EnableDeepLinking();
        
        // Display request duration for performance monitoring
        c.DisplayRequestDuration();
        
        // Show examples and models by default
        c.DefaultModelsExpandDepth(2);
        c.DefaultModelExpandDepth(2);
    });
}

app.UseCors("SsoCorsPolicy");

app.MapControllers();

// Health check endpoint with version information
app.MapGet("/health", () => 
{
    try
    {
        var versionFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VERSION.txt");
        var version = "unknown";
        var status = "version file not found";
        
        if (File.Exists(versionFilePath))
        {
            version = File.ReadAllText(versionFilePath).Trim();
            status = "ok";
        }

        return Results.Ok(new { 
            status = "healthy", 
            service = "CloudSchool Transport API",
            timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
            version = version,
            versionStatus = status
        });
    }
    catch (Exception ex)
    {
        return Results.Ok(new { 
            status = "healthy", 
            service = "CloudSchool Transport API",
            timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
            version = "error",
            versionStatus = $"error reading version: {ex.Message}"
        });
    }
});

app.Run();
