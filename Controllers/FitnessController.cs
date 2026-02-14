using FitnessCalendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace FitnessCalendar.Controllers
{
    public class FitnessController(ApplicationDbContext context) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 90;
            int pageNumber = page ?? 1;
            
            var records = await _context.FitnessRecords
                .Include(r => r.FullBodyTraining)
                .Include(r => r.Stretching)
                .OrderByDescending(r => r.Date)
                .ToPagedListAsync(pageNumber, pageSize);

            return View(records);
        }

        public async Task<IActionResult> Create()
        {
            var trainingTypes = await _context.TrainingTypes.ToListAsync();
            ViewBag.FullBodyTypes = trainingTypes.Where(t => t.Name.Contains("FullBody")).ToList();
            ViewBag.StretchingTypes = trainingTypes.Where(t => t.Name.Contains("Stretching")).ToList();
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
            var trainingTypes = await _context.TrainingTypes.ToListAsync();
            ViewBag.FullBodyTypes = trainingTypes.Where(t => t.Name.Contains("FullBody")).ToList();
            ViewBag.StretchingTypes = trainingTypes.Where(t => t.Name.Contains("Stretching")).ToList();
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

            var trainingTypes = await _context.TrainingTypes.ToListAsync();
            ViewBag.FullBodyTypes = trainingTypes.Where(t => t.Name.Contains("FullBody")).ToList();
            ViewBag.StretchingTypes = trainingTypes.Where(t => t.Name.Contains("Stretching")).ToList();
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
            var trainingTypes = await _context.TrainingTypes.ToListAsync();
            ViewBag.FullBodyTypes = trainingTypes.Where(t => t.Name.Contains("FullBody")).ToList();
            ViewBag.StretchingTypes = trainingTypes.Where(t => t.Name.Contains("Stretching")).ToList();
            return View(record);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.FitnessRecords
                .Include(r => r.FullBodyTraining)
                .Include(r => r.Stretching)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.FitnessRecords.FindAsync(id);
            if (record != null)
            {
                _context.FitnessRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessRecordExists(int id)
        {
            return _context.FitnessRecords.Any(e => e.Id == id);
        }
    }
} 