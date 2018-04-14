using JqueryDataTableWithoutModal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqueryDataTableWithoutModal.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (DbModel _context = new DbModel())
            {
                List<Person> personList = _context.People.ToList();
                return Json(new { data = personList }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RedirectToAddorEdit(int id = 0)
        {

            if (id != 0)
                return RedirectToAction("AddEdit", "AddorEdit", id);
            else
                return RedirectToAction("AddEdit", "AddorEdit", 0);
        }
    }
}