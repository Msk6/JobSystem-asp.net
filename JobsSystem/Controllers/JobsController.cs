using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobsSystem.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace JobsSystem.Controllers
{
    public class JobsController : Controller
    {
        private readonly DataContext _context;

        public JobsController(DataContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .FirstOrDefaultAsync(m => m.id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Submissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Submissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("name,major,cvFile")] Submission submission)
        {
            if (ModelState.IsValid)
            {
                /*IFormFile userFile = submission.cvFile;
                var filePath = Path.Combine("~/CvFiles", userFile.FileName);
                System.IO.File.Create(filePath);*/
                submission.JobId = id;
                _context.Submissions.Add(submission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(submission);
        }
    }
}
