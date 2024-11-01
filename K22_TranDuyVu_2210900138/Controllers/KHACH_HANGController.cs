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
    public class KHACH_HANGController : Controller
    {
        private TDVEntities db = new TDVEntities();

        // GET: KHACH_HANG/TDVIndex
        public ActionResult TDVIndex()
        {
            return View(db.KHACH_HANG.ToList());
        }

        // GET: KHACH_HANG/TDVDetails/5
        public ActionResult TDVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // GET: KHACH_HANG/TDVCreate
        public ActionResult TDVCreate()
        {
            return View();
        }

        // POST: KHACH_HANG/TDVCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVCreate([Bind(Include = "KhachHangID,Ten,DiaChi,Email,SoDienThoai,NgayThamGia")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACH_HANG.Add(kHACH_HANG);
                db.SaveChanges();
                return RedirectToAction("TDVIndex"); // Updated redirect
            }

            return View(kHACH_HANG);
        }

        // GET: KHACH_HANG/TDVEdit/5
        public ActionResult TDVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: KHACH_HANG/TDVEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVEdit([Bind(Include = "KhachHangID,Ten,DiaChi,Email,SoDienThoai,NgayThamGia")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACH_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TDVIndex"); // Updated redirect
            }
            return View(kHACH_HANG);
        }

        // GET: KHACH_HANG/TDVDelete/5
        public ActionResult TDVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: KHACH_HANG/TDVDelete/5
        [HttpPost, ActionName("TDVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TDVDeleteConfirmed(int id)
        {
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            db.KHACH_HANG.Remove(kHACH_HANG);
            db.SaveChanges();
            return RedirectToAction("TDVIndex"); // Updated redirect
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
