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
    public class ComunidadeUsuarioController : Controller
    {
        private readonly Contexto _context;

        public ComunidadeUsuarioController(Contexto context)
        {
            _context = context;
        }

        // GET: ComunidadeUsuario
        public async Task<IActionResult> Index()
        {
            var contexto = _context.ComunidadeUsuario.Include(c => c.Comunidades).Include(c => c.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: ComunidadeUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ComunidadeUsuario == null)
            {
                return NotFound();
            }

            var comunidadeUsuario = await _context.ComunidadeUsuario
                .Include(c => c.Comunidades)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ComunidadeUsuarioId == id);
            if (comunidadeUsuario == null)
            {
                return NotFound();
            }

            return View(comunidadeUsuario);
        }

        // GET: ComunidadeUsuario/Create
        public IActionResult Create()
        {
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: ComunidadeUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComunidadeUsuarioId,UsuarioId,ComunidadesId")] ComunidadeUsuario comunidadeUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comunidadeUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade", comunidadeUsuario.ComunidadesId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", comunidadeUsuario.UsuarioId);
            return View(comunidadeUsuario);
        }

        // GET: ComunidadeUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ComunidadeUsuario == null)
            {
                return NotFound();
            }

            var comunidadeUsuario = await _context.ComunidadeUsuario.FindAsync(id);
            if (comunidadeUsuario == null)
            {
                return NotFound();
            }
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade", comunidadeUsuario.ComunidadesId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", comunidadeUsuario.UsuarioId);
            return View(comunidadeUsuario);
        }

        // POST: ComunidadeUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComunidadeUsuarioId,UsuarioId,ComunidadesId")] ComunidadeUsuario comunidadeUsuario)
        {
            if (id != comunidadeUsuario.ComunidadeUsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comunidadeUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComunidadeUsuarioExists(comunidadeUsuario.ComunidadeUsuarioId))
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
            ViewData["ComunidadesId"] = new SelectList(_context.Comunidades, "ComunidadesId", "NomeComunidade", comunidadeUsuario.ComunidadesId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", comunidadeUsuario.UsuarioId);
            return View(comunidadeUsuario);
        }

        // GET: ComunidadeUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ComunidadeUsuario == null)
            {
                return NotFound();
            }

            var comunidadeUsuario = await _context.ComunidadeUsuario
                .Include(c => c.Comunidades)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ComunidadeUsuarioId == id);
            if (comunidadeUsuario == null)
            {
                return NotFound();
            }

            return View(comunidadeUsuario);
        }

        // POST: ComunidadeUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ComunidadeUsuario == null)
            {
                return Problem("Entity set 'Contexto.ComunidadeUsuario'  is null.");
            }
            var comunidadeUsuario = await _context.ComunidadeUsuario.FindAsync(id);
            if (comunidadeUsuario != null)
            {
                _context.ComunidadeUsuario.Remove(comunidadeUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComunidadeUsuarioExists(int id)
        {
          return (_context.ComunidadeUsuario?.Any(e => e.ComunidadeUsuarioId == id)).GetValueOrDefault();
        }
    }
}
