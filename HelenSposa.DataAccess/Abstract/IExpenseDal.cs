using HelenSposa.Core.DataAccess;
using HelenSposa.Core.Entities.Dtos;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.DataAccess.Abstract
{
    public interface IExpenseDal:IEntityRepository<Expense>
    {
        public List<Expense> GetPagination(Expression<Func<Expense, bool>> filter = null, PaginationDto paginationDto = null);
    }
}
