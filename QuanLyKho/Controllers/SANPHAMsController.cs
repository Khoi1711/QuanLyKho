using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using PagedList;
using QuanLyKho.Models;

namespace QuanLyKho.Controllers
{
    public class SANPHAMsController : Controller
    {
        private QLKhoDBContext db = new QLKhoDBContext();

        // GET: SANPHAMs
        public ActionResult Index(String sortOrder, String nhomSP, int? page)
        {
            ViewBag.SortOrder = sortOrder;
            var sanPham = db.SANPHAMs.AsQueryable();
            if (!string.IsNullOrEmpty(nhomSP))
            {
                sanPham = sanPham.Where(sp => sp.NHOMSANPHAM.TenNhomSP == nhomSP);
            }
            switch (sortOrder)
            {
                case "asc":
                    sanPham = sanPham.OrderBy(sp => sp.SoLuongTon);
                    break;
                case "desc":
                    sanPham = sanPham.OrderByDescending(sp => sp.SoLuongTon);
                    break;
                case "asc-price":
                    sanPham = sanPham.OrderBy(sp => sp.DonGia);
                    break;
                case "desc-price":
                    sanPham = sanPham.OrderByDescending(sp => sp.DonGia);
                    break;
                default:
                    sanPham = sanPham.OrderBy(sp => sp.TenSP);
                    break;
            }
            return View(sanPham.ToList());
           /* sanPham = sanPham.OrderBy(nv => nv.MaSP);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(sanPham.ToPagedList(pageNumber,pageSize)); */
        }

        // GET: SANPHAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC");
            ViewBag.MaNhomSP = new SelectList(db.NHOMSANPHAMs, "MaNhomSP", "TenNhomSP");
            return View();
        }

        // POST: SANPHAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,Mota,DonGia,DonViTinh,SoLuongTon,NgayNhap,HinhAnh,MaNCC,MaNhomSP")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            ViewBag.MaNhomSP = new SelectList(db.NHOMSANPHAMs, "MaNhomSP", "TenNhomSP", sANPHAM.MaNhomSP);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            ViewBag.MaNhomSP = new SelectList(db.NHOMSANPHAMs, "MaNhomSP", "TenNhomSP", sANPHAM.MaNhomSP);
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,Mota,DonGia,DonViTinh,SoLuongTon,NgayNhap,HinhAnh,MaNCC,MaNhomSP")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NHACUNGCAPs, "MaNCC", "TenNCC", sANPHAM.MaNCC);
            ViewBag.MaNhomSP = new SelectList(db.NHOMSANPHAMs, "MaNhomSP", "TenNhomSP", sANPHAM.MaNhomSP);
            return View(sANPHAM);
        }

        // GET: SANPHAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
                    if (int.TryParse(id, out int sanPhamId))
                    {
                        var sanPham = db.SANPHAMs.Find(sanPhamId);
                        if (sanPham != null)
                        {
                            db.SANPHAMs.Remove(sanPham);
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
