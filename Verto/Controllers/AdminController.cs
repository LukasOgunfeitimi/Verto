
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace Verto.Controllers {
    public class AdminController : Controller {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Admin/EditHomepage
        public async Task<IActionResult> EditHomepage() {
            // Retrieve the homepage content from the database
            var homepageContent = await _context.HomePageContents.FirstOrDefaultAsync();
            if (homepageContent == null) {
                return NotFound(); // If no content is found, return 404
            }

            return View(homepageContent);
        }

        // POST: Admin/EditHomepage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHomepage(
            HomePageContent model,
            IFormFile ImagePath,
            IFormFile ExploreImage1,
            IFormFile ExploreImage2,
            IFormFile ExploreImage3,
            IFormFile FeatureImage1,
            IFormFile FeatureImage2,
            IFormFile FeatureImage3,
            IFormFile FeatureImage4,
            IFormFile DiscoverImage) {
        var existing = await _context.HomePageContents.FirstOrDefaultAsync();

        if (existing == null)
            return NotFound();

        if (isNull(model.Title)) existing.Title = model.Title;
        if (isNull(model.Description)) existing.Description = model.Description;

        if (isNull(model.ImagePath)) existing.ImagePath = model.ImagePath;
        if (isNull(model.SliderImage1)) existing.SliderImage1 = model.SliderImage1;
        if (isNull(model.SliderImage2)) existing.SliderImage2 = model.SliderImage2;
        if (isNull(model.SliderImage3)) existing.SliderImage3 = model.SliderImage3;

        if (isNull(model.DiscoverImage)) existing.DiscoverImage = model.DiscoverImage;

        if (isNull(model.ExploreImage1)) existing.ExploreImage1 = model.ExploreImage1;
        if (isNull(model.ExploreImage2)) existing.ExploreImage2 = model.ExploreImage2;
        if (isNull(model.ExploreImage3)) existing.ExploreImage3 = model.ExploreImage3;

        if (isNull(model.FeatureImage1)) existing.FeatureImage1 = model.FeatureImage1;
        if (isNull(model.FeatureImage2)) existing.FeatureImage2 = model.FeatureImage2;
        if (isNull(model.FeatureImage3)) existing.FeatureImage3 = model.FeatureImage3;
        if (isNull(model.FeatureImage4)) existing.FeatureImage4 = model.FeatureImage4;

        await _context.SaveChangesAsync();
        return Redirect("/");
        }

        private bool isNull(string? str) {
            return !string.IsNullOrWhiteSpace(str);
        }


        private async Task<string> SaveImageAsync(IFormFile file) {
            var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + System.Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (var stream = new FileStream(filePath, FileMode.Create)) {
                await file.CopyToAsync(stream);
            }

            return "/images/" + fileName; 
        }
    }
}

