using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_LastName.Models;
using mission6.Models;
using mission6;

namespace mission6.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;
    public HomeController(MovieCollectionContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GettoKnowJoel()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult EnterMovie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult EnterMovie(Application movie)
    {
        if (ModelState.IsValid)
        {
            // save movie
            _context.Applications.Add(movie); 
            
            // 2. Save the changes to the SQLite file
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(movie);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}