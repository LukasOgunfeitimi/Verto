using Microsoft.AspNetCore.Mvc;
using Verto.Models;
using System.Linq;

public class HomeController : Controller {
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context) {
        _context = context;
    }

    public IActionResult Index() {
        var content = _context.HomePageContents.FirstOrDefault();
        return View(content);
    }
}
