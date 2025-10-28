using Shared.DataTransferObjects.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface  ICommentService
    {
        Task AddCommentAsync(CreateCommentDTO commentDTO);
        Task UpdateCommentAsync(UpdateCommentDTO updateCommentDTO);
        public Task DeleteComment(int id);
        Task<CommentDTO?> GetCommentByIdAsync(int id);
        Task<IEnumerable<CommentDTO>> GetAllCommentAsync();


    }
}
