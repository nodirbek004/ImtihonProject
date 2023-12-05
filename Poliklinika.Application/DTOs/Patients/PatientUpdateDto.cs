using HospitalInformationSystem.Domain.Commons;
using Poliklinka.Domain.Enums;

namespace Poliklinika.Application.DTOs.Patients;

public class PatientUpdateDto:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string TelNumber { get; set; }
    public Gender gender { get; set; }
}
