using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Verto.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}");






using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    var homePageContent = context.HomePageContents.FirstOrDefault();
    if (homePageContent != null) {
       
        homePageContent.Title = "Custom built design & furniture solutions";
        homePageContent.Description = "Speciflaits";
        homePageContent.SliderImage1 = "/images/new_image1.jpg";
        homePageContent.SliderImage2 = "/images/new_image2.jpg";
        homePageContent.SliderImage3 = "/images/new_image3.jpg";
        homePageContent.ImagePath = "/images/circle-icons.png";
        homePageContent.ExploreImage1 = "images/explore-image1.png";
        homePageContent.ExploreImage2 = "images/explore-image2.png";
        homePageContent.ExploreImage3 = "images/explore-image3.png";
        homePageContent.FeatureImage1 = "images/office.png";
        homePageContent.FeatureImage2 = "images/education.png";
        homePageContent.FeatureImage3 = "images/healthcare.png";
        homePageContent.FeatureImage4 = "images/hospitality.png";
        homePageContent.DiscoverImage = "images/discover.png";
        context.SaveChanges();
    } else {
       context.HomePageContents.Add(new HomePageContent {
            Title = "Welcome Verto",
            Description = "Custom built design and development for your business.",
            SliderImage1 = "/images/new_image1.jpg",
            SliderImage2 = "/images/new_image2.jpg",
            SliderImage3 = "/images/new_image3.jpg",
            ImagePath = "/images/new_content.jpg"
        });
        context.SaveChanges();
    }
}

app.Run();