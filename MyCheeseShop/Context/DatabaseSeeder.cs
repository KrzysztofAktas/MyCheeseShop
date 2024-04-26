using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;
using System.Runtime.InteropServices;

namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");


            }
            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }

        }

        private List<Cheese> GetCheeses()
        {
            return
                [
                 new Cheese { Name = "Cheddar", Type = "Hard", Description = "A popular hard cheese with a tangy flavor.", Strength = "Medium", Price = 10.99m },
                 new Cheese { Name = "Brie", Type = "Soft", Description = "A creamy cheese with a mild flavor and edible rind.", Strength = "Mild", Price = 12.50m },
                 new Cheese { Name = "Gouda", Type = "Semi-Hard", Description = "A Dutch cheese with a smooth, creamy texture.", Strength = "Medium", Price = 9.75m },
                 new Cheese { Name = "Blue Cheese", Type = "Semi-Soft", Description = "A pungent cheese with blue veins running through it.", Strength = "Strong", Price = 15.25m },
                 new Cheese { Name = "Parmesan", Type = "Hard", Description = "A hard Italian cheese often grated over pasta dishes.", Strength = "Strong", Price = 14.99m },
                 new Cheese { Name = "Mozzarella", Type = "Soft", Description = "A mild, stringy cheese often used on pizzas.", Strength = "Mild", Price = 8.99m },
                 new Cheese { Name = "Gruyere", Type = "Hard", Description = "A Swiss cheese with a nutty flavor, great for melting.", Strength = "Medium", Price = 11.50m },
                 new Cheese { Name = "Camembert", Type = "Soft", Description = "Similar to Brie, but with a stronger flavor and aroma.", Strength = "Medium", Price = 13.75m },
                 new Cheese { Name = "Provolone", Type = "Semi-Hard", Description = "An Italian cheese with a mild, smoky flavor.", Strength = "Medium", Price = 10.25m },
                 new Cheese { Name = "Roquefort", Type = "Semi-Soft", Description = "A French blue cheese with a tangy, salty flavor.", Strength = "Strong", Price = 16.50m },
                 new Cheese { Name = "Havarti", Type = "Semi-Soft", Description = "A Danish cheese with small, irregular holes and a buttery taste.", Strength = "Mild", Price = 11.99m },
                 new Cheese { Name = "Swiss Cheese", Type = "Hard", Description = "A Swiss cheese with large holes and a mild, nutty flavor.", Strength = "Medium", Price = 10.50m },
                 new Cheese { Name = "Feta", Type = "Soft", Description = "A Greek cheese made from sheep's milk, crumbly with a salty flavor.", Strength = "Strong", Price = 12.99m },
                 new Cheese { Name = "Manchego", Type = "Hard", Description = "A Spanish cheese made from sheep's milk, with a nutty flavor.", Strength = "Medium", Price = 13.25m },
                 new Cheese { Name = "Fontina", Type = "Semi-Soft", Description = "An Italian cheese with a buttery texture and mild flavor.", Strength = "Mild", Price = 11.75m },
                 new Cheese { Name = "Colby", Type = "Semi-Hard", Description = "An American cheese with a mild flavor and smooth texture.", Strength = "Mild", Price = 9.25m },
                 new Cheese { Name = "Monterey Jack", Type = "Semi-Soft", Description = "An American cheese with a mild, slightly tangy flavor.", Strength = "Mild", Price = 9.99m },
                 new Cheese { Name = "Emmental", Type = "Hard", Description = "A Swiss cheese with a pale yellow color and a mild, nutty flavor.", Strength = "Medium", Price = 12.50m },
                 new Cheese { Name = "Limburger", Type = "Soft", Description = "A German cheese known for its strong aroma and pungent flavor.", Strength = "Strong", Price = 14.75m },
                 new Cheese { Name = "Edam", Type = "Semi-Hard", Description = "A Dutch cheese with a mild, nutty flavor and distinctive red wax coating.", Strength = "Mild", Price = 10.75m }
                ];

        }

        
    }
}
