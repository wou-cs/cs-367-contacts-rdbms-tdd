using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactList.Models;
using ContactList.Services;

namespace ContactList.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _service;

    public ContactController(IContactService service)
    {
        _service = service;
    }

    // GET: /Contact
    public async Task<IActionResult> Index()
    {
        return View(await _service.GetAllAsync());
    }

    // GET: /Contact/Details/3
    public async Task<IActionResult> Details(int id)
    {
        return await _service.GetByIdAsync(id) is { } c ? View(c) : NotFound();
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
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(Contact.GetCategories());
            return View(contact);
        }
        await _service.AddAsync(contact);
        return RedirectToAction(nameof(Index));
    }

    // GET: /Contact/Delete/3
    public async Task<IActionResult> Delete(int id)
    {
        return await _service.GetByIdAsync(id) is { } c ? View(c) : NotFound();
    }

    // POST: /Contact/Delete/3
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
