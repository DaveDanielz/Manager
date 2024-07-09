using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manager.Data;
using Manager.Models;

namespace Manager.Controllers
{
    public class ChurchMembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChurchMembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChurchMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChurchMembers.ToListAsync());
        }

        // GET: ChurchMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (churchMember == null)
            {
                return NotFound();
            }

            return View(churchMember);
        }

        // GET: ChurchMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChurchMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChurchMember churchMember)
            
        {
            churchMember.CreatedById = "Dave";
            churchMember.CreatedOn = DateTime.Now;
            churchMember.ModifiedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(churchMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(churchMember);
        }

        // GET: ChurchMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMembers.FindAsync(id);
            if (churchMember == null)
            {
                return NotFound();
            }
            return View(churchMember);
        }

        // POST: ChurchMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,IsAdmin,Email,Phone,DateOfBirth,CreatedById,CreatedOn,ModifiedById,ModifiedOn")] ChurchMember churchMember)
        {
            if (id != churchMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(churchMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChurchMemberExists(churchMember.Id))
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
            return View(churchMember);
        }

        // GET: ChurchMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var churchMember = await _context.ChurchMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (churchMember == null)
            {
                return NotFound();
            }

            return View(churchMember);
        }

        // POST: ChurchMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var churchMember = await _context.ChurchMembers.FindAsync(id);
            if (churchMember != null)
            {
                _context.ChurchMembers.Remove(churchMember);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChurchMemberExists(int id)
        {
            return _context.ChurchMembers.Any(e => e.Id == id);
        }
    }
}
