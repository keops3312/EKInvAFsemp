using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EKInvAFsemp.API.Context;
using EKInvAFsemp.Common.Classes.Models;

namespace EKInvAFsemp.API.Controllers
{
    [AllowAnonymous]
    public class MarcasAPIController : ApiController
    {
        private MySQLInventarios db = new MySQLInventarios();

        //GET:BUSCAR 
        [HttpGet]
        public IHttpActionResult searchMarca(string marca)
            {
            Marcas marcas = db.Marcas.
                    Where(c=> c.Marca==marca).
                        FirstOrDefault();
            //if (marcas == null)
            //{
            //    return NotFound();
            //}

            return Ok(marcas);
        }



        // GET: api/MarcasAPI
        public IQueryable<Marcas> GetMarcas()
        {
            return db.Marcas;
        }

        // GET: api/MarcasAPI/5
        [ResponseType(typeof(Marcas))]
        public IHttpActionResult GetMarcas(int id)
        {
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return NotFound();
            }

            return Ok(marcas);
        }

        // PUT: api/MarcasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarcas(int id, Marcas marcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marcas.IdMarca)
            {
                return BadRequest();
            }

            db.Entry(marcas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MarcasAPI
        [ResponseType(typeof(Marcas))]
        public IHttpActionResult PostMarcas(Marcas marcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marcas.Add(marcas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = marcas.IdMarca }, marcas);
        }

        // DELETE: api/MarcasAPI/5
        [ResponseType(typeof(Marcas))]
        public IHttpActionResult DeleteMarcas(int id)
        {
            Marcas marcas = db.Marcas.Find(id);
            if (marcas == null)
            {
                return NotFound();
            }

            db.Marcas.Remove(marcas);
            db.SaveChanges();

            return Ok(marcas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarcasExists(int id)
        {
            return db.Marcas.Count(e => e.IdMarca == id) > 0;
        }
    }
}