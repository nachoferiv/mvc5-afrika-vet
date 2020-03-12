using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VetManagement.Core.Model;
using BLL;

namespace MVC.Controllers
{
    public class AppointmentsController : Controller
    {
        AppointmentBLL appBLL = new AppointmentBLL();
        DoctorBLL docBLL = new DoctorBLL();
        PatientBLL patientBLL = new PatientBLL();
        RoomBLL roomBLL = new RoomBLL();
        // GET: Appointments
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public JsonResult GetEvents()
        {
            var appointments = appBLL.List();
            return new JsonResult { Data = appointments, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult GetView (string id, string viewName, string message = "")
        {
            ViewBag.error = TempData["error"];
            Appointment app = null;
            if (id.Length>0)
            {
                app = appBLL.GetById(Int32.Parse(id));
            }
            
            ViewBag.DoctorId = new SelectList(docBLL.List(), "Id", "Name");
            ViewBag.PatientId = new SelectList(patientBLL.List(), "Id", "Name");
            ViewBag.RoomId = new SelectList(roomBLL.List(), "Id", "Name");

            if (message.Length > 0)
            {
                ViewBag.message = message;
            }

            return PartialView(viewName, app);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = appBLL.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientId,RoomId,DoctorId,StartDate,EndDate,Description")] Appointment appointment)
        {
            ViewBag.error = "";

            if (ModelState.IsValid)
            {
                var error = validate(appointment);
                if (error != null)
                {
                    ViewBag.error = error;
                    ViewBag.create = "error";
                    return View("Index");
                }
                appBLL.Insert(appointment);
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(docBLL.List(), "Id", "Name", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(patientBLL.List(), "Id", "Name", appointment.PatientId);
            ViewBag.RoomId = new SelectList(roomBLL.List(), "Id", "Name", appointment.RoomId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,RoomId,DoctorId,StartDate,EndDate,Description")] Appointment appointment)
        {
            ViewBag.error = "";

            if (ModelState.IsValid)
            {
                var error = validate(appointment);
                if (error != null)
                {
                    ViewBag.error = error; 
                    ViewBag.errorId = appointment.Id.ToString();

                    return View("Index");
                }
                appBLL.Update(appointment);
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(docBLL.List(), "Id", "Name", appointment.DoctorId);
            ViewBag.PatientId = new SelectList(patientBLL.List(), "Id", "Name", appointment.PatientId);
            ViewBag.RoomId = new SelectList(roomBLL.List(), "Id", "Name", appointment.RoomId);
            return View("Index");
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            appBLL.Delete(id);
            return RedirectToAction("Index");
        }

        public String validate(Appointment app)
        {
            var errors = appBLL.ValidationCheck(app);

            return errors;
        }
    }
}
