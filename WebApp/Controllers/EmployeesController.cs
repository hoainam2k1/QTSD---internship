using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QTSD_internship.Models;

namespace WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly QTSDContext _context;

        public EmployeesController(QTSDContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var qTSDContext = _context.Employees.Include(e => e.Position);
            return View(await qTSDContext.ToListAsync());
        }


        // GET: Employees/AddOrEdit
        // GET: Employees/AddOrEdit/5
        public async Task<IActionResult> AddOrEdit(string id = null)
        {
            if (id == null)
            {
                ViewData["Vitri"] = new SelectList(_context.Positions, "PositionId", "Name");
                return View(new Employee());
            }
            else
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                ViewData["Vitri"] = new SelectList(_context.Positions, "PositionId", "Name");
                return View(employee);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(string id, [Bind("Id,Name,Age,Address,PositionId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var empl = await _context.Employees.FindAsync(id);
                //Insert
                if (empl == null)
                {
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                    catch(Exception ex)
                    {
                        if (!EmployeeExists(employee.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Employees.ToList()) });
            }
            
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", employee) });
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
