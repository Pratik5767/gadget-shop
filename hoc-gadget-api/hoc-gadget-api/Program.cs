
namespace hoc_gadget_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowedSpecificOrigins = "_myAllowedSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowedSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost", "http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowedSpecificOrigins);
            app.UseAuthorization();


            app.MapControllers();
            app.Run();
        }
    }
}
