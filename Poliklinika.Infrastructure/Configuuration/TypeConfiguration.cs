using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliklinka.Domain.Entities;

namespace Poliklinika.Infrastructure.Configuuration;

public class TypeConfiguration:IEntityTypeConfiguration<PatientEntity>
{
    public void  Configure(EntityTypeBuilder<PatientEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName)
        .IsRequired();
    }
}
