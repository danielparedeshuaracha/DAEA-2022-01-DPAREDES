using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Lab14.Models;


namespace Lab14.Controllers
{
    public class CategoriesController : Controller
    {
        //ATRIBUTO CONTEXTO
        private NORTHWNDEntities _contexto;
        //PROPIEDAD CONTEXTO
        public NORTHWNDEntities Contexto
        {
            set
            {
                _contexto = value;
            }
            get
            {
                if (_contexto == null)
                    _contexto = new NORTHWNDEntities();
                return _contexto;
            }
        }

        // GET: Categories
        public ActionResult Index()
        {
            //envia a la vista la coleccion de entidades categories
            return View(Contexto.Categories.ToList());
        }

        //GET
        public ActionResult Details(int id)
        {
            var productosPorCategoria = from p in Contexto.Products
                                        orderby p.ProductName ascending
                                        where p.CategoryID == id
                                        select p;
            return View(productosPorCategoria.ToList());
        }

        //GET /Categories/Create
        //mostrar formulario
        public ActionResult Create()
        {
            return View();
        }
        //POST /Categories/Create
        //registrar nueva categoria en la BD
        [HttpPost]
        public ActionResult Create(Categories nuevaCategoria)
        {
            try
            { //validamos los datos ingresados
                if (ModelState.IsValid)
                {
                    //registramos la nueva categoría
                    Contexto.Categories.Add(nuevaCategoria);
                    Contexto.SaveChanges();
                    //llamamos al metodo index
                    return RedirectToAction("Index");
                }
                //muestra la vista create con datos ingresados
                return View(nuevaCategoria);
            }
            catch
            {
                //muestra la vista create vacia
                return View();
            }
        }

        //GET
        public ActionResult Edit(int? id)
        {
            //si el id es NULL
            if (id == null) //muestra un mensaje de error
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //Buscar por categoria a editar
            Categories CategoriaEditar = Contexto.Categories.Find(id);

            //Si la entidad es NULO (categoria no existe)
            if (CategoriaEditar == null)
                return HttpNotFound();

            return View(CategoriaEditar);
        }
        //POST : /Categories/Edit/5
        //registrar cambios en la categoria en la BD
        [HttpPost]
        public ActionResult Edit(Categories CategoriaEditar)
        {

            try
            { //validamos los datos ingresados
                if (ModelState.IsValid)
                { //graba los cambios en la categoria
                    Contexto.Entry(CategoriaEditar).State = EntityState.Modified;
                    Contexto.SaveChanges();
                    //llama al metodo index
                    return RedirectToAction("Index");
                }
                //muestra la vista Edit con los datos ingresados
                return View(CategoriaEditar);
            }
            catch
            {
                return View();
            }
        }

        //GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //Buscar por categoria a editar
            Categories CategoriaEliminar = Contexto.Categories.Find(id);

            //Si la entidad es NULO (categoria no existe)
            if (CategoriaEliminar == null)
                return HttpNotFound();

            return View(CategoriaEliminar);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(int? id, Categories Categoria1)
        {
            try
            {
                Categories CategoriaEliminar = new Categories();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    //busca categoria a eliminar
                    CategoriaEliminar = Contexto.Categories.Find(id);

                    //Si no encuentra la categoria
                    if (CategoriaEliminar == null)
                        return HttpNotFound();

                    //Elimina la categoria
                    Contexto.Categories.Remove(CategoriaEliminar);
                    Contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(CategoriaEliminar);
            }
            catch
            {
                return View();
            }
        }
    }
}