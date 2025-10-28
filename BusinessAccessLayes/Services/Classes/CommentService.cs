using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using DataAccessLayer.Models.Contents.Comments;
using DataAccessLayer.Repositories.UnitOfWork;
using Shared.DataTransferObjects.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Classes
{
    public class CommentService(IUnitOfWork unitOfWork,IMapper mapper):ICommentService
    {
        public async Task DeleteComment(int id)
        {
            var repo = unitOfWork.GetRepository<Comment, int>();

            var comment = await repo.GetByIdAsync(id);
            if (comment is not null)
            {
                repo.Delete(comment);
                await unitOfWork.SaveChangesAsync();

            }

        }
        public async Task<IEnumerable<CommentDTO>> GetAllCommentAsync()
        {
            var repo = unitOfWork.GetRepository<Comment, int>();
            var all = await repo.GetAllAsync();
            var comments = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(all);
            return comments;

        }
        public async Task AddCommentAsync(CreateCommentDTO commentDTO)
        {
            var repo = unitOfWork.GetRepository<Comment, int>();
            var comment = mapper.Map<CreateCommentDTO, Comment>(commentDTO);
            await repo.AddAsync(comment);
            await unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateCommentAsync(UpdateCommentDTO updateCommentDTO)
        {
            var repo = unitOfWork.GetRepository<Comment, int>();
            var commentup = mapper.Map<UpdateCommentDTO, Comment>(updateCommentDTO);
            repo.Update(commentup);
            await unitOfWork.SaveChangesAsync();
        }
        public async Task<CommentDTO?> GetCommentByIdAsync(int id)
        {
            var repo = unitOfWork.GetRepository<Comment, int>();
            var comment = await repo.GetByIdAsync(id);
            if (comment == null) return null;
            return mapper.Map<CommentDTO>(comment);

        }


    }
}
