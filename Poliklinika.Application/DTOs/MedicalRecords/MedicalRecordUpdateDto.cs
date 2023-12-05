﻿using HospitalInformationSystem.Domain.Commons;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Application.DTOs.MedicalRecords;

public class MedicalRecordUpdateDto:Auditable
{
    public string MedicalConditions { get; set; }
    public string Medications { get; set; }
    public string TestResults { get; set; }
    public string TreatmentPlans { get; set; }
    public long PatientId { get; set; }

}
