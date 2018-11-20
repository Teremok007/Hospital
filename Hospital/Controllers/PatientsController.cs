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
            var doctors = repo.GetDoctors(null).
                            Select(d => new {
                                DoctorId = d.Id,
                                DoctorName = d.Specialization.Name + " - " + d.Name}).
                            ToList();
            PatientEditViewModel patientEditViewModel = new PatientEditViewModel()
            {
                Doctors = new MultiSelectList(doctors, "DoctorId", "DoctorName")
            };
            return View(patientEditViewModel);
        }

        [HttpPost]
        public ActionResult Create(PatientEditViewModel patient) //[Bind(Include = "Id,Name,DayOfBirth,Status,TaxCode, ")]
        {
            if (ModelState.IsValid)
            {
                patient.Patient.Doctors = repo.GetDoctorsById(patient.DoctorsId.ToArray());
                repo.Add(patient.Patient);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Patient patient = repo.GetPatient(id);
            if (patient == null)
            {
                return new HttpNotFoundResult("Client not found.");
            }

            var doctors = repo.GetDoctors(null)
                .OrderBy(d => d.Name)
                .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name + " (" + d.Specialization.Name + ")" ,
                        Selected = patient.Doctors.Any(doc => doc.Id == d.Id)
                    }).ToList();

            var selectedItems = patient.Doctors.Select(d => d.Id).ToArray<int>();
            PatientEditViewModel patientEditViewModel = new PatientEditViewModel()
            {
                Patient = patient,
                Doctors = new MultiSelectList(doctors, "Value", "Text", selectedItems)
            };
            return View(patientEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Patient.Doctors = repo.GetDoctorsById(model.DoctorsId.ToArray());
                repo.Edit(model.Patient);
                return RedirectToAction("Index");
            }
            return View();
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