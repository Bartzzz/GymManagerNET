using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models;
using GymManagerNET.Core.Models.Users;
using GymManagerNET.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace GymManager.Data
{
    public class AppSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly UserManager<DefaultEmployee> _userManager;

        public AppSeeder(ApplicationDbContext context, IConfiguration config, UserManager<DefaultEmployee> userManager)
        {
            _context = context;
            _config = config;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            DefaultEmployee user = await _userManager.FindByEmailAsync("admin@migusgym.com");
            if (user == null)
            {
                user = new DefaultEmployee()
                {
                    Email = "admin@migusgym.com",
                    UserName = "admin@migusgym.com",
                    Name = "Bartosz",
                    Surname = "Migus",
                    UserType = UserType.Manager
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!1");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user");
                }
            }

            if (!_context.Clients.Any())
            {
                var clients = new List<Client>()
                {
                    new Client()
                    {
                        Name = "Andrzej",
                        Surname = "Kowalski",
                        Email = "akowalski@migusgym.com",
                        Subscriptions = new List<Subscription>()
                        {
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.Monthly,
                                EntrancesLeft = 0,
                                StartDate = DateTime.Now
                            },
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.Monthly,
                                EntrancesLeft = 0,
                                StartDate = DateTime.Now.AddMonths(-2)
                            }}
                    },
                    new Client()
                    {
                        Name = "Janko",
                        Surname = "Mant",
                        Email = "jmuzykant@migusgym.com",
                        Subscriptions = new List<Subscription>()
                        {
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.CountedEntrances,
                                EntrancesLeft = 10,
                                StartDate = DateTime.Now
                            }
                        }
                    },
                    new Client()
                    {
                        Name = "Janko",
                        Surname = "Andrzej",
                        Email = "jmuzykant2@migusgym.com",
                        Subscriptions = new List<Subscription>()
                        {
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.CountedEntrances,
                                EntrancesLeft = 10,
                                StartDate = DateTime.Now
                            }
                        }
                    },
                    new Client()
                    {
                        Name = "Janko",
                        Surname = "Muzykant",
                        Email = "jmuzykant3@migusgym.com",
                        Subscriptions = new List<Subscription>()
                        {
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.Monthly,
                                EntrancesLeft = 0,
                                StartDate = DateTime.Now.AddMonths(-2)
                            }

                        }
                    },
                    new Client()
                    {
                        Name = "John",
                        Surname = "Musicman",
                        Email = "jmuzykant4@migusgym.com",
                        Subscriptions = new List<Subscription>()
                        {
                            new Subscription()
                            {
                                SubscriptionType = SubscriptionType.Monthly,
                                EntrancesLeft = 0,
                                StartDate = DateTime.Now.AddMonths(-2)
                            }

                        }
                    }
                };

                _context.AddRange(clients);
                _context.SaveChanges();
            }

        }
    }
}
