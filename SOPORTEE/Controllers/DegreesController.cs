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
        public ActionResult Index2(string buscar)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    IEnumerable<degrees> data = db.degrees.ToList();
                    if (!String.IsNullOrEmpty(buscar))
                    {
                        data = data.Where(s => s.degrees1.Contains(buscar));
                    }
                    return View(data.ToList());
                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(degrees a)
        {
            if(!ModelState.IsValid)
            return View();

            try
            {
                using (var db = new inventoryContext())
                {
                    db.degrees.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index2");
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error");
                return View();
            }      
        }


        public ActionResult Editar(int id)
        {

            try
            {
                using (var db = new inventoryContext())
                {
                    degrees deg = db.degrees.Find(id);
                    return View(deg);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
              
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(degrees a)
        {
            try
            {

                if (!ModelState.IsValid)     // o sea si los datos estan bien, si numero es numero y asi
                    return View();//si el modelo es validor retona la vista

                using (var db = new inventoryContext())
                {
                    //para actualizar primero encuentro al alumno
                    degrees deg = db.degrees.Find(a.id); //al es el alumno encontrado
                    deg.degrees1 = a.degrees1;
                    //agregar ultima actualizacion
                    db.SaveChanges();
                    return RedirectToAction("Index2");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}