using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

public class ProductController : Controller
{
    private static List<Product> products = new List<Product>()
    {
        new Product { Id = 1, Name = "Cake 1", Price = 50000, Image = "cake1.jpg" },
        new Product { Id = 2, Name = "Cake 2", Price = 60000, Image = "cake2.jpg" }
    };

    // READ
    public IActionResult Index()
    {
        return View(products); // dùng static list đã khai báo
    }



    // CREATE GET
    public IActionResult Create()
    {
        return View();
    }

    // CREATE POST
    [HttpPost]
    public IActionResult Create(Product p)
    {
        p.Id = products.Max(x => x.Id) + 1;
        products.Add(p);
        return RedirectToAction("Index");
    }

    // EDIT GET
    public IActionResult Edit(int id)
    {
        var p = products.FirstOrDefault(x => x.Id == id);
        return View(p);
    }

    // EDIT POST
    [HttpPost]
    public IActionResult Edit(Product p)
    {
        var prod = products.FirstOrDefault(x => x.Id == p.Id);
        prod.Name = p.Name;
        prod.Price = p.Price;
        prod.Image = p.Image;
        return RedirectToAction("Index");
    }

    // DELETE
    public IActionResult Delete(int id)
    {
        var p = products.FirstOrDefault(x => x.Id == id);
        products.Remove(p);
        return RedirectToAction("Index");
    }
}