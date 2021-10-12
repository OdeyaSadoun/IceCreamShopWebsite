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
    public class ConnectUsController : Controller
    {
        private readonly OrdersContext _context;

        public ConnectUsController(OrdersContext context)
        {
            _context = context;
        }

        // GET: ConnectUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConnectUs.ToListAsync());
        }

        // GET: ConnectUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectUs = await _context.ConnectUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (connectUs == null)
            {
                return NotFound();
            }

            return View(connectUs);
        }

        // GET: ConnectUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConnectUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Message,Email")] ConnectUs connectUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(connectUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(connectUs);
        }

        // GET: ConnectUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectUs = await _context.ConnectUs.FindAsync(id);
            if (connectUs == null)
            {
                return NotFound();
            }
            return View(connectUs);
        }

        // POST: ConnectUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Message,Email")] ConnectUs connectUs)
        {
            if (id != connectUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(connectUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConnectUsExists(connectUs.Id))
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
            return View(connectUs);
        }

        // GET: ConnectUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var connectUs = await _context.ConnectUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (connectUs == null)
            {
                return NotFound();
            }

            return View(connectUs);
        }

        // POST: ConnectUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var connectUs = await _context.ConnectUs.FindAsync(id);
            _context.ConnectUs.Remove(connectUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConnectUsExists(int id)
        {
            return _context.ConnectUs.Any(e => e.Id == id);
        }
    }
}
