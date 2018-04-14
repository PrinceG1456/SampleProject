using JqueryDataTableWithoutModal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqueryDataTableWithoutModal.Controllers
{
    public class AddorEditController : Controller
    {
        // GET: AddorEdit
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.Title = "Add";
                return View("AddEdit", new Person());
            }
            else
            {
                ViewBag.Title = "Edit";
                using (DbModel _context = new DbModel())
                {
                    return View("AddEdit", _context.People.Where(x => x.id == id).FirstOrDefault<Person>());
                }
            }
        }
        [HttpPost]
        public ActionResult AddEdit(Person p)
        {

            using (DbModel _context = new DbModel())
            {
                if (p.id == 0)
                {
                    _context.People.Add(p);
                }
                else
                {
                    _context.Entry(p).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Unable toSave" }, JsonRequestBehavior.AllowGet);
                }
            }
            return RedirectToAction("Index", "List", null);
        }
    }
}