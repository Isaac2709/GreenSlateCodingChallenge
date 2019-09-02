using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GS.CodingChallenge.Domain.Models;
using GS.CodingChallenge.Application.Services;
using GS.CodingChallenge.WebApplication.Models;
using AutoMapper;

namespace GS.CodingChallenge.WebApplication.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectService _service;
        private readonly IMapper _mapper;

        public ProjectsController(ProjectService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var entities = await _service.GetAll();

            return Json(entities);
        }

        public async Task<IActionResult> List(int? id)
        {
            var entities = await _service.GetByUser(id.Value);
            var models = _mapper.Map<IList<ProjectViewModel>>(entities);

            return Json(models);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _service.Get(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return Json(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Credits"), FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(project);
                return RedirectToAction(nameof(Index));
            }
            return Json(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _service.Get(id.Value);
            if (project == null)
            {
                return NotFound();
            }
            return Json(project);
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Credits"), FromBody] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(project);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return Json(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _service.Get(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return Json(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            var entity = _service.Get(id);
            return entity == null;
        }
    }
}
