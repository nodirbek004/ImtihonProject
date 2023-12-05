namespace Poliklinka.Domain.Exceptions.Appointment;

public class AppointmentNotFoundException:NotFoundException
{
    public AppointmentNotFoundException()
    {
        TitleMessage = "Appointment not found";
    }
}
