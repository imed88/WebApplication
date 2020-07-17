using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApps.Models;

namespace WebApps.Controllers
{
    public class nursesController : Controller
    {
        private readonly IdentityAppContext _context;

        public nursesController(IdentityAppContext context)
        {
            _context = context;
        }

        // GET: nurses
        public async Task<IActionResult> Index()
        {
            return View(await _context.nurses.ToListAsync());
        }

        // GET: nurses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurses = await _context.nurses
                .SingleOrDefaultAsync(m => m.idNurse == id);
            if (nurses == null)
            {
                return NotFound();
            }

            return View(nurses);
        }

        // GET: nurses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: nurses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idNurse,nameNurse,emailNurse,passwordNurse,phoneNurse,Created")] nurses nurses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nurses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nurses);
        }

        // GET: nurses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurses = await _context.nurses.SingleOrDefaultAsync(m => m.idNurse == id);
            if (nurses == null)
            {
                return NotFound();
            }
            return View(nurses);
        }

        // POST: nurses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idNurse,nameNurse,emailNurse,passwordNurse,phoneNurse,Created")] nurses nurses)
        {
            if (id != nurses.idNurse)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nurses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!nursesExists(nurses.idNurse))
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
            return View(nurses);
        }

        // GET: nurses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nurses = await _context.nurses
                .SingleOrDefaultAsync(m => m.idNurse == id);
            if (nurses == null)
            {
                return NotFound();
            }

            return View(nurses);
        }

        // POST: nurses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nurses = await _context.nurses.SingleOrDefaultAsync(m => m.idNurse == id);
            _context.nurses.Remove(nurses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool nursesExists(int id)
        {
            return _context.nurses.Any(e => e.idNurse == id);
        }
    }
}
