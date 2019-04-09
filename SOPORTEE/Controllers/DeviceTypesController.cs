using SOPORTEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOPORTEE.Controllers
{
    public class DeviceTypesController : Controller
    {
        // GET: DeviceTypes
        public ActionResult Index_DeviceTypes(string buscar)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    IEnumerable<deviceTypes> data = db.deviceTypes.ToList();
                    if (!String.IsNullOrEmpty(buscar))
                    {
                        data = data.Where(s => s.type.Contains(buscar));
                    }
                    return View(data.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public ActionResult Agregar_DeviceTypes() //este seria el get y aqui es donde creamos la vista
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar_DeviceTypes(deviceTypes a) //va a recibir una entidad alumno
        {
            if (!ModelState.IsValid)     // o sea si los datos estan bien, si numero es numero y asi
                return View();//si el modelo es validor retona la vista

            try
            {
                using (var db = new inventoryContext()) //abrir y cerrar la conexion, es mas recomendado
                {

                    
                    db.deviceTypes.Add(a); //si todo esta bien agregame al alumno
                    db.SaveChanges(); //guardar los cambios
                    return RedirectToAction("Index_DeviceTypes"); //si todo esta bien lo redireccionamos

                }
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error");
                return View();
            }
        }


        public ActionResult Editar_DeviceType(int id)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    deviceTypes dev = db.deviceTypes.Find(id);
                    return View(dev);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar_DeviceType(deviceTypes a)
        {
            try
            {

                {
                    if (!ModelState.IsValid)
                        return View();
                    using (var db= new inventoryContext())
                    {
                        deviceTypes dev = db.deviceTypes.Find(a.id);
                        dev.type = a.type;

                        db.SaveChanges();
                        return RedirectToAction("Index_DeviceTypes");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public ActionResult Borrar_DeviceType(int id)
        {
            try
            {
                using (var db = new inventoryContext())
                {
                    //para actualizar primero encuentro al alumno
                    deviceTypes lo = db.deviceTypes.Find(id); //al es el alumno encontrado
                    db.deviceTypes.Remove(lo);
                    db.SaveChanges();
                    return RedirectToAction("Index_DeviceTypes");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}