using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oraculo.Models;

namespace Oraculo.Controllers
{
    public class ComunidadesController : Controller
    {
        private readonly Contexto _context;

        public ComunidadesController(Contexto context)
        {
            _context = context;
        }

        // GET: Comunidades
        public async Task<IActionResult> Index()
        {
              return _context.Comunidades != null ? 
                          View(await _context.Comunidades.ToListAsync()) :
                          Problem("Entity set 'Contexto.Comunidades'  is null.");
        }

        // GET: Comunidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comunidades == null)
            {
                return NotFound();
            }

            var comunidades = await _context.Comunidades
                .FirstOrDefaultAsync(m => m.ComunidadesId == id);
            if (comunidades == null)
            {
                return NotFound();
            }

            return View(comunidades);
        }

        // GET: Comunidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comunidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComunidadesId,NomeComunidade")] Comunidades comunidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comunidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comunidades);
        }

        // GET: Comunidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comunidades == null)
            {
                return NotFound();
            }

            var comunidades = await _context.Comunidades.FindAsync(id);
            if (comunidades == null)
            {
                return NotFound();
            }
            return View(comunidades);
        }

        // POST: Comunidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComunidadesId,NomeComunidade")] Comunidades comunidades)
        {
            if (id != comunidades.ComunidadesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comunidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComunidadesExists(comunidades.ComunidadesId))
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
            return View(comunidades);
        }

        // GET: Comunidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comunidades == null)
            {
                return NotFound();
            }

            var comunidades = await _context.Comunidades
                .FirstOrDefaultAsync(m => m.ComunidadesId == id);
            if (comunidades == null)
            {
                return NotFound();
            }

            return View(comunidades);
        }

        // POST: Comunidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comunidades == null)
            {
                return Problem("Entity set 'Contexto.Comunidades'  is null.");
            }
            var comunidades = await _context.Comunidades.FindAsync(id);
            if (comunidades != null)
            {
                _context.Comunidades.Remove(comunidades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComunidadesExists(int id)
        {
          return (_context.Comunidades?.Any(e => e.ComunidadesId == id)).GetValueOrDefault();
        }
    }
}
