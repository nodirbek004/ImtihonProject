using HospitalInformationSystem.Domain.Commons;
using Poliklinka.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Poliklinka.Domain.Entities;
[Table("Patient")]
public class PatientEntity:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string TelNumber { get; set; }
    public Gender gender { get; set; }
}
