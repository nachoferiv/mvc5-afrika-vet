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
using System.IO;

namespace MVC.Controllers
{
    public class PatientsController : Controller
    {

        // GET: Patients
        public ActionResult Index()
        {
            var patientBll = new PatientBLL();  
            return View(patientBll.List());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patientBll = new PatientBLL();
            Patient patient = patientBll.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            var clientBll = new ClientBLL();
            ViewBag.ClientId = new SelectList(clientBll.List(), "Id", "FullName");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ClientId,Gender,ImagePath")] Patient patient, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && patient.Name != null && patient.Gender != 0)
            {
                var patientBll = new PatientBLL();

                if(file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/PatientImages/"), filename);
                    file.SaveAs(imgpath);
                    patient.ImgPath = "~/Content/PatientImages/" + file.FileName;
                } else
                {
                    patient.ImgPath = "~/Content/PatientImages/default.jpg";
                }
                
                patientBll.Insert(patient);
                return RedirectToAction("Index");
            }
            var clientBll = new ClientBLL();
            ViewBag.ClientId = new SelectList(clientBll.List(), "Id", "FullName", patient.ClientId);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patientBll = new PatientBLL();
            Patient patient = patientBll.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            var clientBll = new ClientBLL();
            ViewBag.ClientId = new SelectList(clientBll.List(), "Id", "FullName", patient.ClientId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ClientId,Gender,ImagePath")] Patient patient, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var patientBll = new PatientBLL();
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/PatientImages/"), filename);
                    file.SaveAs(imgpath);
                    patient.ImgPath = "~/Content/PatientImages/" + file.FileName;
                }
                patientBll.Update(patient);
                return RedirectToAction("Index");
            }
            var clientBll = new ClientBLL();
            ViewBag.ClientId = new SelectList(clientBll.List(), "Id", "FullName", patient.ClientId);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var patientBll = new PatientBLL();
            Patient patient = patientBll.GetById(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var patientBll = new PatientBLL();
            patientBll.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
