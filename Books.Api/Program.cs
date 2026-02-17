using Books.Application.Interfaces;
using Books.Application.Mapping;
using Books.Application.Services;
using Books.Infrastructure.Data;
using Books.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Books.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LibraryDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            builder.Services.AddAutoMapper(_ => { }, typeof(BookProfile).Assembly);
            builder.Services.AddAutoMapper(_ => { }, typeof(AuthorProfile).Assembly);
            builder.Services.AddAutoMapper(_ => { }, typeof(GenreProfile).Assembly);
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
