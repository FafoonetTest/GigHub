using GigHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class GenreRepository : Repository
    {
        
        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }
    }
}