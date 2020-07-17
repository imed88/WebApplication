using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApps.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WebApps.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IdentityAppContext _context;

        public AdminsController(IdentityAppContext context)
        {
            _context = context;
        }

        // GET: Admins
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.admins.ToListAsync());
        }

        // GET: Admins/Details/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admins = await _context.admins
                .SingleOrDefaultAsync(m => m.idAdmin == id);
            if (admins == null)
            {
                return NotFound();
            }

            return View(admins);
        }

        // GET: Admins/Create
        [Authorize(Roles = "Admin,User")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAdmin,nameAdmin,emailAdmin,passwordAdmin,phoneAdmin,Created")] Admins admins)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admins);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admins);
        }

        // GET: Admins/Edit/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admins = await _context.admins.SingleOrDefaultAsync(m => m.idAdmin == id);
            if (admins == null)
            {
                return NotFound();
            }
            return View(admins);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAdmin,nameAdmin,emailAdmin,passwordAdmin,phoneAdmin,Created")] Admins admins)
        {
            if (id != admins.idAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admins);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminsExists(admins.idAdmin))
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
            return View(admins);
        }

        // GET: Admins/Delete/5
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admins = await _context.admins
                .SingleOrDefaultAsync(m => m.idAdmin == id);
            if (admins == null)
            {
                return NotFound();
            }

            return View(admins);
        }

        // POST: Admins/Delete/5
        [Authorize(Roles = "Admin,User")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admins = await _context.admins.SingleOrDefaultAsync(m => m.idAdmin == id);
            _context.admins.Remove(admins);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin,User")]
        private bool AdminsExists(int id)
        {
            return _context.admins.Any(e => e.idAdmin == id);
        }


       


    }
}
