using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hospital.DAL
{
    public class DBInitializer : CreateDatabaseIfNotExists<HospitalContext>
    {
        protected override void Seed(HospitalContext context)
        {
            base.Seed(context);
            SeedSpecialization(context);
            SeedDoctor(context);
            SeedPatient(context);
        }


        protected void SeedDoctor(HospitalContext context)
        {
            context.Doctors.Add(new Doctor
            {
                Name = "Alex",
                SpecializationId = context.Specializations.Single(s => String.Compare(s.Name,"Allergist",true) == 0).Id
            });
            context.Doctors.Add(new Doctor
            {
                Name = "BlackDoc",
                SpecializationId = context.Specializations.Single(s => String.Compare(s.Name, "Gynecologist", true) == 0).Id
            });
            context.Doctors.Add(new Doctor
            {
                Name = "WhiteDoc",
                SpecializationId = context.Specializations.Single(s => String.Compare(s.Name, "Plastic Surgeon", true) == 0).Id
            });
            context.Doctors.Add(new Doctor
            {
                Name = "ManDoc",
                SpecializationId = context.Specializations.Single(s => String.Compare(s.Name, "Urologist", true) == 0).Id
            });

            context.SaveChanges();
        }


        protected void SeedPatient(HospitalContext context)
        {
            Patient patient = new Patient
            {
                Name = "Dushka",
                Status = PatientStatus.Sick,
                DayOfBirth = new DateTime(2018, 01, 01),
                TaxCode = "982564477",
                Doctors = new List<Doctor>()
            };
            patient.Doctors.Add(context.Doctors.Single(d => String.Compare(d.Name, "BlackDoc", true) == 0));
            patient.Doctors.Add(context.Doctors.Single(d => String.Compare(d.Name, "WhiteDoc", true) == 0));
            context.Patients.Add(patient);

            patient = new Patient
            {
                Name = "Tom",
                Status = PatientStatus.Sick,
                DayOfBirth = new DateTime(2018, 01, 01),
                TaxCode = "982564477",
                Doctors = new List<Doctor>()
            };
            patient.Doctors.Add(context.Doctors.First<Doctor>(d => d.Name == "Alex"));
            patient.Doctors.Add(context.Doctors.First<Doctor>(d => d.Name == "ManDoc"));
            context.Patients.Add(patient);

            patient = new Patient
            {
                Name = "Aram",
                Status = PatientStatus.Sick,
                DayOfBirth = new DateTime(2018, 01, 01),
                TaxCode = "982564477",
                Doctors = new List<Doctor>()
            };
            patient.Doctors.Add(context.Doctors.First<Doctor>(d => d.Name == "ManDoc"));
            patient.Doctors.Add(context.Doctors.First<Doctor>(d => d.Name == "BlackDoc"));
            context.Patients.Add(patient);
            context.SaveChanges();
        }
        
        protected void SeedSpecialization(HospitalContext context)
        {
            context.Specializations.Add(new Specialization { Name = "Allergist", Description = "conducts the diagnosis and treatment of allergic conditions" });
            context.Specializations.Add(new Specialization { Name = "Anesthesiologist", Description = "treats chronic pain syndromes; administers anesthesia and monitors the patient during surgery" });
            context.Specializations.Add(new Specialization { Name = "Cardiologist", Description = "treats heart disease" });
            context.Specializations.Add(new Specialization { Name = "Dermatologist", Description = "treats skin diseases, including some skin cancers" });
            context.Specializations.Add(new Specialization { Name = "Gastroenterologist", Description = "treats stomach disorders" });
            context.Specializations.Add(new Specialization { Name = "Hematologist / Oncologist", Description = "treats diseases of the blood and blood-forming tissues(oncology including cancer and other tumors)" });
            context.Specializations.Add(new Specialization { Name = "Internal Medicine Physician", Description = "treats diseases and disorders of internal structures of the body" });
            context.Specializations.Add(new Specialization { Name = "Nephrologist", Description = "treats kidney diseases" });
            context.Specializations.Add(new Specialization { Name = "Neurologist", Description = "treats diseases and disorders of the nervous system" });
            context.Specializations.Add(new Specialization { Name = "Neurosurgeon", Description = "conducts surgery of the nervous system" });
            context.Specializations.Add(new Specialization { Name = "Obstetrician", Description = "treats women during pregnancy and childbirth" });
            context.Specializations.Add(new Specialization { Name = "Gynecologist", Description = "treats diseases of the female reproductive system and genital tract" });
            context.Specializations.Add(new Specialization { Name = "Nurse-Midwifery", Description = "manages a woman''s health care, especially during pregnancy, delivery, and the postpartum period" });
            context.Specializations.Add(new Specialization { Name = "Occupational Medicine Physician", Description = "diagnoses and treats work-related disease or injury" });
            context.Specializations.Add(new Specialization { Name = "Ophthalmologist", Description = "treats eye defects, injuries, and diseases" });
            context.Specializations.Add(new Specialization { Name = "Oral and Maxillofacial Surgeon", Description = "surgically treats diseases, injuries, and defects of the hard and soft tissues of the face, mouth, and jaws" });
            context.Specializations.Add(new Specialization { Name = "Orthopaedic Surgeon", Description = "preserves and restores the function of the musculoskeletal system" });
            context.Specializations.Add(new Specialization { Name = "Otolaryngologist (Head and Neck Surgeon)", Description = "treats diseases of the ear, nose, and throat, and some diseases of the head and neck, including facial plastic surgery" });
            context.Specializations.Add(new Specialization { Name = "Pathologist", Description = "diagnoses and treats the study of the changes in body tissues and organs which cause or are caused by disease" });
            context.Specializations.Add(new Specialization { Name = "Pediatrician", Description = "treats infants, toddlers, children and teenagers" });
            context.Specializations.Add(new Specialization { Name = "Plastic Surgeon", Description = "restores, reconstructs, corrects or improves in the shape and appearance of damaged body structures, especially the face" });
            context.Specializations.Add(new Specialization { Name = "Podiatrist", Description = "provides medical and surgical treatment of the foot" });
            context.Specializations.Add(new Specialization { Name = "Psychiatrist", Description = "treats patients with mental and emotional disorders" });
            context.Specializations.Add(new Specialization { Name = "Pulmonary Medicine Physician", Description = "diagnoses and treats lung disorders" });
            context.Specializations.Add(new Specialization { Name = "Radiation Onconlogist", Description = "diagnoses and treats disorders with the use of diagnostic imaging, including X-rays, sound waves, radioactive substances, and magnetic fields" });
            context.Specializations.Add(new Specialization { Name = "Diagnostic Radiologist", Description = "diagnoses and medically treats diseases and disorders of internal structures of the body" });
            context.Specializations.Add(new Specialization { Name = "Rheumatologist", Description = "treats rheumatic diseases, or conditions characterized by inflammation, soreness and stiffness of muscles, and pain in joints and associated structures" });
            context.Specializations.Add(new Specialization { Name = "Urologist", Description = "diagnoses and treats the male and female urinary tract and the male reproductive system" });
            context.SaveChanges();
        }
    }
}