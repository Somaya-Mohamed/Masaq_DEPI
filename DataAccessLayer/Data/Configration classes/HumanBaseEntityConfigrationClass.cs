using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configration_classes
{
        internal class HumanBaseEntityConfigrationClass<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : HumanBaseEntity
        {
    
            public void Configure(EntityTypeBuilder<TEntity> builder)
            {
                builder.Property(T => T.Id).UseIdentityColumn(1, 1);
                builder.Property(t => t.FName).HasColumnType("nvarchar(20)").IsRequired();
                builder.Property(t => t.LName).HasColumnType("nvarchar(20)").IsRequired();
                builder.Property(t => t.Address).HasColumnType("nvarchar(50)").IsRequired();
                builder.Property(t => t.email).HasColumnType("nvarchar(50)").IsRequired();
                builder.Property(t=>t.LastActive).HasComputedColumnSql("GETDATE()");
                builder.Property(t => t.Gender)
                .HasConversion((gender) => gender.ToString(),
                (togender) => (Gender)Enum.Parse(typeof(Gender), togender))
                .HasMaxLength(10).IsRequired();
                builder.Property(t => t.City).HasMaxLength(20)
                .IsRequired(false);
            }
        }
}
