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
    public class ComunidadeGeneroController : Controller
    {
        private readonly Contexto _context;

        public ComunidadeGeneroController(Contexto context)
        {
            _context = context;
        }

        // GET: ComunidadeGenero
        public async Task<IActionResult> Index()
        {
            var contexto = _context.ComunidadeGenero.Include(c => c.Comunidades).Include(c => c.Genero);
            return View(await contexto.ToListAsync());
        }

        // GET: ComunidadeGenero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ComunidadeGenero == null)
            {
                return NotFound();
            }

            var comunidadeGenero = await _context.ComunidadeGenero
                .Include(c => c.Comunidades)
                .Include(c => c.Genero)
                .FirstOrDefaultAsync(m => m.ComunidadeGeneroId == id);
            if (comunidadeGenero == null)
            {
                return NotFound();
            }

            return View(comunidadeGenero);
        }

        // GET: ComunidadeGenero/Create
        public IActionResult Create()
        {
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade");
            ViewData["GeneroId"] = new SelectList(_context.Genero, "GeneroId", "GeneroNome");
            return View();
        }

        // POST: ComunidadeGenero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComunidadeGeneroId,ComunidadesId,GeneroId")] ComunidadeGenero comunidadeGenero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comunidadeGenero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade", comunidadeGenero.ComunidadesId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "GeneroId", "GeneroNome", comunidadeGenero.GeneroId);
            return View(comunidadeGenero);
        }

        // GET: ComunidadeGenero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ComunidadeGenero == null)
            {
                return NotFound();
            }

            var comunidadeGenero = await _context.ComunidadeGenero.FindAsync(id);
            if (comunidadeGenero == null)
            {
                return NotFound();
            }
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade", comunidadeGenero.ComunidadesId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "GeneroId", "GeneroNome", comunidadeGenero.GeneroId);
            return View(comunidadeGenero);
        }

        // POST: ComunidadeGenero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComunidadeGeneroId,ComunidadesId,GeneroId")] ComunidadeGenero comunidadeGenero)
        {
            if (id != comunidadeGenero.ComunidadeGeneroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comunidadeGenero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComunidadeGeneroExists(comunidadeGenero.ComunidadeGeneroId))
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
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade", comunidadeGenero.ComunidadesId);
            ViewData["GeneroId"] = new SelectList(_context.Genero, "GeneroId", "GeneroNome", comunidadeGenero.GeneroId);
            return View(comunidadeGenero);
        }

        // GET: ComunidadeGenero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ComunidadeGenero == null)
            {
                return NotFound();
            }

            var comunidadeGenero = await _context.ComunidadeGenero
                .Include(c => c.Comunidades)
                .Include(c => c.Genero)
                .FirstOrDefaultAsync(m => m.ComunidadeGeneroId == id);
            if (comunidadeGenero == null)
            {
                return NotFound();
            }

            return View(comunidadeGenero);
        }

        // POST: ComunidadeGenero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ComunidadeGenero == null)
            {
                return Problem("Entity set 'Contexto.ComunidadeGenero'  is null.");
            }
            var comunidadeGenero = await _context.ComunidadeGenero.FindAsync(id);
            if (comunidadeGenero != null)
            {
                _context.ComunidadeGenero.Remove(comunidadeGenero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComunidadeGeneroExists(int id)
        {
          return (_context.ComunidadeGenero?.Any(e => e.ComunidadeGeneroId == id)).GetValueOrDefault();
        }
    }
}
