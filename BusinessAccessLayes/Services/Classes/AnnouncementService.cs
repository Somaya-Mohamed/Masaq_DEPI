using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using DataAccessLayer.Models.Announcements;
using DataAccessLayer.Repositories.UnitOfWork;
using Shared.DataTransferObjects.Announcements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Classes
{
    public class AnnouncementService(IUnitOfWork unitOfWork, IMapper mapper) : IAnncouncementService
    {
        public async Task DeleteAnnouncement(int id)
        {
            var repo = unitOfWork.GetRepository<Announcement, int>();

            var anno = await repo.GetByIdAsync(id);
            if (anno is not null)
            {
                repo.Delete(anno);
                await unitOfWork.SaveChangesAsync();
            }

        }
        public async Task<IEnumerable<AnnouncementDTO>> GetAllAnnouncementAsync()
        {
            var repo = unitOfWork.GetRepository<Announcement, int>();

            var announcemntDto = await repo.GetAllAsync();

            return mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementDTO>>(announcemntDto);
        }

        //public async Task AddAnnouncementAsync(AnnouncementDTO announcementDTO)
        //{
        //    var repo = unitOfWork.GetRepository<Announcement, int>();
        //    var announcement = mapper.Map<AnnouncementDTO, Announcement>(announcementDTO);
        //    await repo.AddAsync(announcement);
        //    await unitOfWork.SaveChangesAsync();

        //}
        public async Task AddAnnouncementAsync(AnnouncementDTO announcementDTO)
        {
            var repo = unitOfWork.GetRepository<Announcement, int>();

            // 1. Map from DTO to entity
            var announcement = mapper.Map<AnnouncementDTO, Announcement>(announcementDTO);

            // 2. --- THIS IS THE FIX ---
            //    We don't want EF to track a new Lesson object, just the foreign key.
            announcement.lesson = null;

            // 3. Make sure the Foreign Key ID is set (AutoMapper ReverseMap should do this)
            announcement.LessonIdFK = announcementDTO.LessonId;

            // 4. Add the announcement
            await repo.AddAsync(announcement); // This is your line 41
            await unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateAnnouncementAsync(AnnouncementDTO announcementDTO)
        {
            var repo = unitOfWork.GetRepository<Announcement, int>();
            var announcement = mapper.Map<AnnouncementDTO, Announcement>(announcementDTO);
            repo.Update(announcement);
            await unitOfWork.SaveChangesAsync();
        }
        public async Task<AnnouncementDTO?> GetAnnouncementByIdAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Announcement, int>();
            var announcement = await repo.GetByIdAsync(id);

            if (announcement is not null)
                return mapper.Map<AnnouncementDTO>(announcement);

            return null;
        }

    }
}
