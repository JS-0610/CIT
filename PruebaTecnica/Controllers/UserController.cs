using PruebaTecnica.Models;
using PruebaTecnica.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserViewModel> lst = null;
            using (citEntities db = new citEntities())
            {
                lst = (from d in db.tbUsuario
                       join b in db.tbRoles on d.puesto equals b.id_puesto
                       select new UserViewModel
                       {
                           Id = d.id_usuario,
                           Nombre = d.nombre,
                           Usuario = d.usuario,
                           Email = d.email,
                           Celular = d.celular,
                           Puesto = b.rol
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
        public ActionResult Add(UserAddViewModel model)
        {
            if (!ModelState.IsValid)              
            {
                return View(model);
            }

            using (var db = new citEntities())
            {
                tbUsuario oUser = new tbUsuario();
                oUser.email = model.Email;
                oUser.nombre = model.Nombre;
                oUser.usuario = model.Usuario;
                oUser.celular = model.Celular;
                oUser.puesto = 1;

                db.tbUsuario.Add(oUser);               
                db.SaveChanges();                 
            }

            return Redirect(Url.Content("~/User/Index"));
        }

        public ActionResult Edit(int id)                       
        {
            UserEditViewModel model = new UserEditViewModel();  

            using (var db = new citEntities())
            {
                var oUser = db.tbUsuario.Find(id);                  
                model.Nombre = oUser.nombre;                  
                model.Usuario = oUser.usuario;
                model.Email = oUser.email;
                model.Celular = oUser.celular;
                model.Id = id;
            }

            return View(model);                                
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel model)     
        {
            if (!ModelState.IsValid)                           
            {
                return View(model);                            
            }

            using (var db = new citEntities())
            {
                var oUser = db.tbUsuario.Find(model.Id);
                oUser.email = model.Email;
                oUser.nombre = model.Nombre;
                oUser.usuario = model.Usuario;
                oUser.celular = model.Celular;
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified; 
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Index"));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (var db = new citEntities())
            {
                var oUser = db.tbUsuario.Find(id);

                db.Entry(oUser).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
    
}