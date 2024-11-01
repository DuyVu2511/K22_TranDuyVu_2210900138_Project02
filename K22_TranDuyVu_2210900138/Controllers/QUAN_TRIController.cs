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
    public class QUAN_TRIController : Controller
    {
        private TDVEntities db = new TDVEntities();

        // GET: QUAN_TRI
        public ActionResult TDVIndex()
        {
            return View(db.QUAN_TRI.ToList());
        }

        // GET: QUAN_TRI/TDVDetails/5
        public ActionResult TDVDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/TDVCreate
        public ActionResult TDVCreate()
        {
            return View();
        }

        // POST: QUAN_TRI/TDVCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVCreate([Bind(Include = "AdminID,TenDangNhap,MatKhau,Email")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.QUAN_TRI.Add(qUAN_TRI);
                db.SaveChanges();
                return RedirectToAction("TDVIndex");
            }

            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/TDVEdit/5
        public ActionResult TDVEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: QUAN_TRI/TDVEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVEdit([Bind(Include = "AdminID,TenDangNhap,MatKhau,Email")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUAN_TRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TDVIndex");
            }
            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/TDVDelete/5
        public ActionResult TDVDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: QUAN_TRI/TDVDelete/5
        [HttpPost, ActionName("TDVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            db.QUAN_TRI.Remove(qUAN_TRI);
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
