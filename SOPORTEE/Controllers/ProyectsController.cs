using SOPORTEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOPORTEE.Controllers
{
    public class ProyectsController : Controller
    {
        // GET: Proyects
        public ActionResult Index_Proyects(string buscar)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    IEnumerable<proyects> data = db.proyects.ToList();
                    if (!String.IsNullOrEmpty(buscar))
                    {
                        data = data.Where(s => s.proyect.Contains(buscar));
                    }
                    return View(data.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public ActionResult Agregar_Proyects() //este seria el get y aqui es donde creamos la vista
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_Proyects(proyects a) 
        {
            if (!ModelState.IsValid)     
                return View();

            try
            {
                using (var db = new inventoryContext()) 
                {        
                    db.proyects.Add(a); 
                    db.SaveChanges(); 
                    return RedirectToAction("Index_Proyects"); 

                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error");
                return View();
            }
        }


        public ActionResult Editar_Proyects(int id)
        {

            try
            {
                using (var db = new inventoryContext())
                {
                    proyects pro = db.proyects.Find(id);
                    return View(pro);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar_Proyects(proyects a)
        {
            try
            {

                if (!ModelState.IsValid)   
                    return View();

                using (var db = new inventoryContext())
                {
                    proyects pro = db.proyects.Find(a.id); 
                    pro.proyect = a.proyect;
                    //agregar ultima actualizacion
                    db.SaveChanges();
                    return RedirectToAction("Index_Proyects");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }





        public ActionResult Borrar_Proyects(int id)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    proyects lo = db.proyects.Find(id); //al es el alumno encontrado
                    db.proyects.Remove(lo);
                    db.SaveChanges();
                    return RedirectToAction("Index_Proyects");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}