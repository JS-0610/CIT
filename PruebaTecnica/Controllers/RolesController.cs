using PruebaTecnica.Models.DBModel;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            List<RolViewModel> lst = null;
            using (citEntities db = new citEntities())
            {
                lst = (from b in db.tbRoles
                       select new RolViewModel
                       {
                           Id = b.id_puesto,
                           Rol = b.rol
                       }).ToList();
            }
            List<UserViewModel> lst1 = null;
            using (citEntities db = new citEntities())
            {
                lst1 = (from d in db.tbUsuario
                       select new UserViewModel
                       {
                           Id = d.id_usuario,
                           Nombre = d.nombre,
                       }).ToList();
            }
            ViewBag.Rol = lst;
            ViewBag.User = lst1;
            return View();
        }

        public ActionResult Modificar(int idUser, int idRol)
        {
            using (citEntities db = new citEntities()) 
            {
                var oUser = db.tbUsuario.Find(idUser);
                oUser.puesto = idRol;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
             
            return Content("1");
            
        }

        
    }
}
