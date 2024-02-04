using First.Domain.Tables.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Infrastructure.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {

        public void Configure(EntityTypeBuilder<Group> builder)
        {
        builder.HasMany(x => x.Students).WithMany(x => x.Groups).UsingEntity(nameof(StudentToGroup));
        builder.HasMany(x => x.Teachers).WithMany(x => x.Groups).UsingEntity(nameof(TeacherToGroup));
        builder.HasOne(x => x.Faculty).WithMany(x => x.Groups).HasForeignKey(x => x.FacultyId);

            
        }
    }
}
