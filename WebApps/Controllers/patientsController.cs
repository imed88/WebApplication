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
    public class patientsController : Controller
    {
        private readonly IdentityAppContext _context;

        public patientsController(IdentityAppContext context)
        {
            _context = context;
        }

        // GET: patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.patients.ToListAsync());
        }

        // GET: patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.patients
                .SingleOrDefaultAsync(m => m.idPatients == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        // GET: patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPatients,namePatients,phonePatients,gender,health_condition,doctor_id,nurse_id,Created")] patients patients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patients);
        }

        // GET: patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.patients.SingleOrDefaultAsync(m => m.idPatients == id);
            if (patients == null)
            {
                return NotFound();
            }
            return View(patients);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPatients,namePatients,phonePatients,gender,health_condition,doctor_id,nurse_id,Created")] patients patients)
        {
            if (id != patients.idPatients)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!patientsExists(patients.idPatients))
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
            return View(patients);
        }

        // GET: patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.patients
                .SingleOrDefaultAsync(m => m.idPatients == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patients = await _context.patients.SingleOrDefaultAsync(m => m.idPatients == id);
            _context.patients.Remove(patients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool patientsExists(int id)
        {
            return _context.patients.Any(e => e.idPatients == id);
        }
    }
}
