﻿using Restarant.Domain.Commons;
using Restarant.Domain.Enums;
using System.Globalization;

namespace Restarant.Domain.Entities;

public class Cook:AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Position Position { get; set; }
    public float Salary { get; set; }

}
