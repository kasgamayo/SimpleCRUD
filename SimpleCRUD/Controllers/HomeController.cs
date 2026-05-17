using Microsoft.AspNetCore.Mvc;
using SimpleCRUD.Models;

namespace SimpleCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Home/SubmitInquiry
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitInquiry(Inquiry userInquiry)
        {
            _context.Inquiries.Add(userInquiry);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = userInquiry.Id });
        }

        // GET: /Home/Details/5
        public IActionResult Details(int id)
        {
            var inquiry = _context.Inquiries.Find(id);
            if (inquiry == null)
            {
                return NotFound();
            }
            return View(inquiry);
        }

        // GET: /Home/Edit/5
        public IActionResult Edit(int id)
        {
            var inquiry = _context.Inquiries.Find(id);
            if (inquiry == null)
            {
                return NotFound();
            }
            return View(inquiry);
        }

        // POST: /Home/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Inquiry updatedInquiry)
        {
            _context.Inquiries.Update(updatedInquiry);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = updatedInquiry.Id });
        }

        // GET: /Home/History
        public IActionResult History()
        {
            var allInquiries = _context.Inquiries.ToList();
            return View(allInquiries);
        }

        // POST: /Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var inquiry = _context.Inquiries.Find(id);
            if (inquiry != null)
            {
                _context.Inquiries.Remove(inquiry);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}