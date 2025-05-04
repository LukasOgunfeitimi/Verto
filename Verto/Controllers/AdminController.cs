using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using Verto.Models;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var content = await _context.HomePageContents.FirstOrDefaultAsync();
        return View(content);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(HomePageContent model, IFormFile image, IFormFile SliderImage1, IFormFile SliderImage2, IFormFile SliderImage3)
    {
        if (ModelState.IsValid)
        {
            if (image != null)
            {
                var filePath = Path.Combine("wwwroot/images", image.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                model.ImagePath = "/images/" + image.FileName;
            }

            if (SliderImage1 != null)
            {
                var filePath = Path.Combine("wwwroot/images", SliderImage1.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await SliderImage1.CopyToAsync(stream);
                }
                model.SliderImage1 = "/images/" + SliderImage1.FileName;
            }

            if (SliderImage2 != null)
            {
                var filePath = Path.Combine("wwwroot/images", SliderImage2.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await SliderImage2.CopyToAsync(stream);
                }
                model.SliderImage2 = "/images/" + SliderImage2.FileName;
            }

            if (SliderImage3 != null)
            {
                var filePath = Path.Combine("wwwroot/images", SliderImage3.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await SliderImage3.CopyToAsync(stream);
                }
                model.SliderImage3 = "/images/" + SliderImage3.FileName;
            }

            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
}