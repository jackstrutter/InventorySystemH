using SOPORTEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOPORTEE.Controllers
{
    public class locationController : Controller
    {
        // GET: location
        public ActionResult Index(string buscar)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    IEnumerable<locations> data = db.locations.ToList();
                    if (!String.IsNullOrEmpty(buscar))
                    {
                        data = data.Where(s => s.location.Contains(buscar));
                    }
                    return View(data.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
         }



        public ActionResult Agregar_location()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_location(locations a)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventoryContext())
                {
                    db.locations.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error");
                return View();
            }
        }


        public ActionResult Editar_location(int id)
        {

            try
            {
                using (var db = new inventoryContext())
                {
                   locations lo = db.locations.Find(id);
                    return View(lo);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar_location(locations a)
        {
            try
            {

                if (!ModelState.IsValid)     // o sea si los datos estan bien, si numero es numero y asi
                    return View();//si el modelo es validor retona la vista

                using (var db = new inventoryContext())
                {
                    //para actualizar primero encuentral alumno
                    locations lo = db.locations.Find(a.id);
                    lo.location = a.location;

                    //agregar ultima actualizacion
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ActionResult Borrar_location(int id)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    //para actualizar primero encuentro al alumno
                    locations lo = db.locations.Find(id); //al es el alumno encontrado
                    db.locations.Remove(lo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}