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
    public class PersonAttachmentController : Controller {
        private RequestDb db = new RequestDb();

        // GET: PersonAttachment
        public async Task<ActionResult> Index() {
            var personAttachments = db.PersonAttachments.Include(p => p.Attachment).Include(p => p.Person);
            return View(await personAttachments.ToListAsync());
        }

        // GET: PersonAttachment/Details/5
        public async Task<ActionResult> Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonAttachment personAttachment = await db.PersonAttachments.FindAsync(id);
            if (personAttachment == null) {
                return HttpNotFound();
            }
            return View(personAttachment);
        }

        // GET: PersonAttachment/Create
        public ActionResult Create(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.AttachmentID = new SelectList(db.Attachments, "ID", "Name");
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", id);
            return View();
        }

        // POST: PersonAttachment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PersonID,AttachmentID,Action")] PersonAttachment personAttachment) {
            if (ModelState.IsValid) {
                db.PersonAttachments.Add(personAttachment);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Person", new { id = personAttachment.PersonID });
            }

            ViewBag.AttachmentID = new SelectList(db.Attachments, "ID", "Name", personAttachment.AttachmentID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", personAttachment.PersonID);
            return View(personAttachment);
        }

        // GET: PersonAttachment/Edit/5
        public async Task<ActionResult> Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonAttachment personAttachment = await db.PersonAttachments.FindAsync(id);
            if (personAttachment == null) {
                return HttpNotFound();
            }
            ViewBag.AttachmentID = new SelectList(db.Attachments, "ID", "Name", personAttachment.AttachmentID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", personAttachment.PersonID);
            return View(personAttachment);
        }

        // POST: PersonAttachment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,PersonID,AttachmentID,Action")] PersonAttachment personAttachment) {
            if (ModelState.IsValid) {
                db.Entry(personAttachment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AttachmentID = new SelectList(db.Attachments, "ID", "Name", personAttachment.AttachmentID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FirstName", personAttachment.PersonID);
            return View(personAttachment);
        }

        // GET: PersonAttachment/Delete/5
        public async Task<ActionResult> Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonAttachment personAttachment = await db.PersonAttachments.FindAsync(id);
            if (personAttachment == null) {
                return HttpNotFound();
            }
            return View(personAttachment);
        }

        // POST: PersonAttachment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id) {
            PersonAttachment personAttachment = await db.PersonAttachments.FindAsync(id);
            db.PersonAttachments.Remove(personAttachment);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Person", new { id = personAttachment.PersonID });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
