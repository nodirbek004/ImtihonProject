﻿using Poliklinka.Domain.Entities;

namespace Poliklinika.Infrastructure.IRepasitories;

public interface IAppointmentRepository:IRepository<AppointmentEntity>
{
    IQueryable<AppointmentEntity> GetBySpecifyingDate(DateTime date);
}
