using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class PatientsController : Controller
    {
        private IPatientRepository repo;

        public PatientsController(IPatientRepository repo)
        {
            this.repo = repo;
        }
        
        public ActionResult Index(string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return View(repo.GetPatients());
            }
            return View(repo.GetPatients().Where(d => d.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) != -1));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,DayOfBirth,Status,TaxCode")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                repo.Add(patient);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Patient patient = repo.GetPatient(id);
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id, Name, Status, Birthday, TaxCode")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = repo.GetPatient(id);
            if (patient == null)
            {
                return new HttpNotFoundResult("Client not found.");
            }            
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}