using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;
using Hospital.Repositories;


namespace Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        //private HospitalContext db = new HospitalContext();
        private IDoctorRepository repo; 

        public DoctorsController(IDoctorRepository repo)
        {
            this.repo = repo;
        }
        // GET: Doctors
        public ActionResult Index(string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return View(repo.GetDoctors());
            }
            return View(repo.GetDoctors().Where(d => d.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) != -1));
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = repo.GetDoctor(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            
            return View(new DoctorEditViewModel() { Specializations = repo.GetSpecializations() });
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SpecializationId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                repo.Add(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = repo.GetDoctor(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            var patients = doctor.Patients.Select(p => new { PatientId = p.Id, PatientName = p.Name }).ToList();

            return View(new DoctorEditViewModel()
            {
                Specializations = repo.GetSpecializations(),
                Doctor = doctor,
                Patients = new MultiSelectList(
                    patients,
                    "PatientId",
                    "PatientName")
            });
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Specialization")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = repo.GetDoctor(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
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
