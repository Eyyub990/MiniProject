﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.Configurations
{
    public class SkillGroupEntityTypeConfiguration : IEntityTypeConfiguration<SkillGroup>
    {
        public void Configure(EntityTypeBuilder<SkillGroup> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.TypeId).HasColumnType("int");
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.CreatedBy).HasColumnType("int").IsRequired();
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int").IsRequired(false);
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int").IsRequired(false);

            builder.HasKey(m => m.Id);
            builder.ToTable("SkillGroups");


            builder.HasOne<SkillType>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.TypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
