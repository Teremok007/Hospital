CREATE DATABASE [Hospital]
GO

USE [Hospital]
GO

--------------------------------------------------------------
------ CREATE Spetiallilzation table    ----------------------
--------------------------------------------------------------
CREATE TABLE [Specializations](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL UNIQUE,
	[Description] [nvarchar](250) NULL,
)
GO
--------------------------------------------------------------
------ CREATE [Doctors] table        -------------------------
--------------------------------------------------------------
CREATE TABLE [Doctors](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SpecializationId] [int] NOT NULL 
 )
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Doctors_dbo.Specializations_SpecializationId] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specializations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_dbo.Doctors_dbo.Specializations_SpecializationId]
GO
--------------------------------------------------------------
------ CREATE Patient table         --------------------------
--------------------------------------------------------------
CREATE TABLE [Patients](
	[Id] [int] PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[DayOfBirth] [datetime] NOT NULL,
	[TaxCode] [nvarchar](max) NOT NULL
)
GO

--------------------------------------------------------------
------ CREATE PatientDoctors table --------------------------
--------------------------------------------------------------
CREATE TABLE [PatientDoctors](
	[Patient_Id] [int] NOT NULL,
	[Doctor_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PatientDoctors] PRIMARY KEY CLUSTERED 
(
	[Patient_Id] ASC,
	[Doctor_Id] ASC
)
)
GO

ALTER TABLE [dbo].[PatientDoctors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PatientDoctors_dbo.Doctors_Doctor_Id] FOREIGN KEY([Doctor_Id])
REFERENCES [dbo].[Doctors] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[PatientDoctors] CHECK CONSTRAINT [FK_dbo.PatientDoctors_dbo.Doctors_Doctor_Id]
GO

ALTER TABLE [dbo].[PatientDoctors]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PatientDoctors_dbo.Patients_Patient_Id] FOREIGN KEY([Patient_Id])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[PatientDoctors] CHECK CONSTRAINT [FK_dbo.PatientDoctors_dbo.Patients_Patient_Id]
GO

--------------------------------------------------------------
INSERT INTO Specializations([Name], [Description])
VALUES('Allergist', 'conducts the diagnosis and treatment of allergic conditions'),
('Anesthesiologist', 'treats chronic pain syndromes; administers anesthesia and monitors the patient during surgery'),
('Cardiologist', 'treats heart disease'),
('Dermatologist', 'treats skin diseases, including some skin cancers'),
('Gastroenterologist', 'treats stomach disorders'),
('Hematologist / Oncologist', 'treats diseases of the blood and blood-forming tissues(oncology including cancer and other tumors)'),
('Internal Medicine Physician', 'treats diseases and disorders of internal structures of the body'),
('Nephrologist', 'treats kidney diseases'),
('Neurologist', 'treats diseases and disorders of the nervous system'),
( 'Neurosurgeon', 'conducts surgery of the nervous system'),
('Obstetrician', 'treats women during pregnancy and childbirth'),
('Gynecologist', 'treats diseases of the female reproductive system and genital tract'),
('Nurse-Midwifery', 'manages a woman''s health care, especially during pregnancy, delivery, and the postpartum period'),
('Occupational Medicine Physician', 'diagnoses and treats work-related disease or injury'),
('Ophthalmologist', 'treats eye defects, injuries, and diseases'),
('Oral and Maxillofacial Surgeon', 'surgically treats diseases, injuries, and defects of the hard and soft tissues of the face, mouth, and jaws'),
('Orthopaedic Surgeon', 'preserves and restores the function of the musculoskeletal system'),
('Otolaryngologist (Head and Neck Surgeon)', 'treats diseases of the ear, nose, and throat, and some diseases of the head and neck, including facial plastic surgery'),
('Pathologist', 'diagnoses and treats the study of the changes in body tissues and organs which cause or are caused by disease'),
('Pediatrician', 'treats infants, toddlers, children and teenagers'),
('Plastic Surgeon', 'restores, reconstructs, corrects or improves in the shape and appearance of damaged body structures, especially the face'),
('Podiatrist', 'provides medical and surgical treatment of the foot'),
('Psychiatrist', 'treats patients with mental and emotional disorders'),
('Pulmonary Medicine Physician', 'diagnoses and treats lung disorders'),
('Radiation Onconlogist', 'diagnoses and treats disorders with the use of diagnostic imaging, including X-rays, sound waves, radioactive substances, and magnetic fields'),
('Diagnostic Radiologist', 'diagnoses and medically treats diseases and disorders of internal structures of the body'),
('Rheumatologist', 'treats rheumatic diseases, or conditions characterized by inflammation, soreness and stiffness of muscles, and pain in joints and associated structures'),
('Urologist', 'diagnoses and treats the male and female urinary tract and the male reproductive system')
--------------------------------------------------------------
INSERT INTO Doctors([Name], SpecializationId)
VALUES('Alex', 12),
('BlackDoc', 11),
('WhiteDoc', 21),
('ManDoc', 28);

--------------------------------------------------------------
select * From Patients
INSERT INTO Patients([Name], [Status], [DayOfBirth], [TaxCode])
VALUES('Dushka', 2, '1978-01-11', 9874563844),
('Tom', 1, '2008-05-15', 9874563234),
('Aram', 1, '1995-06-04', 9832434245),
('Bob', 2, '2015-03-01', 9892343234)
