using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess.Entities;

namespace TaskBoard.DataAccess.Configurations
{
    public class ObjectiveConfiguration : IEntityTypeConfiguration<ObjectiveEntity>
    {
        public void Configure(EntityTypeBuilder<ObjectiveEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(Objective.MAX_NAME_LENGTH)
                .IsRequired();
        }
    }
}
