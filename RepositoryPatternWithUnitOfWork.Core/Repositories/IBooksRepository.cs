using RepositoryPatternWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUnitOfWork.Core.Repositories
{
    //created for a special methods only used for Books in addition to shared methods 
    public interface IBooksRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}
