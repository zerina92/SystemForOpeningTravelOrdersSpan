using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SystemForOpeningTravelOrdersSpan.Models;
using System.Net.Mail;


namespace SystemForOpeningTravelOrdersSpan.Controllers
{
    public class TravelOrdersController : Controller
    {
        private TravelOrderDBContext db = new TravelOrderDBContext();

        // GET: TravelOrders
        public ActionResult Index()
        {
            return View(db.TravelOrders.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Travels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id, subject, from, to, name, surname, dateOfStartTravel, dateOfEndTravel, travelVehicle, reasonForTravel, relationOfTravel, projectNumber, accommodation, accomodationDate, accomodationArrivalDate, accomodationDepartureDate, comment")] TravelOrder travelOrder, SystemForOpeningTravelOrdersSpan.Models.TravelOrder _objModelMail)
        {
            if (ModelState.IsValid)
            {
                db.TravelOrders.Add(travelOrder);
                db.SaveChanges();

                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.to);
                mail.From = new MailAddress(_objModelMail.from);
                mail.Subject = "Putni nalog" + _objModelMail.subject;
                string Body = "Pozdrav, <br />" + " Zamolio bih putni nalog za \n" + _objModelMail.name + " "
                   + _objModelMail.surname + ". \nDatum početka putovanja je " + _objModelMail.dateOfStartTravel + ", a datum povratka je " + _objModelMail.dateOfEndTravel + " . Putnik koristi " + _objModelMail.travelVehicle
                   + " za put." + " Razlog putovanja je " + _objModelMail.reasonForTravel + ". Relacija putovanja je slijedeća: "
                   + _objModelMail.relationOfTravel + ". Razlog dolaska je projekt broj: " + _objModelMail.projectNumber + ". Smještaj je potreban od: " + _objModelMail.accomodationArrivalDate + " do: "
                   + _objModelMail.accomodationDepartureDate + "<br /> Lijep pozdrav, <br />" + _objModelMail.name + " " + _objModelMail.name;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("zerina.salitrezic@gmail.com", "kinka92etfos");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return View(travelOrder);

            }
            return View(travelOrder);

        }

        // GET: TravelOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelOrder travelOrder = db.TravelOrders.Find(id);
            if (travelOrder == null)
            {
                return HttpNotFound();
            }
            return View(travelOrder);
        }

        // GET: TravelOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelOrder travelOrder = db.TravelOrders.Find(id);
            if (travelOrder == null)
            {
                return HttpNotFound();
            }
            return View(travelOrder);
        }

        // POST: TravelOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,subject,from,to,name,surname,dateOfStartTravel,dateOfEndTravel,travelVehicle,reasonForTravel,relationOfTravel,projectNumber,accommodation,accomodationDate,accomodationArrivalDate,accomodationDepartureDate,comment")] TravelOrder travelOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(travelOrder);
        }

        // GET: TravelOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelOrder travelOrder = db.TravelOrders.Find(id);
            if (travelOrder == null)
            {
                return HttpNotFound();
            }
            return View(travelOrder);
        }

        // POST: TravelOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TravelOrder travelOrder = db.TravelOrders.Find(id);
            db.TravelOrders.Remove(travelOrder);
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
