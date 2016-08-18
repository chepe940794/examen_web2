using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenApi.Models;

namespace ExamenApi.Controllers
{
    public class FacturasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Facturas
        public ActionResult Index()
        {
            var facturaciones = db.Facturaciones.Include(f => f.Cliente).Include(f => f.Inventario);
            return View(facturaciones.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturaciones.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "Cedula");
            ViewBag.InventarioID = new SelectList(db.Inventarios, "Id", "Cantidad");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MontoTotal,SubTotal,Detalle,ClienteID,ProductosID,InventarioID")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Facturaciones.Add(facturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "Cedula", facturas.ClienteID);
            ViewBag.InventarioID = new SelectList(db.Inventarios, "Id", "Cantidad", facturas.InventarioID);
            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturaciones.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "Cedula", facturas.ClienteID);
            ViewBag.InventarioID = new SelectList(db.Inventarios, "Id", "Cantidad", facturas.InventarioID);
            return View(facturas);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MontoTotal,SubTotal,Detalle,ClienteID,ProductosID,InventarioID")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "Cedula", facturas.ClienteID);
            ViewBag.InventarioID = new SelectList(db.Inventarios, "Id", "Cantidad", facturas.InventarioID);
            return View(facturas);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturaciones.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facturas facturas = db.Facturaciones.Find(id);
            db.Facturaciones.Remove(facturas);
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
