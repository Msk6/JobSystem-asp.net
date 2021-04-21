using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobsSystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace JobsSystem.Controllers
{
    public class AdminSubmissionsController : Controller
    {
        private readonly DataContext _context;

        public AdminSubmissionsController(DataContext context)
        {
            _context = context;
        }

        // GET: AdminSubmissions
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Submissions.ToListAsync());
        }

        // GET: AdminSubmissions/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions
                .FirstOrDefaultAsync(m => m.id == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // GET: AdminSubmissions/Create
        [Authorize]
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: AdminSubmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(int id, [Bind("name,major,cvFile")] Submission submission)
        {
            if (ModelState.IsValid)
            {
                /*var filePath = Path.Combine("~/CvFiles", submission.cvFile.FileName);
                System.IO.File.Create(filePath);*/
                submission.JobId = id;
                _context.Add(submission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(submission);
        }

        // GET: AdminSubmissions/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }
            return View(submission);
        }

        // POST: AdminSubmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,major,cvFile")] Submission submission)
        {
            if (id != submission.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmissionExists(submission.id))
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
            return View(submission);
        }

        // GET: AdminSubmissions/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submissions
                .FirstOrDefaultAsync(m => m.id == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // POST: AdminSubmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submission = await _context.Submissions.FindAsync(id);
            _context.Submissions.Remove(submission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RelatedJobs(int id)
        {
            var selectedSubmission = await _context.Submissions.FirstOrDefaultAsync(s => s.id == id);
            var submisions = await _context.Submissions.Include(s => s.job).Where(s => s.name == selectedSubmission.name).ToListAsync();
            /*if (submisions[0] == null )
            {
                return NotFound();
            }*/
            
            return View(submisions);
        }

        private bool SubmissionExists(int id)
        {
            return _context.Submissions.Any(e => e.id == id);
        }
    }
}
