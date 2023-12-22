using Microsoft.AspNetCore.Hosting;

namespace ECommerceWebsite.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped(typeof(CacheManager<>));

            #region Identity
            builder.Services.AddDbContext<OganiContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
            #endregion

            #region Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<OganiContext>()
                    .AddDefaultTokenProviders();
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            });
            #endregion

            #region JwtAuthentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidAudience = builder.Configuration["Jwt:Audience"],
                            ValidIssuer = builder.Configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                            RequireExpirationTime = true,
                        };
                    });
            #endregion

            #region AddCors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            #endregion
            var app = builder.Build();
            app.UseCors("AllowAllOrigins");

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
        }

    }
}

