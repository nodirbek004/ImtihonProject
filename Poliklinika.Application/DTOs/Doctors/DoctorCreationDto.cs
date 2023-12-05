using Poliklinka.Domain.Enums;

namespace Poliklinika.Application.DTOs.Doctors;

public class DoctorCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    public Specialty Specialization { get; set; }
}
