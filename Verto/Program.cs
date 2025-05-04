using Microsoft.EntityFrameworkCore;
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
using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    // Check if the record exists
    var homePageContent = context.HomePageContents.FirstOrDefault();
    if (homePageContent == null) {
        // Add new record if none exists
        context.HomePageContents.Add(new HomePageContent {
            Title = "Welcome to Verto hi",
            Description = "Custom built design and development for your business.",
            SliderImage1 = "/images/slider1.jpg",
            SliderImage2 = "/images/slider2.jpg",
            SliderImage3 = "/images/slider3.jpg",
            ImagePath = "/images/content.jpg"
        });
    } else {
        // Update the existing record
        homePageContent.Title = "Welcome to Verto hi";
        homePageContent.Description = "Custom built design and development for your business.";
        homePageContent.SliderImage1 = "/images/slider1.jpg";
        homePageContent.SliderImage2 = "/images/slider2.jpg";
        homePageContent.SliderImage3 = "/images/slider3.jpg";
        homePageContent.ImagePath = "/images/content.jpg";
    }

    context.SaveChanges();
}
app.Run();