namespace Poliklinka.Domain.Exceptions.Appointment;

public class AppointmentAlreadyExistsException : NotFoundException
{
    public AppointmentAlreadyExistsException()
    {
        TitleMessage = "Appointment already exist";
    }
}
