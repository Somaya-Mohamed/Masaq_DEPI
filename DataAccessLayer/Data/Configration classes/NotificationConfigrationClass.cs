

using DataAccessLayer.Models.Notifications;
using DataAccessLayer.Models.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Data.Configration_classes
{
    public class NotificationConfigrationClass: BaseOfAllEntityConfigrationClass<Notification,int>, IEntityTypeConfiguration<Notification>

    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(a => a.Header).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(a => a.Body).HasColumnType("nvarchar(600)").IsRequired();

            base.Configure(builder);

        }
    }
}
