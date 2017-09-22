using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aanvragen.Entities;
using Aanvragen.Web.DAL;

namespace Aanvragen.Web.Controllers {
    public class RequestAttachmentController : Controller {
        private RequestDb db = new RequestDb();

        // GET: RequestAttachment
        public async Task<ActionResult> Index() {
            var requestAttachments = db.RequestAttachments.Include(r => r.Attachment).Include(r => r.Request);
            return View(await requestAttachments.ToListAsync());
        }

        // GET: RequestAttachment/Details/5
        public async Task<ActionResult> Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestAttachment requestAttachment = await db.RequestAttachments.FindAsync(id);
            if (requestAttachment == null) {
                return HttpNotFound();
            }
            return View(requestAttachment);
        }

        // GET: RequestAttachment/Create
        public ActionResult Create(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.AttachmentID = new SelectList(db.Attachments, "ID", "Name");
            ViewBag.RequestID = new SelectList(db.Requests, "ID", "RequestNumber", id);
            return View();
        }

        // POST: RequestAttachment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RequestID,AttachmentID,Action")] RequestAttachment requestAttachment) {
            if (ModelState.IsValid) {
                db.RequestAttachments.Add(requestAttachment);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Request", new { id = requestAttachment.RequestID });
            }

            ViewBag.AttachmentID = new SelectList(db.Attachments, "ID", "Name", requestAttachment.AttachmentID);
            ViewBag.RequestID = new SelectList(db.Requests, "ID", "RequestNumber", requestAttachment.RequestID);
            return View(requestAttachment);
        }

        // GET: RequestAttachment/Edit/5
        public async Task<ActionResult> Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestAttachment requestAttachment = await db.RequestAttachments.FindAsync(id);
            if (requestAttachment == null) {
                return HttpNotFound();
            }
            ViewBag.AttachmentID = new SelectList(db.Attachments, "ID", "Name", requestAttachment.AttachmentID);
            ViewBag.RequestID = new SelectList(db.Requests, "ID", "RequestNumber", requestAttachment.RequestID);
            return View(requestAttachment);
        }

        // POST: RequestAttachment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,RequestID,AttachmentID,Action")] RequestAttachment requestAttachment) {
            if (ModelState.IsValid) {
                db.Entry(requestAttachment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AttachmentID = new SelectList(db.Attachments, "ID", "Name", requestAttachment.AttachmentID);
            ViewBag.RequestID = new SelectList(db.Requests, "ID", "RequestNumber", requestAttachment.RequestID);
            return View(requestAttachment);
        }

        // GET: RequestAttachment/Delete/5
        public async Task<ActionResult> Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestAttachment requestAttachment = await db.RequestAttachments.FindAsync(id);
            if (requestAttachment == null) {
                return HttpNotFound();
            }
            return View(requestAttachment);
        }

        // POST: RequestAttachment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id) {
            RequestAttachment requestAttachment = await db.RequestAttachments.FindAsync(id);
            db.RequestAttachments.Remove(requestAttachment);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Request", new { id = requestAttachment.RequestID });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
