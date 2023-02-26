using PruebaTecnica.Models;
using PruebaTecnica.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ProductoViewModel> lst = null;
            using(citEntities db = new citEntities()){
                lst = (from d in db.tbProductos
                       where d.estado == 1
                       select new ProductoViewModel
                       {
                           Id = d.id_producto,
                           Nombre = d.nombre,
                           Precio = d.precio,
                           Descripcion = d.descripcion,
                           Imagen= d.imagen,
                           Unidad = d.unidad,
                           Cantidad = d.cantidad
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
        public ActionResult Add(ProductoAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new citEntities())
            {
                tbProductos oProducto = new tbProductos();
                oProducto.nombre = model.Nombre;
                oProducto.precio = model.Precio;
                oProducto.descripcion = model.Descripcion;
                oProducto.imagen = Url.Content("~/Imagenes/") + model.Imagen;
                oProducto.unidad = model.Unidad;
                oProducto.cantidad = model.Cantidad;
                oProducto.estado = 1;

                db.tbProductos.Add(oProducto);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Producto/Index"));
        }

        public ActionResult Edit(int id) {
            ProductoEditViewModel model = new ProductoEditViewModel();

            using (var db = new citEntities())
            {
                var oProducto = db.tbProductos.Find(id);
                model.Nombre = oProducto.nombre;
                model.Precio = oProducto.precio;
                model.Descripcion = oProducto.descripcion;
                model.Unidad = oProducto.unidad;
                model.Cantidad = oProducto.cantidad;
                model.Imagen = oProducto.imagen;
                model.Id = id;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ProductoEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new citEntities())
            {
                var oProducto = db.tbProductos.Find(model.Id);
                oProducto.nombre = model.Nombre;
                oProducto.precio = model.Precio;
                oProducto.descripcion = model.Descripcion;
                oProducto.imagen = Url.Content("~/Imagenes/") + model.Imagen;
                oProducto.unidad = model.Unidad;
                oProducto.cantidad = model.Cantidad;

                db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Producto/Index"));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (var db = new citEntities())
            {
                var oProducto = db.tbProductos.Find(id);
                oProducto.estado = 0;
                db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}