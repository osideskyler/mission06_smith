using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(Category => Category.CategoryName)
            .ToList();
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult EnterMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie); 
            _context.SaveChanges();
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View(movie);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(Category => Category.CategoryName)
                .ToList();
            return View(movie);
        }
    }

    public IActionResult MovieList()
    {
       var movies = _context.Movies
           .Include(movie => movie.Category)
           .OrderBy(movie => movie.Title.ToLower())
           .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories
            .OrderBy(Category => Category.CategoryName)
            .ToList();
        return View("EnterMovie", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie recordToDelete)
    {
        _context.Movies.Remove(recordToDelete);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}