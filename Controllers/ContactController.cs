using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactList.Models;

namespace ContactList.Controllers;

public class ContactController : Controller
{
    private readonly IContactRepository _repo;

    public ContactController(IContactRepository repo)
    {
        _repo = repo;
    }

    // GET: /Contact
    public IActionResult Index()
    {
        return View(_repo.GetAll());
    }

    // GET: /Contact/Details/3
    public IActionResult Details(int id)
    {
        var contact = _repo.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // GET: /Contact/Create
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_repo.GetCategories());
        return View();
    }

    // POST: /Contact/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _repo.Add(contact);
            return RedirectToAction("Index");
        }

        ViewBag.Categories = new SelectList(_repo.GetCategories());
        return View(contact);
    }

    // GET: /Contact/Delete/3
    public IActionResult Delete(int id)
    {
        var contact = _repo.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // POST: /Contact/Delete/3
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _repo.Remove(id);
        return RedirectToAction("Index");
    }
}
