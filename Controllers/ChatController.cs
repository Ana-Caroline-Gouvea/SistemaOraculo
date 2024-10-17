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
    public class ChatController : Controller
    {
        private readonly Contexto _context;

        public ChatController(Contexto context)
        {
            _context = context;
        }

        // GET: Chat
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Chat.Include(c => c.Categorias).Include(c => c.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Chat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chat == null)
            {
                return NotFound();
            }

            var chat = await _context.Chat
                .Include(c => c.Categorias)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ChatId == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // GET: Chat/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: Chat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChatId,Mensagem,UsuarioId,CategoriaId,Data")] Chat chat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", chat.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", chat.UsuarioId);
            return View(chat);
        }

        // GET: Chat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chat == null)
            {
                return NotFound();
            }

            var chat = await _context.Chat.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", chat.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", chat.UsuarioId);
            return View(chat);
        }

        // POST: Chat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChatId,Mensagem,UsuarioId,CategoriaId,Data")] Chat chat)
        {
            if (id != chat.ChatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(chat.ChatId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", chat.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", chat.UsuarioId);
            return View(chat);
        }

        // GET: Chat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chat == null)
            {
                return NotFound();
            }

            var chat = await _context.Chat
                .Include(c => c.Categorias)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ChatId == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chat == null)
            {
                return Problem("Entity set 'Contexto.Chat'  is null.");
            }
            var chat = await _context.Chat.FindAsync(id);
            if (chat != null)
            {
                _context.Chat.Remove(chat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatExists(int id)
        {
          return (_context.Chat?.Any(e => e.ChatId == id)).GetValueOrDefault();
        }
    }
}
