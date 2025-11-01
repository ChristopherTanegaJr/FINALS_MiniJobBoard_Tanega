using Microsoft.AspNetCore.Mvc;
using MiniJobBoard.Models;
using MiniJobBoard.Services;

namespace MiniJobBoard.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAllAsync();
            return View(jobs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var job = await _jobService.GetByIdAsync(id);
            if (job == null) return NotFound();
            return View(job);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Job job)
        {
            if (!ModelState.IsValid) return View(job);
            await _jobService.CreateAsync(job);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var job = await _jobService.GetByIdAsync(id);
            if (job == null) return NotFound();
            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Job job)
        {
            if (id != job.Id) return BadRequest();
            if (!ModelState.IsValid) return View(job);
            var ok = await _jobService.UpdateAsync(job);
            if (!ok) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
