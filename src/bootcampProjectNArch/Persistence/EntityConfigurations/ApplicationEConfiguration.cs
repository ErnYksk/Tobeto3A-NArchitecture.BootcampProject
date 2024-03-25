using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ApplicationEConfiguration : IEntityTypeConfiguration<ApplicationE>
{
    public void Configure(EntityTypeBuilder<ApplicationE> builder)
    {
        builder.ToTable("ApplicationEs").HasKey(ae => ae.Id);

        builder.Property(ae => ae.Id).HasColumnName("Id").IsRequired();
        builder.Property(ae => ae.ApplicantId).HasColumnName("ApplicantId");
        builder.Property(ae => ae.BootcampId).HasColumnName("BootcampId");
        builder.Property(ae => ae.ApplicationStateId).HasColumnName("ApplicationStateId");
        builder.Property(ae => ae.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ae => ae.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ae => ae.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(a => a.Bootcamp);
        builder.HasOne(a => a.Applicant);
        builder.HasOne(a => a.ApplicationState);
        builder.HasQueryFilter(ae => !ae.DeletedDate.HasValue);
    }
}
