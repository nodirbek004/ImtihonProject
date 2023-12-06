using Restarant.Domain.Commons;
using System.Globalization;

namespace Restarant.Domain.Entities;

public class Cook:AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public float Salary { get; set; }

}
