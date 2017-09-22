using Aanvragen.Entities;
using Aanvragen.Web.DAL;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Aanvragen.Web.Controllers {
    public class AttachmentController : Controller {
        private RequestDb db = new RequestDb();

        // GET: Attachment
        public async Task<ActionResult> Index() {
            return View(await db.Attachments.Where(x => x.Active == true).ToListAsync());
        }

        // GET: Attachment/Details/5
        public async Task<ActionResult> Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Name,Description,FileName,Extention,Url,Type")] Attachment attachment) {
            if (ModelState.IsValid) {
                db.Attachments.Add(attachment);
                await db.SaveChangesAsync();
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
        public async Task<ActionResult> Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,FileName,Extention,Url,Type")] Attachment attachment) {
            if (ModelState.IsValid) {
                db.Entry(attachment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(attachment);
        }

        // GET: Attachment/Delete/5
        public async Task<ActionResult> Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
            if (attachment == null) {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: Attachment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id) {
            Attachment attachment = db.Attachments.Find(id);
            attachment.Active = false;
            await db.SaveChangesAsync();
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
