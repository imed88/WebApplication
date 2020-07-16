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
    public class doctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public doctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: doctors
        public async Task<IActionResult> Index()
        {
            return View(await _context.doctors.ToListAsync());
        }

        // GET: doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.doctors
                .SingleOrDefaultAsync(m => m.idDoctors == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // GET: doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDoctors,nameDoctors,emailDoctors,phoneDoctors,gender,specialist,Created")] doctors doctors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctors);
        }

        // GET: doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.doctors.SingleOrDefaultAsync(m => m.idDoctors == id);
            if (doctors == null)
            {
                return NotFound();
            }
            return View(doctors);
        }

        // POST: doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDoctors,nameDoctors,emailDoctors,phoneDoctors,gender,specialist,Created")] doctors doctors)
        {
            if (id != doctors.idDoctors)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!doctorsExists(doctors.idDoctors))
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
            return View(doctors);
        }

        // GET: doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.doctors
                .SingleOrDefaultAsync(m => m.idDoctors == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctors = await _context.doctors.SingleOrDefaultAsync(m => m.idDoctors == id);
            _context.doctors.Remove(doctors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool doctorsExists(int id)
        {
            return _context.doctors.Any(e => e.idDoctors == id);
        }
    }
}
