using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessCalendar.Models;

namespace FitnessCalendar.Controllers
{
    public class FitnessController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnessController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var records = await _context.FitnessRecords
                .Include(r => r.FullBodyTraining)
                .Include(r => r.Stretching)
                .OrderByDescending(r => r.Date)
                .ToListAsync();
            return View(records);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.TrainingTypes = await _context.TrainingTypes.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FitnessRecord record)
        {
            if (ModelState.IsValid)
            {
                _context.Add(record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TrainingTypes = await _context.TrainingTypes.ToListAsync();
            return View(record);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.FitnessRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            ViewBag.TrainingTypes = await _context.TrainingTypes.ToListAsync();
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FitnessRecord record)
        {
            if (id != record.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(record);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessRecordExists(record.Id))
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
            ViewBag.TrainingTypes = await _context.TrainingTypes.ToListAsync();
            return View(record);
        }

        private bool FitnessRecordExists(int id)
        {
            return _context.FitnessRecords.Any(e => e.Id == id);
        }
    }
} 