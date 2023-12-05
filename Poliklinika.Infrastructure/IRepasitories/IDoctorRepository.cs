using Poliklinka.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Infrastructure.IRepasitories
{
    public interface IDoctorRepository:IRepository<DoctorEntity>
    {
        Task<DoctorEntity> GetByTelNumberAsync  (string telNumber);
    }
}
