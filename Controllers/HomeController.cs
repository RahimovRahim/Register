using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia2.Contexts;
using Pronia2.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

public class HomeController : Controller
{
    private readonly ProniaDbContext _context;
    public HomeController(ProniaDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var sliders = await _context.Sliders.ToListAsync();
        var shippings = await _context.Shippings.ToListAsync();

        HomeViewModel homeViewModel = new HomeViewModel
        {
            Sliders = sliders,
            Shippings = shippings
        };

        return View(homeViewModel);
    }

}