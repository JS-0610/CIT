using PruebaTecnica.Models;
using PruebaTecnica.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            List<RolViewModel> lst = null;
            using(citEntities db= new citEntities())
            {
                lst = (from d in db.tbRoles
                       select new RolViewModel
                       {
                           Id= d.id_puesto,
                           Rol = d.rol
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RolAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new citEntities())
            {
                tbRoles oRol = new tbRoles();
                oRol.rol = model.Rol;

                db.tbRoles.Add(oRol);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Rol/Index"));
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            RolEditViewModel model = new RolEditViewModel();

            using (citEntities db = new citEntities())
            {
                var oRol = db.tbRoles.Find(id);
                model.Id = id;
                model.Rol = oRol.rol;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(RolEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

            using (citEntities db = new citEntities())
            {
                var oRol = db.tbRoles.Find(model.Id);
                oRol.rol = model.Rol;

                db.Entry(oRol).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Rol/Index"));
        }

        public ActionResult Delete(int id)
        {
            List<UserViewModel> lst = null;
            using (citEntities db2 = new citEntities())
            {
                lst = (from d in db2.tbUsuario
                       join c in db2.tbRoles on d.puesto equals c.id_puesto
                       where c.id_puesto == id
                       select new UserViewModel
                       {
                           Id = d.id_usuario

                       }).ToList();
            }
            if (lst.Count > 0)
            {
                return Content("Error: Este rol no se puede eliminar porque hay usuarios identificados con este rol");
            }
            else
            {
                using (var db = new citEntities())
                {
                    var oRol = db.tbRoles.Find(id);
                    db.Entry(oRol).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                
            }

            return Content("1");
        }
    }
    
}