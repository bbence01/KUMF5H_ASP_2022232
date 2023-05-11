using KUMF5H_ASP_2022232.Models;

namespace KUMF5H_ASP_2022232.Data
{
    public class CommentRepository : ICommentRepository
    {
        ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Comment c)
        {
            context.Comments.Add(c);
            context.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return context.Comments;
        }

        public Comment GetOne(string id)
        {
            return context.Comments.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Comment c)
        {
            this.context.Comments.Remove(c);
            this.context.SaveChanges();
        }

        public void Delete(string id)

        {
            var word = context.Comments.Find(id);
            if (word != null)
            {
                context.Comments.Remove(word);
                context.SaveChanges();
            }
        }

        public List<Comment> GetCommentssForRequest(string id)
        {
            return context.Comments.Where(p => p.RequestId == id).ToList();
        }

    }
}
