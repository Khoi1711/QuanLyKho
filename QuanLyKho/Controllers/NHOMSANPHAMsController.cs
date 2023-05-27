using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKho.Models;

namespace QuanLyKho.Controllers
{
    public class NHOMSANPHAMsController : Controller
    {
        private QLKhoDBContext db = new QLKhoDBContext();

        // GET: NHOMSANPHAMs
        public ActionResult Index()
        {
            return View(db.NHOMSANPHAMs.ToList());
        }

        // GET: NHOMSANPHAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMSANPHAM nHOMSANPHAM = db.NHOMSANPHAMs.Find(id);
            if (nHOMSANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(nHOMSANPHAM);
        }

        // GET: NHOMSANPHAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHOMSANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhomSP,TenNhomSP,Mota")] NHOMSANPHAM nHOMSANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.NHOMSANPHAMs.Add(nHOMSANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHOMSANPHAM);
        }

        // GET: NHOMSANPHAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMSANPHAM nHOMSANPHAM = db.NHOMSANPHAMs.Find(id);
            if (nHOMSANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(nHOMSANPHAM);
        }

        // POST: NHOMSANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhomSP,TenNhomSP,Mota")] NHOMSANPHAM nHOMSANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHOMSANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHOMSANPHAM);
        }

        // GET: NHOMSANPHAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMSANPHAM nHOMSANPHAM = db.NHOMSANPHAMs.Find(id);
            if (nHOMSANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(nHOMSANPHAM);
        }

        // POST: NHOMSANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NHOMSANPHAM nHOMSANPHAM = db.NHOMSANPHAMs.Find(id);
            db.NHOMSANPHAMs.Remove(nHOMSANPHAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteSelected(string[] selectedIds)
        {
            if (selectedIds != null && selectedIds.Length > 0)
            {
                foreach (var id in selectedIds)
                {
                    if (int.TryParse(id, out int nhomsanPhamId))
                    {
                        var nhomsanPham = db.NHOMSANPHAMs.Find(nhomsanPhamId);
                        if (nhomsanPham != null)
                        {
                            db.NHOMSANPHAMs.Remove(nhomsanPham);
                        }
                    }
                }
                db.SaveChanges();
            }

            return new EmptyResult();
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
