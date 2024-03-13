using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia2.Models;
using Pronia2.ViewModels;

namespace Pronia2.Contexts
{
    public class ProniaDbContext : DbContext
    {
        public ProniaDbContext(DbContextOptions<ProniaDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; } = null!;
        public DbSet<Shipping> Shippings { get; set; } = null!;
    }
}

