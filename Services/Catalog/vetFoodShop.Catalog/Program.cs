
using Microsoft.Extensions.Options;
using vetFoodShop.Catalog.Services.CategoryServices;
using vetFoodShop.Catalog.Services.ProductDetailDetailServices;
using vetFoodShop.Catalog.Services.ProductDetailServices;
using vetFoodShop.Catalog.Services.ProductImageServices;
using vetFoodShop.Catalog.Services.ProductServices;
using vetFoodShop.Catalog.Settings;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authentication.JwtBearer;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});           //  3.23-> authentication category'in Get işleminde hata veriyor sanırım bu yüzden




builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

//builder.Services.AddSingleton<IDatabaseSettings>(sp =>
//{
//    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
//});

//builder.Services.AddScoped<MongoDBService>();


//builder.Services.AddSingleton<MongoDBService>();    // yorum satırındaydı açınca bir şey olmadı (troll)


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
