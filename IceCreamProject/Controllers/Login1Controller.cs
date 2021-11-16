using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceCreamProject.Models;

namespace IceCreamProject.Controllers
{
    public class Login1Controller : Controller
    {
        private readonly OrdersContext _context;

        public Login1Controller(OrdersContext context)
        {
            _context = context;
        }

        // GET: Login1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Login1.ToListAsync());
        }

        // GET: Login1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login1 = await _context.Login1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login1 == null)
            {
                return NotFound();
            }

            return View(login1);
        }

        // GET: Login1/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Login()
        { 
            return View();
        }
        public IActionResult TryLogin(string username,string password)
        {
            foreach (var item in _context.Login1)
            {
                if (item.UserName == username && item.Password == password)
                {
                    HelpStaticClass.IsAdmin = true;
                    return View("~/Views/Home/ManagerIndex.cshtml");
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

        // POST: Login1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserName,Password,Mail")] Login1 login1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login1);
        }

        // GET: Login1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login1 = await _context.Login1.FindAsync(id);
            if (login1 == null)
            {
                return NotFound();
            }
            return View(login1);
        }

        // POST: Login1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserName,Password,Mail")] Login1 login1)
        {
            if (id != login1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Login1Exists(login1.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(login1);
        }

        // GET: Login1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login1 = await _context.Login1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (login1 == null)
            {
                return NotFound();
            }

            return View(login1);
        }

        // POST: Login1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login1 = await _context.Login1.FindAsync(id);
            _context.Login1.Remove(login1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Login1Exists(int id)
        {
            return _context.Login1.Any(e => e.Id == id);
        }
    }
}
