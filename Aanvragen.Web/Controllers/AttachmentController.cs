using Aanvragen.Entities;
using Aanvragen.Web.DAL;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aanvragen.Web.Controllers {
    public class AttachmentController : Controller {
        private RequestDb db = new RequestDb();

        // GET: Attachment
        public ActionResult Index() {
            return View(db.Attachments.ToList());
        }

        // GET: Attachment/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null) {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // GET: Attachment/Create
        public ActionResult Create(string url) {
            return View();
        }

        // POST: Attachment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,FileName,Extention,Url,Type")] Attachment attachment) {
            if (ModelState.IsValid) {
                db.Attachments.Add(attachment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attachment);
        }

        // Simple MultiPart file upload form
        public ActionResult Upload() {
            return View();
        }

        // The file uploader
        public ActionResult Uploader() {
            foreach (string file in Request.Files) {
                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;

                if (hpf.ContentLength == 0)
                    continue;
                string savedFileName = Path.Combine(
                   AppDomain.CurrentDomain.BaseDirectory,
                   "UploadDir/",
                   Path.GetFileName(hpf.FileName));

                hpf.SaveAs(savedFileName);

                TempData["fileName"] = Path.GetFileName(hpf.FileName);
                TempData["fileNameLean"] = Path.GetFileNameWithoutExtension(hpf.FileName);
                TempData["Extention"] = Path.GetExtension(hpf.FileName);
                TempData["Url"] = this.Request.Url.ToString().Replace("/Attachment/Uploader", "/UploadDir/" + Path.GetFileName(hpf.FileName));
            }

            return View();
        }

        // GET: Attachment/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null) {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: Attachment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,FileName,Extention,Url,Type")] Attachment attachment) {
            if (ModelState.IsValid) {
                db.Entry(attachment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attachment);
        }

        // GET: Attachment/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null) {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: Attachment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Attachment attachment = db.Attachments.Find(id);
            db.Attachments.Remove(attachment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
