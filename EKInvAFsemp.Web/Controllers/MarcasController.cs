

namespace EKInvAFsemp.Web.Controllers
{
    #region Libraries
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using EKInvAFsemp.Web.Classes;
    using EKInvAFsemp.Web.Context;
    using EKInvAFsemp.Web.Models;
    using EKInvAFsemp.Web.ViewModels; 
    #endregion


    public class MarcasController : Controller
    {
        #region Constructors

        private MySQLInventarios db;
        public MarcasController()
        {
            db = new MySQLInventarios();
        } 
        #endregion


        // GET: Marcas
        public ActionResult Index()
        {
            return View(db.Marcas.ToList());
        }

        // GET: Marcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }
            return View(marcas);
        }

        #region Create
        // GET: Marcas/Create
        public ActionResult Create()
        {
            ViewBag.DropDownTipos = (from c in db.Tipos select new { c.IdTipos,
                                        c.NombreTipo }).Distinct();
            return View();
        }

        // POST: Marcas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcasView view)
        {


          
            if (view == null)
            {
                ViewBag.DropDownTipos = (from c in db.Tipos select new { c.IdTipos, c.NombreTipo }).Distinct();
                ViewBag.ResultMessage = "COMPLETA LOS CAMPOS POR FAVOR!!";
                return View(view);
            }
           
            view.Alta = DateTime.Now;
          
           
            if (!ModelState.IsValid)
            {
                ViewBag.DropDownTipos = (from c in db.Tipos select new { c.IdTipos, c.NombreTipo }).Distinct();
                ViewBag.ResultMessage = "ALGUN CAMPO NO ES ADMITIDO REVISA POR FAVOR";
                return View(view);
            }

           
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    view.Imagen = "NULL";

                    var pic = string.Empty;
                    var folder = "~/Images/Brands";
                    if (view.ImageFile != null)
                    {
                        pic = FileHelper.UploadPhoto(view.ImageFile, folder);
                        pic = string.Format("{0}/{1}", folder, pic);
                    }
                    var Marcas = newMarca(view);
                    Marcas.Imagen = pic;
                    db.Marcas.Add(Marcas);
                    db.SaveChanges();
                    
                   
                    transaction.Commit();

                  
                    ViewBag.ResultMessage = "1";
                    ViewBag.DropDownTipos = (from c in db.Tipos select new { c.IdTipos, c.NombreTipo }).Distinct();
                    view = null;
                    return View();//POR SI DESEA AGREGAR MAS
                    //return RedirectToAction("Index");
                }
                catch (Exception)
                {
                  
                    transaction.Rollback();
                    ViewBag.ResultMessage = "0";
                }
            }

            ViewBag.ResultMessage = "1";
            ViewBag.DropDownTipos = (from c in db.Tipos select new { c.IdTipos, c.NombreTipo }).Distinct();
            return View();

            #region MyRegion

            //if (ModelState.IsValid)
            //{


            //    var pic = string.Empty;
            //    var folder = "~/Images/Brands";
            //    if (view.ImageFile != null)
            //    {
            //        pic = FileHelper.UploadPhoto(view.ImageFile, folder);
            //        pic = string.Format("{0}/{1}", folder, pic);
            //    }
            //    var Marcas = newMarca(view);
            //    Marcas.Imagen = pic;
            //    db.marcas.Add(Marcas);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(view); 
            #endregion
        }


        #endregion



        public ActionResult EditMarca(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }



            //ViewBag.ResultMessage = "1";
            //ViewBag.DropDownTipos = (from c in db.Tipos select new { c.IdTipos, c.NombreTipo }).Distinct();

            return PartialView(marcas);

        }



        // GET: Marcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }



            //ViewBag.ResultMessage = "1";
            //ViewBag.DropDownTipos = (from c in db.Tipos select new { c.IdTipos, c.NombreTipo }).Distinct();
            
            return PartialView("PartialEdit",marcas);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Marcas marcas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(marcas);
        }





        //CREATE NEW MARCAS ELEMENT
        private Marcas newMarca(MarcasView marcasView)
        {
            return new Marcas {
                IdMarca = marcasView.IdMarca,
                Marca =marcasView.Marca,
                Descripcion = marcasView.Descripcion,           
                Alta = marcasView.Alta,
                ActInac =marcasView.ActInac,
                Imagen = marcasView.Imagen,
                TipoMarca =marcasView.TipoMarca,
                
            };
            
        }


   

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Marcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return HttpNotFound();
            }
            return View(marcas);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marcas marcas = db.Marcas.Find(id);
            db.Marcas.Remove(marcas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
