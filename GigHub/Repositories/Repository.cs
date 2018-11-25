using GigHub.Models;

namespace GigHub.Repositories
{
    public abstract class Repository
    {
        protected readonly ApplicationDbContext _context;

        public Repository()
        {
            _context = new ApplicationDbContext();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}