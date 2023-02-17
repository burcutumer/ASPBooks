using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data
{
    public class AppDbInitializer
    {
        public static void Seed (IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                    new Book
                    {
                        Title = "1st book title",
                        Description = "1st book description",
                        IsRead = true,
                        Genre = "romantic",
                        Author = "Burcu Tumer",
                        DateRead = DateTime.UtcNow.AddDays(-10),
                        Rate = 4,
                        CoverURl = "1st book coverURl",
                        DateAdded = DateTime.UtcNow
                    },
                    new Book
                    {
                        Title = "2nd book title",
                        Description = "2nd book description",
                        IsRead = true,
                        Genre = "romantic",
                        Author = "Burcu Tumer",
                        DateRead = DateTime.UtcNow.AddDays(-10),
                        Rate = 4,
                        CoverURl = "2nd book coverURl",
                        DateAdded = DateTime.UtcNow
                    }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}