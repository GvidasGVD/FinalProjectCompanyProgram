using FinalProjectCompanyProgram.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCompanyProgram.Controllers
{
    public class DoorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        //[BindProperty]
        //public Door Door { get; set; }
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

        [Authorize(Roles = "Administrator, Owner")]
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
        [Authorize(Roles = "Administrator, Owner")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrator, Owner")]
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
        [Authorize(Roles = "Administrator, Owner")]
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
        [Authorize(Roles = "Administrator, Owner")]
        [HttpPost]
        //The ValidateAntiForgeryToken attribute helps prevent cross-site request forgery attacks.
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

        [Authorize(Roles = "Administrator, Owner")]
        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _context.Doors.ToListAsync() });
        }

        // POST: Doors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpDelete]
        public async Task<IActionResult> AjaxDelete(int id)
        {
            var door = await _context.Doors.FindAsync(id);
            _context.Doors.Remove(door);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion



        [Authorize(Roles = "Administrator, Owner")]
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
                return NotFound();
            }

            return View(door);
        }


        [Authorize(Roles = "Administrator, Owner")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var door = await _context.Doors.FindAsync(id);
            _context.Doors.Remove(door);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
