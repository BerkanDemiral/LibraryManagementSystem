using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    public class LoanedController : Controller
    {
        // GET: Loaned
        DBLIBRARYEntities db = new DBLIBRARYEntities();
        public ActionResult Index()
        {
            var values = db.events.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Lend()
        {
            List<SelectListItem> bookValue = (from book in db.books.ToList().OrderBy(b=>b.name)
                                             select new SelectListItem
                                             {
                                                 Text = book.name,
                                                 Value = book.id.ToString()
                                             }).ToList();
            ViewBag.value1 = bookValue;

            List<SelectListItem> memberValue = (from member in db.members.ToList().OrderBy(m=>m.first_name)
                                             select new SelectListItem
                                             {
                                                 Text = member.first_name+" "+member.last_name,
                                                 Value = member.id.ToString()
                                             }).ToList();
            ViewBag.value2 = memberValue;

            List<SelectListItem> personnelValue = (from prsnl in db.personnels.ToList().OrderBy(p=>p.personnel)
                                              select new SelectListItem
                                              {
                                                  Text = prsnl.personnel,
                                                  Value = prsnl.id.ToString()
                                              }).ToList();
            ViewBag.value3 = personnelValue;

            return View();
        }

        [HttpPost]
        public ActionResult Lend (events evnt)
        {
            var book = db.books.Where(b =>b.id == evnt.books.id).FirstOrDefault(); // ilk ya da varsayılan değerini aldık
            var member = db.members.Where(m=> m.id == evnt.members.id).FirstOrDefault();
            var personnel = db.personnels.Where(p => p.id ==evnt.personnels.id).FirstOrDefault();

            evnt.books = book;
            evnt.members = member;
            evnt.personnels = personnel;

            db.events.Add(evnt);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ReturnBook(int id)
        {
            var returnBook = db.events.Find(id);
            return View("ReturnBook", returnBook);
        }

        public ActionResult UpdateLend(events evnt)
        {
            var evnts = db.events.Find(evnt.id);
            evnts.member_return_date = evnt.member_return_date;
            evnts.process_situation = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}