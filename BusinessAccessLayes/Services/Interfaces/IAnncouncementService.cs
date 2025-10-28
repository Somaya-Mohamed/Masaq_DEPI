using Shared.DataTransferObjects.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface IAnncouncementService
    {
        Task AddAnnouncementAsync(AnnouncementDTO announcementDTO);
        Task UpdateAnnouncementAsync(AnnouncementDTO announcementDTO);
        public Task DeleteAnnouncement(int id);
        Task<AnnouncementDTO?> GetAnnouncementByIdAsync(int id);
        Task<IEnumerable<AnnouncementDTO>> GetAllAnnouncementAsync();

    }
}
