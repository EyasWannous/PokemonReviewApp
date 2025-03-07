﻿using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models;

public class Reviewer
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    public string FullName => FirstName + " " + LastName;
    public ICollection<Review> Reviews { get; set; } = [];
}
