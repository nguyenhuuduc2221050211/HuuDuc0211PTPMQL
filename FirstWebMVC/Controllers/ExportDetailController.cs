using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models;

namespace FirstWebMVC.Controllers
{
    public class ExportDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExportDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExportDetail
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExportDetails.Include(e => e.Device).Include(e => e.ExportReceipt);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExportDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportDetail = await _context.ExportDetails
                .Include(e => e.Device)
                .Include(e => e.ExportReceipt)
                .FirstOrDefaultAsync(m => m.ExportDetailID == id);
            if (exportDetail == null)
            {
                return NotFound();
            }

            return View(exportDetail);
        }

        // GET: ExportDetail/Create
public IActionResult Create()
{
    ViewBag.Devices = _context.Devices.ToList();

    ViewBag.ExportReceipts = _context.ExportReceipts.ToList();

    return View();
}

        // POST: ExportDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create(ExportDetail exportDetail)
{
    var device = _context.Devices
                         .FirstOrDefault(x => x.DeviceID == exportDetail.DeviceID);

    if(device == null)
    {
        return NotFound();
    }

    if(device.Quantity < exportDetail.Quantity)
    {
        ModelState.AddModelError("", "Không đủ hàng trong kho");

        ViewBag.Devices = _context.Devices.ToList();
        ViewBag.ExportReceipts = _context.ExportReceipts.ToList();

        return View(exportDetail);
    }

    _context.ExportDetails.Add(exportDetail);

    device.Quantity -= exportDetail.Quantity;

    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
}

        // GET: ExportDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportDetail = await _context.ExportDetails.FindAsync(id);
            if (exportDetail == null)
            {
                return NotFound();
            }
            ViewData["DeviceID"] = new SelectList(_context.Devices, "DeviceID", "DeviceName", exportDetail.DeviceID);
            ViewData["ExportReceiptID"] = new SelectList(_context.ExportReceipts, "ExportReceiptID", "ExportReceiptID", exportDetail.ExportReceiptID);
            return View(exportDetail);
        }

        // POST: ExportDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExportDetailID,ExportReceiptID,DeviceID,Quantity,ExportPrice")] ExportDetail exportDetail)
        {
            if (id != exportDetail.ExportDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exportDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExportDetailExists(exportDetail.ExportDetailID))
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
            ViewData["DeviceID"] = new SelectList(_context.Devices, "DeviceID", "DeviceName", exportDetail.DeviceID);
            ViewData["ExportReceiptID"] = new SelectList(_context.ExportReceipts, "ExportReceiptID", "ExportReceiptID", exportDetail.ExportReceiptID);
            return View(exportDetail);
        }

        // GET: ExportDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportDetail = await _context.ExportDetails
                .Include(e => e.Device)
                .Include(e => e.ExportReceipt)
                .FirstOrDefaultAsync(m => m.ExportDetailID == id);
            if (exportDetail == null)
            {
                return NotFound();
            }

            return View(exportDetail);
        }

        // POST: ExportDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exportDetail = await _context.ExportDetails.FindAsync(id);
            if (exportDetail != null)
            {
                _context.ExportDetails.Remove(exportDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExportDetailExists(int id)
        {
            return _context.ExportDetails.Any(e => e.ExportDetailID == id);
        }
    }
}
