using Payment.Domain.Commons;
using Payment.Domain.Enums;

namespace Payment.Domain.Enitities;

public class Card:AudiTable
{
    public CardName CardName { get; set; }
    public string Number { get; set; }
    public string Date { get; set; }
    public int Password { get; set; }
    public User? User { get; set; }

}
