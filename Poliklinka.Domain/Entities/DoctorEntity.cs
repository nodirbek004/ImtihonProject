using HospitalInformationSystem.Domain.Commons;
using Poliklinka.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poliklinka.Domain.Entities;
[Table("Doctor")]
public class DoctorEntity:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    public Specialty Specialization { get; set; }
}
