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
    public class GamesController : Controller
    {
        private TDVEntities db = new TDVEntities();

        // GET: Games/TDVIndex
        public ActionResult TDVIndex()
        {
            return View(db.Games.ToList());
        }

        // GET: Games/TDVDetails/5
        public ActionResult TDVDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/TDVCreate
        public ActionResult TDVCreate()
        {
            return View();
        }

        // POST: Games/TDVCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVCreate([Bind(Include = "GameID,Ten,TheLoai,MoTa,NgayPhatHanh,NhaPhatTrien,DanhGia")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("TDVIndex"); // Updated redirect
            }

            return View(game);
        }

        // GET: Games/TDVEdit/5
        public ActionResult TDVEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/TDVEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TDVEdit([Bind(Include = "GameID,Ten,TheLoai,MoTa,NgayPhatHanh,NhaPhatTrien,DanhGia")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TDVIndex"); // Updated redirect
            }
            return View(game);
        }

        // GET: Games/TDVDelete/5
        public ActionResult TDVDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/TDVDelete/5
        [HttpPost, ActionName("TDVDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TDVDeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
