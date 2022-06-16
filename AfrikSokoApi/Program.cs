using AfrikSoko_DAL.Repository;
using AfrikSoko_DAL.Interface;
using AfrikSoko_BLL.LocalServices;
using AfrikSoko_DAL.Models;
using AfrikSoko_BLL.LocalServices.Interface;
using System.Configuration;
using AfrikSokoApi.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Repository
builder.Services.AddScoped<BaseRepository>();
builder.Services.AddScoped<IUserRepository<User>, UserRepo>();
builder.Services.AddScoped<IProductRepository<Product, SupplyItem>, ProductRepo>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepo>();
builder.Services.AddScoped<IBuyerRepository, BuyerRepo>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepo>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepo>();
builder.Services.AddScoped<ISupplyItemRepository, SupplyItemRepo>();
builder.Services.AddScoped<ISectorRepository, SectorRepo>();
builder.Services.AddScoped<IServiceRepository, ServiceRepo>();
builder.Services.AddScoped<ICommentRepository, CommentRepo>();
builder.Services.AddScoped<IRoleRepository, RoleRepo>();
builder.Services.AddScoped<IAddressRepository, AddressRepo>();
#endregion

#region Local Services
builder.Services.AddScoped<IUserService, LocalUserService>();
builder.Services.AddScoped<TokenService>();


#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region ConfigSwagger

builder.Services.AddSwaggerGen(c =>
{
    //var filePath = Path.Combine(System.AppContext.BaseDirectory, "afriksokoswagger.xml");
    //c.IncludeXmlComments(filePath);
    //c.DescribeAllParametersInCamelCase();
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "AfrikSoko API",
        Description = "Products - Suppliers - Buyers Data Tool",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Email = "ericrudz@gmail.com",
            Name = "Eric R."
        }
    });
});
#endregion

#region Config JwToken

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("tokenValidation").GetSection("secret").Value)),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("tokenValidation").GetSection("issuer").Value,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("tokenValidation").GetSection("audience").Value
        };
    }
    );
#endregion


#region Authorization Policy

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("adminPolicy", policy => policy.RequireRole("Admin"));
//    options.AddPolicy("userPolicy", policy => policy.RequireRole("User", "Admin", "Moderator"));
//    options.AddPolicy("modoPolicy", policy => policy.RequireRole("Admin", "Moderator"));
//});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DisplayOperationId();
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AfrikSoko API");
    });
}


app.UseHttpsRedirection();

//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();

