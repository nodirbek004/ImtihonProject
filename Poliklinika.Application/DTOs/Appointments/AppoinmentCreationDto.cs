using Poliklinka.Domain.Entities;
using Poliklinka.Domain.Enums;

namespace Poliklinika.Application.DTOs.Appointments;

public class AppoinmentCreationDto
{
    
    public long DoctorId { get; set; }
  
    public Specialty SpecifyingDate { get; set; }
}
