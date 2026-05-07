using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactList.Database;
using ContactList.Models;

namespace ContactList.Controllers;

public class ContactController : Controller
{
    private readonly ApplicationContext _context;

    public ContactController(ApplicationContext context)
    {
        _context = context;
    }

    // GET: /Contact
    public async Task<IActionResult> Index()
    {
        var contacts = await _context.Contacts!.ToArrayAsync();
        return View(contacts);
    }

    // GET: /Contact/Details/3
    public async Task<IActionResult> Details(int id)
    {
        var contact = await _context.Contacts!.FindAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // GET: /Contact/Create
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Contact.GetCategories());
        return View();
    }

    // POST: /Contact/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _context.Contacts!.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ViewBag.Categories = new SelectList(Contact.GetCategories());
        return View(contact);
    }

    // GET: /Contact/Delete/3
    public async Task<IActionResult> Delete(int id)
    {
        var contact = await _context.Contacts!.FindAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // POST: /Contact/Delete/3
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var contact = await _context.Contacts!.FindAsync(id);
        if (contact != null)
        {
            _context.Contacts!.Remove(contact);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}
