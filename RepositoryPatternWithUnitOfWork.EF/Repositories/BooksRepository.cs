using RepositoryPatternWithUnitOfWork.Core.Models;
using RepositoryPatternWithUnitOfWork.Core.Repositories;

namespace RepositoryPatternWithUnitOfWork.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Book> SpecialMethod()
        {
            return _context.Books.ToList();
        }
    }
}