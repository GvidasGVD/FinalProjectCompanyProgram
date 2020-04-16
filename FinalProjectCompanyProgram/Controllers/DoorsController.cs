using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectCompanyProgram.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectCompanyProgram.Controllers
{
    public class DoorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Door Door { get; set; }
        public DoorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doors
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doors.ToListAsync());
        }

        // GET: Doors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var door = await _context.Doors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (door == null)
            {
                return NotFound();
            }

            return View(door);
        }

        // GET: Doors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Model,DoorLeaf,DoorJamb,Hinges,Finish,Height,Width,Price,Additions")] Door door)
        {
            if (ModelState.IsValid)
            {
                _context.Add(door);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(door);
        }

        // GET: Doors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var door = await _context.Doors.FindAsync(id);
            if (door == null)
            {
                return NotFound();
            }
            return View(door);
        }

        // POST: Doors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Model,DoorLeaf,DoorJamb,Hinges,Finish,Height,Width,Price,Additions")] Door door)
        {
            if (id != door.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(door);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoorExists(door.Id))
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
            return View(door);
        }

        private bool DoorExists(int id)
        {
            return _context.Doors.Any(e => e.Id == id);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.Doors.ToListAsync() });
        }

        // POST: Doors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: Doors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var door = await _context.Doors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (door == null)
            {
                //return NotFound();
                return Json(new { success = false, message = "Error while Deleting" });
            }

            return View(door);
        }

        // POST: Doors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var door = await _context.Doors.FindAsync(id);
            _context.Doors.Remove(door);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
