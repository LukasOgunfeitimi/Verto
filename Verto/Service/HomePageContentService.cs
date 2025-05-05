using Microsoft.EntityFrameworkCore;

namespace Verto.Services {
    public class HomePageContentService {
        private readonly ApplicationDbContext _context;

        public HomePageContentService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task ResetHomePage() {
            var existingContent = await _context.HomePageContents.FirstOrDefaultAsync();
            if (existingContent != null) {
                _context.HomePageContents.Remove(existingContent);
            }

            var newContent = new HomePageContent {
                Title = "Welcome Verto",
                Description = "Custom built design and development for your business.",

                SliderTitle1 = "Welcome to Verto",
                SliderDesc1 = "Custom built design and development for your business.",
                SliderTitle2 = "Innovative Solutions",
                SliderDesc2 = "We create custom solutions that fit your unique needs.",
                SliderTitle3 = "Get Started Today",
                SliderDesc3 = "Contact us to take the first step towards a better digital experience.",

                MainImage = "/images/main.png",

                DiscoverImage = "/images/discover.png",

                CircleIconsImage = "/images/circle-icons.png",

                ExploreImage1 = "/images/explore-image1.png",
                ExploreImage2 = "/images/explore-image2.png",
                ExploreImage3 = "/images/explore-image3.png",

                FeatureImage1 = "/images/feature1.png",
                FeatureImage2 = "/images/feature2.png",
                FeatureImage3 = "/images/feature3.png",
                FeatureImage4 = "/images/feature4.png",
            };

            _context.HomePageContents.Add(newContent);
            await _context.SaveChangesAsync();
        }
    }
}