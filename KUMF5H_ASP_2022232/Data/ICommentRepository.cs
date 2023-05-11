using KUMF5H_ASP_2022232.Models;

namespace KUMF5H_ASP_2022232.Data
{
    public interface ICommentRepository
    {

        void Create(Comment comment);
        void Delete(Comment comment);
        void Delete(string id);
        IEnumerable<Comment> GetAll();
        Comment GetOne(string id);
        List<Comment> GetCommentssForRequest(string id);
    }
}
