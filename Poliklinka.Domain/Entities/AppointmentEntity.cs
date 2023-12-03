using HospitalInformationSystem.Domain.Commons;
using Poliklinka.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poliklinka.Domain.Entities;
[Table("Appintment")]
public class AppointmentEntity:Auditable
{
    public PatientEntity Patient { get; set; }
    public long DoctorId { get; set; }
    public DoctorEntity Doctor { get; set; }
    public Specialty SpecifyingDate { get; set; }
}
