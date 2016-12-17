using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EQ.Models;

namespace EQ.Controllers
{
    public class TicketsController : Controller
    {
        private EQEntities db = new EQEntities();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.AspNetUser).Include(t => t.ServicePoint).Include(t => t.Service).Include(t => t.State);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ServicePointsId = new SelectList(db.ServicePoints, "ServicePointsId", "Name");
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Name");
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,AspNetUserId,ServiceId,Timestamp,TimeServed,StateId,ServicePointsId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", ticket.AspNetUserId);
            ViewBag.ServicePointsId = new SelectList(db.ServicePoints, "ServicePointsId", "Name", ticket.ServicePointsId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Name", ticket.ServiceId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", ticket.StateId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", ticket.AspNetUserId);
            ViewBag.ServicePointsId = new SelectList(db.ServicePoints, "ServicePointsId", "Name", ticket.ServicePointsId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Name", ticket.ServiceId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", ticket.StateId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,AspNetUserId,ServiceId,Timestamp,TimeServed,StateId,ServicePointsId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.AspNetUsers, "Id", "Email", ticket.AspNetUserId);
            ViewBag.ServicePointsId = new SelectList(db.ServicePoints, "ServicePointsId", "Name", ticket.ServicePointsId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Name", ticket.ServiceId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "StateName", ticket.StateId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
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
