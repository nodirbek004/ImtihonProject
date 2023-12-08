

using Payment.Domain.Commons;

namespace Payment.Domain.Enitities;

public class User:AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    public string Seria { get; set; }
}
