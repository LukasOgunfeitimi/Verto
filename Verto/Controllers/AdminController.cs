using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Verto.Models;
using Verto.Services;
namespace Verto.Controllers {
    public class AdminController : Controller {
        private readonly ApplicationDbContext _context;
        private readonly HomePageContentService _homePageContentService;

        public AdminController(ApplicationDbContext context, HomePageContentService homePageContentService) {
            _context = context;
            _homePageContentService = homePageContentService;
        }
        
        public async Task<IActionResult> ResetHomePage() {
            await _homePageContentService.ResetHomePage();
            return Redirect("/");
        }

        // GET: Admin/EditHomepage
        public async Task<IActionResult> EditHomepage() {
            var homepageContent = await _context.HomePageContents.FirstOrDefaultAsync();
            if (homepageContent == null) return NotFound();
            return View(homepageContent);
        }

        // POST: Admin/EditHomepage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHomepage(
            HomePageContent model,
            IFormFile MainImage,
            IFormFile ExploreImage1,
            IFormFile ExploreImage2,
            IFormFile ExploreImage3,
            IFormFile FeatureImage1,
            IFormFile FeatureImage2,
            IFormFile FeatureImage3,
            IFormFile FeatureImage4,
            IFormFile DiscoverImage
        ) {
            var existing = await _context.HomePageContents.FirstOrDefaultAsync();
            if (existing == null) return NotFound();

            // Text fields
            if (!string.IsNullOrWhiteSpace(model.Title)) existing.Title = model.Title;
            if (!string.IsNullOrWhiteSpace(model.Description)) existing.Description = model.Description;

            // Uploads
            if (MainImage != null) existing.MainImage = await SaveImageAsync(MainImage);
            if (ExploreImage1 != null) existing.ExploreImage1 = await SaveImageAsync(ExploreImage1);
            if (ExploreImage2 != null) existing.ExploreImage2 = await SaveImageAsync(ExploreImage2);
            if (ExploreImage3 != null) existing.ExploreImage3 = await SaveImageAsync(ExploreImage3);
            if (FeatureImage1 != null) existing.FeatureImage1 = await SaveImageAsync(FeatureImage1);
            if (FeatureImage2 != null) existing.FeatureImage2 = await SaveImageAsync(FeatureImage2);
            if (FeatureImage3 != null) existing.FeatureImage3 = await SaveImageAsync(FeatureImage3);
            if (FeatureImage4 != null) existing.FeatureImage4 = await SaveImageAsync(FeatureImage4);
            if (DiscoverImage != null) existing.DiscoverImage = await SaveImageAsync(DiscoverImage);

            await _context.SaveChangesAsync();
            return Redirect("/");
        }

        /*
        Create a random id for the file, save it and return the path
        */
        private async Task<string> SaveImageAsync(IFormFile file) {
            var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + System.Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (var stream = new FileStream(filePath, FileMode.Create)) {
                await file.CopyToAsync(stream);
            }

            return "/images/" + fileName;
        }
    }
}
