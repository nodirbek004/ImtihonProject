using Payment.Domain.Commons;

namespace Payment.Domain.Enitities;

public class Card:AudiTable
{
    public string? Name { get; set; }
    public string Number { get; set; }
    public string Date { get; set; }
    public int Password { get; set; }
    public User? User { get; set; }

}
