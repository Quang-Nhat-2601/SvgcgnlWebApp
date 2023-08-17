using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedAdmins(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;
            var adminData = await File.ReadAllTextAsync("Data/AdminSeed.json");
            
            var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};
            var admins = JsonSerializer.Deserialize<List<AppUser>>(adminData, options);

            foreach (var admin in admins)
            {
                using var hmac = new HMACSHA512();
                admin.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                admin.PasswordSalt = hmac.Key;

                context.Users.Add(admin);
            }

            await context.SaveChangesAsync();

        } 
    }
}