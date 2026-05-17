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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitInquiry(Inquiry userInquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Inquiries.Add(userInquiry);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Index", userInquiry);
        }
    }
}