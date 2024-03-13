using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia2.Areas.Admin.ViewModels;
using Pronia2.Contexts;
using Pronia2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pronia2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShippingController : Controller
    {
        private readonly ProniaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ShippingController(ProniaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var shippings = await _context.Shippings.ToListAsync();
            return View(shippings);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> Create(ShippingCreateViewModel shipping) {
            if (!shipping.Image.ContentType.Contains("image/")){
                ModelState.AddModelError("Image", "Sekil Olmalidir");
                return View();
            }
             string filename = $"{Guid.NewGuid()}-{shipping.Image.FileName}";
        string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", "website-images", filename);


            using(FileStream stream=new FileStream(path, FileMode.Create))
            {
                await shipping.Image.CopyToAsync(stream);
            }
            Shipping newShipping = new Shipping
            {
                Title = shipping.Title,
                Description = shipping.Description,
                Image = filename
            };
   
            await _context.Shippings.AddAsync(newShipping);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var slider = _context.Sliders.SingleOrDefault(s => s.Id == id);
           

            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return View(slider);
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public IActionResult DeleteShipping(int id)
        {
            var slider = _context.Sliders.SingleOrDefault(s => s.Id == id);
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", "website-images", slider.Image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}

