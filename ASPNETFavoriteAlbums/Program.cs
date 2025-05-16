using ASPNETFavoriteAlbums.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPNETFavoriteAlbums
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ASPFavoriteAlbums;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<FavoriteAlbumsDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IAlbum, AlbumRepository>();
            builder.Services.AddTransient<ITag, TagRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
