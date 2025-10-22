using DataAccessLayer.Models.Contents.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configration_classes
{
    internal class CommentConfigrationClass :BaseOfAllEntityConfigrationClass<Comment,int> ,IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Body).HasColumnType("nvarchar(300)").IsRequired();
            base.Configure(builder);

        }
    }
}
