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
    public class VITRISPsController : Controller
    {
        private QLKhoDBContext db = new QLKhoDBContext();

        // GET: VITRISPs
        public ActionResult Index()
        {
            var vITRISPs = db.VITRISPs.Include(v => v.SANPHAM).Include(v => v.VITRIKHO);
            return View(vITRISPs.ToList());
        }

        // GET: VITRISPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VITRISP vITRISP = db.VITRISPs.Find(id);
            if (vITRISP == null)
            {
                return HttpNotFound();
            }
            return View(vITRISP);
        }

        // GET: VITRISPs/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP");
            ViewBag.MaVTK = new SelectList(db.VITRIKHOes, "MaVTK", "TenVTK");
            return View();
        }

        // POST: VITRISPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVTSP,SoLuong,MaSP,MaVTK")] VITRISP vITRISP)
        {
            if (ModelState.IsValid)
            {
                db.VITRISPs.Add(vITRISP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", vITRISP.MaSP);
            ViewBag.MaVTK = new SelectList(db.VITRIKHOes, "MaVTK", "TenVTK", vITRISP.MaVTK);
            return View(vITRISP);
        }

        // GET: VITRISPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VITRISP vITRISP = db.VITRISPs.Find(id);
            if (vITRISP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", vITRISP.MaSP);
            ViewBag.MaVTK = new SelectList(db.VITRIKHOes, "MaVTK", "TenVTK", vITRISP.MaVTK);
            return View(vITRISP);
        }

        // POST: VITRISPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVTSP,SoLuong,MaSP,MaVTK")] VITRISP vITRISP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vITRISP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SANPHAMs, "MaSP", "TenSP", vITRISP.MaSP);
            ViewBag.MaVTK = new SelectList(db.VITRIKHOes, "MaVTK", "TenVTK", vITRISP.MaVTK);
            return View(vITRISP);
        }

        // GET: VITRISPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VITRISP vITRISP = db.VITRISPs.Find(id);
            if (vITRISP == null)
            {
                return HttpNotFound();
            }
            return View(vITRISP);
        }

        // POST: VITRISPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VITRISP vITRISP = db.VITRISPs.Find(id);
            db.VITRISPs.Remove(vITRISP);
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
                    if (int.TryParse(id, out int Id))
                    {
                        var xoa = db.VITRISPs.Find(Id);
                        if (xoa != null)
                        {
                            db.VITRISPs.Remove(xoa);
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
