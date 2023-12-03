using HospitalInformationSystem.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poliklinka.Domain.Entities;
[Table("MedicalRecord")]
public class MedicalRecord:Auditable
{
    public string MedicalConditions { get; set; }
    public string Medications { get; set; }
    public string TestResults { get; set; }
    public string TreatmentPlans { get; set; }
    public long PatientId { get; set; }
    public PatientEntity Patient { get; set; }
}
