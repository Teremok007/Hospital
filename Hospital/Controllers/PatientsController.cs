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
                DoctorSelectList = new MultiSelectList(doctors, "DoctorId", "DoctorName")
            };
            return View(patientEditViewModel);
        }

        [HttpPost]
        public ActionResult Create(PatientEditViewModel creatingPatient) //[Bind(Include = "Id,Name,DayOfBirth,Status,TaxCode, ")]
        {
            List<Doctor> docs = new List<Doctor>();
            if (creatingPatient.SelectedDoctorsId != null)
            {
                docs.AddRange(repo.GetDoctorsById(creatingPatient.SelectedDoctorsId.ToArray<int>()));
            }
            if (ModelState.IsValid)
            {
                Patient newPatient = new Patient
                {
                    Doctors = docs,
                    DayOfBirth = creatingPatient.DayOfBirth,
                    Name = creatingPatient.Name,
                    Status = creatingPatient.Status,
                    TaxCode = creatingPatient.TaxCode
                };
                repo.Add(newPatient);
                return RedirectToAction("Index");
            }            
            creatingPatient.DoctorSelectList = GetDoctorsSelectList(creatingPatient.SelectedDoctorsId.ToArray<int>());
            return View(creatingPatient);
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = repo.GetPatient(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Patient patient = repo.GetPatient(id);
            if (patient == null)
            {
                return new HttpNotFoundResult("Client not found.");
            }
            PatientEditViewModel patientEditViewModel = new PatientEditViewModel()
            {
                Patient = patient,
                DoctorSelectList = GetDoctorsSelectList(patient.Doctors.Select(d => d.Id).ToArray<int>())
            };
            return View(patientEditViewModel);
        }

        private MultiSelectList GetDoctorsSelectList(int[] selectedItems)
        {
            var doctors = repo.GetDoctors(null)
                .OrderBy(d => d.Name)
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name + " (" + d.Specialization.Name + ")"
                }).ToList();            
            return new MultiSelectList(doctors, "Value", "Text", selectedItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientEditViewModel editedPatiend)
        {
            Patient editingPatient = repo.GetPatient(editedPatiend.Id);
            if (editingPatient == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                editingPatient.Name = editedPatiend.Name;
                editingPatient.TaxCode = editedPatiend.TaxCode;
                editingPatient.Status = editedPatiend.Status;
                editingPatient.DayOfBirth = editedPatiend.DayOfBirth;
                editingPatient.Doctors.Clear();
                editingPatient.Doctors.AddRange(repo.GetDoctorsById(editedPatiend.SelectedDoctorsId.ToArray()));
                repo.Edit(editingPatient);
                return RedirectToAction("Index");
            }
            editedPatiend.DoctorSelectList = GetDoctorsSelectList(editingPatient.Doctors.Select(d => d.Id).ToArray<int>());
            return View(editedPatiend);
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