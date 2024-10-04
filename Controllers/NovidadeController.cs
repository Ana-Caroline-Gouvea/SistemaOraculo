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
    public class NovidadeController : Controller
    {
        private readonly Contexto _context;

        public NovidadeController(Contexto context)
        {
            _context = context;
        }

        // GET: Novidade
        public async Task<IActionResult> Index()
        {
              return _context.Novidade != null ? 
                          View(await _context.Novidade.ToListAsync()) :
                          Problem("Entity set 'Contexto.Novidade'  is null.");
        }

        // GET: Novidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Novidade == null)
            {
                return NotFound();
            }

            var novidade = await _context.Novidade
                .FirstOrDefaultAsync(m => m.NovidadeId == id);
            if (novidade == null)
            {
                return NotFound();
            }

            return View(novidade);
        }

        // GET: Novidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Novidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovidadeId,NovidadeFoto,NovidadeTexto")] Novidade novidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(novidade);
        }

        // GET: Novidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Novidade == null)
            {
                return NotFound();
            }

            var novidade = await _context.Novidade.FindAsync(id);
            if (novidade == null)
            {
                return NotFound();
            }
            return View(novidade);
        }

        // POST: Novidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NovidadeId,NovidadeFoto,NovidadeTexto")] Novidade novidade)
        {
            if (id != novidade.NovidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovidadeExists(novidade.NovidadeId))
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
            return View(novidade);
        }

        // GET: Novidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Novidade == null)
            {
                return NotFound();
            }

            var novidade = await _context.Novidade
                .FirstOrDefaultAsync(m => m.NovidadeId == id);
            if (novidade == null)
            {
                return NotFound();
            }

            return View(novidade);
        }

        // POST: Novidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Novidade == null)
            {
                return Problem("Entity set 'Contexto.Novidade'  is null.");
            }
            var novidade = await _context.Novidade.FindAsync(id);
            if (novidade != null)
            {
                _context.Novidade.Remove(novidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovidadeExists(int id)
        {
          return (_context.Novidade?.Any(e => e.NovidadeId == id)).GetValueOrDefault();
        }
    }
}
