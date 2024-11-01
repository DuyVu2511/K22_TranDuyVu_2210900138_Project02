using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22_TranDuyVu_2210900138.Models;

namespace K22_TranDuyVu_2210900138.Controllers
{
    public class DANH_GIAController : Controller
    {
        private TDVEntities db = new TDVEntities();

        // GET: DANH_GIA/TDVIndex
        public ActionResult TDVIndex()
        {
            var dANH_GIA = db.DANH_GIA.Include(d => d.QUAN_TRI).Include(d => d.Game).Include(d => d.KHACH_HANG);
            return View(dANH_GIA.ToList());
        }

        // GET: DANH_GIA/TDVDetails/5
        public ActionResult TDVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            return View(dANH_GIA);
        }

        // GET: DANH_GIA/TDVCreate
        public ActionResult TDVCreate()
        {
            ViewBag.AdminID = new SelectList(db.QUAN_TRI, "AdminID", "TenDangNhap");
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Ten");
            ViewBag.KhachHangID = new SelectList(db.KHACH_HANG, "KhachHangID", "Ten");
            return View();
        }

        // POST: DANH_GIA/TDVCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVCreate([Bind(Include = "ReviewID,GameID,AdminID,KhachHangID,NoiDungDanhGia,DanhGia,NgayDanhGia")] DANH_GIA dANH_GIA)
        {
            if (ModelState.IsValid)
            {
                db.DANH_GIA.Add(dANH_GIA);
                db.SaveChanges();
                return RedirectToAction("TDVIndex");
            }

            ViewBag.AdminID = new SelectList(db.QUAN_TRI, "AdminID", "TenDangNhap", dANH_GIA.AdminID);
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Ten", dANH_GIA.GameID);
            ViewBag.KhachHangID = new SelectList(db.KHACH_HANG, "KhachHangID", "Ten", dANH_GIA.KhachHangID);
            return View(dANH_GIA);
        }

        // GET: DANH_GIA/TDVEdit/5
        public ActionResult TDVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.QUAN_TRI, "AdminID", "TenDangNhap", dANH_GIA.AdminID);
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Ten", dANH_GIA.GameID);
            ViewBag.KhachHangID = new SelectList(db.KHACH_HANG, "KhachHangID", "Ten", dANH_GIA.KhachHangID);
            return View(dANH_GIA);
        }

        // POST: DANH_GIA/TDVEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVEdit([Bind(Include = "ReviewID,GameID,AdminID,KhachHangID,NoiDungDanhGia,DanhGia,NgayDanhGia")] DANH_GIA dANH_GIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANH_GIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TDVIndex");
            }
            ViewBag.AdminID = new SelectList(db.QUAN_TRI, "AdminID", "TenDangNhap", dANH_GIA.AdminID);
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Ten", dANH_GIA.GameID);
            ViewBag.KhachHangID = new SelectList(db.KHACH_HANG, "KhachHangID", "Ten", dANH_GIA.KhachHangID);
            return View(dANH_GIA);
        }

        // GET: DANH_GIA/TDVDelete/5
        public ActionResult TDVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            if (dANH_GIA == null)
            {
                return HttpNotFound();
            }
            return View(dANH_GIA);
        }

        // POST: DANH_GIA/TDVDelete/5
        [HttpPost, ActionName("TDVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TDVDeleteConfirmed(int id)
        {
            DANH_GIA dANH_GIA = db.DANH_GIA.Find(id);
            db.DANH_GIA.Remove(dANH_GIA);
            db.SaveChanges();
            return RedirectToAction("TDVIndex");
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
