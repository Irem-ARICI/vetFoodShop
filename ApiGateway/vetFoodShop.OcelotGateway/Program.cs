using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Configuration for Ocelot JSON file
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // Ensure the correct base path
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true) // Load ocelot.json
    .Build();

// Add Authentication with JWT Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("OcelotAuthenticationScheme", opt =>
    {
        opt.Authority = builder.Configuration["IdentityServerUrl"] ?? throw new InvalidOperationException("IdentityServerUrl is not configured.");
        opt.Audience = "ResourceOcelot";
        opt.RequireHttpsMetadata = false;
    });

// Add Ocelot services
builder.Services.AddOcelot(configuration);

var app = builder.Build();

// Use Authentication Middleware
app.UseAuthentication();

// Use Ocelot Middleware
await app.UseOcelot();

// Map a basic route for testing
app.MapGet("/", () => "Hello World!");

app.Run();


//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer("OcelotAuthenticationScheme", opt =>
//    {
//        opt.Authority = builder.Configuration["IdentityServerUrl"]
//            ?? throw new InvalidOperationException("IdentityServerUrl is not configured.");
//        opt.Audience = "ResourceOcelot";
//        opt.RequireHttpsMetadata = false;
//    });

//IConfiguration configuration = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
//    .Build();

//builder.Services.AddOcelot(configuration);

//var app = builder.Build();

//app.UseAuthentication();

//await app.UseOcelot();

//app.MapGet("/", () => "Hello World!");

//app.Run();
