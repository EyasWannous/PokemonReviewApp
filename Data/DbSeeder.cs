using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data;

public class DbSeeder(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task SeedDataContextAsync()
    {
        if (await _context.PokemonOwners.AnyAsync())
            return;

        PokemonCategory pokemonCategory = new()
        {
            Category = new Category()
            {
                Name = "Leaf"
            }
        };

        var pokemonOwners = new List<PokemonOwner>()
        {
            new()
            {
                Pokemon = new Pokemon()
                {
                    Name = "Pikachu",
                    BirthDate = new DateTime(1903,1,1),
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new()
                        {
                            Category = new Category()
                            {
                                Name = "Electric"
                            }
                        }
                    },
                    Reviews = new List<Review>()
                    {
                        new() 
                        {
                            Title="Pikachu",
                            Text = "Pickahu is the best pokemon, because it is electric",
                            Rating = 5,
                            Reviewer = new Reviewer()
                            {
                                FirstName = "Teddy",
                                LastName = "Smith"
                            }
                        },
                        new()
                        {
                            Title="Pikachu",
                            Text = "Pickachu is the best a killing rocks",
                            Rating = 5,
                            Reviewer = new Reviewer()
                            {
                                FirstName = "Taylor",
                                LastName = "Jones"
                            }
                        },
                        new()
                        {
                            Title="Pikachu",
                            Text = "Pickchu, pickachu, pikachu",
                            Rating = 1,
                            Reviewer = new Reviewer()
                            {
                                FirstName = "Jessica",
                                LastName = "McGregor"
                            }
                        },
                    }
                },
 
                Owner = new Owner()
                {
                    Name = "Jack London",
                    GYM = "Brocks Gym",
                    Country = new Country()
                    {
                        Name = "Kanto"
                    }
                }
            },

            new()
            {
                Pokemon = new Pokemon()
                {
                    Name = "Squirtle",
                    BirthDate = new DateTime(1903,1,1),
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new()
                        {
                            Category = new Category()
                            {
                                Name = "Water"
                            }
                        }
                    },
                    Reviews = new List<Review>()
                    {
                        new()
                        {
                            Title= "Squirtle",
                            Text = "squirtle is the best pokemon, because it is electric",
                            Rating = 5,
                            Reviewer = new Reviewer()
                            { 
                                FirstName = "Teddy",
                                LastName = "Smith"
                            } 
                        },
                        new()
                        {
                            Title= "Squirtle",
                            Text = "Squirtle is the best a killing rocks", Rating = 5,
                            Reviewer = new Reviewer()
                            {
                                FirstName = "Taylor",
                                LastName = "Jones"
                            }
                        },
                        new()
                        {
                            Title= "Squirtle",
                            Text = "squirtle, squirtle, squirtle", Rating = 1,
                            Reviewer = new Reviewer()
                            {
                                FirstName = "Jessica",
                                LastName = "McGregor"
                            }
                        },
                    }
                },

                Owner = new Owner()
                {
                    Name = "Harry Potter",
                    GYM = "Mistys Gym",
                    Country = new Country()
                    {
                        Name = "Saffron City"
                    }
                }
            },

            new()
            {
                Pokemon = new Pokemon()
                {
                    Name = "Venasuar",
                    BirthDate = new DateTime(1903,1,1),
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        pokemonCategory
                    },
                    Reviews = new List<Review>()
                    {
                        new()
                        {
                            Title="Veasaur",
                            Text = "Venasuar is the best pokemon, because it is electric",
                            Rating = 5,
                            Reviewer = new Reviewer()
                            {
                                FirstName = "Teddy",
                                LastName = "Smith"
                            }
                        },
                        new()
                        {
                            Title="Veasaur",
                            Text = "Venasuar is the best a killing rocks",
                            Rating = 5,
                            Reviewer = new Reviewer()
                            {
                                FirstName = "Taylor",
                                LastName = "Jones"
                            }
                        },
                        new()
                        {
                            Title="Veasaur",
                            Text = "Venasuar, Venasuar, Venasuar",
                            Rating = 1,
                            Reviewer = new Reviewer()
                            {
                                FirstName = "Jessica",
                                LastName = "McGregor"
                            }
                        },
                    }
                },

                Owner = new Owner()
                {
                    Name = "Ash Ketchum",
                    GYM = "Ashs Gym",
                    Country = new Country()
                    {
                        Name = "Millet Town"
                    }
                }
            }
        };

        await _context.PokemonOwners.AddRangeAsync(pokemonOwners);

        await _context.SaveChangesAsync();
    }
}