using SOPORTEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOPORTEE.Controllers
{
    public class DegreesController : Controller
    {
        // GET: Degrees
        public ActionResult Index()
        {
            inventoryContext db = new inventoryContext();

            return View(db.degrees.ToList());
        }


        public ActionResult Index2()
        {
            inventoryContext db = new inventoryContext();

            return View(db.degrees.ToList());
        }
    }
}