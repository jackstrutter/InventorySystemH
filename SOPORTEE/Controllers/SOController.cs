using SOPORTEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOPORTEE.Controllers
{
    public class SOController : Controller
    {
        // GET: SO
        public ActionResult Index_SO(string buscar)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    IEnumerable<operatingSystems> data = db.operatingSystems.ToList();
                    if (!String.IsNullOrEmpty(buscar))
                    {
                        data = data.Where(s => s.OperatingSystem.Contains(buscar));
                    }
                    return View(data.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public ActionResult Agregar_SO() //este seria el get y aqui es donde creamos la vista
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_SO(operatingSystems a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventoryContext())
                {
                    db.operatingSystems.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index_SO");

                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error");
                return View();
            }
        }



        public ActionResult Editar_SO(int id)
        {

            try
            {
                using (var db = new inventoryContext())
                {
                    operatingSystems so= db.operatingSystems.Find(id);
                    return View(so);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar_SO(operatingSystems a)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View();

                using (var db = new inventoryContext())
                {
                    operatingSystems so = db.operatingSystems.Find(a.id);
                    so.OperatingSystem = a.OperatingSystem;
                    //agregar ultima actualizacion
                    db.SaveChanges();
                    return RedirectToAction("Index_SO");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public ActionResult Borrar_SO(int id)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    operatingSystems so = db.operatingSystems.Find(id); //al es el alumno encontrado
                    db.operatingSystems.Remove(so);
                    db.SaveChanges();
                    return RedirectToAction("Index_SO");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}