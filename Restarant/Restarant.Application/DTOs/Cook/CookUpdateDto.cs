﻿using Restarant.Domain.Commons;
using Restarant.Domain.Enums;

namespace Restarant.Application.DTOs.Cook;

public class CookUpdateDto:AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Position Position { get; set; }
    public float Salary { get; set; }
}
