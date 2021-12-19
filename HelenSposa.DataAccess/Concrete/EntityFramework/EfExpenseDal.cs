using HelenSposa.Core.DataAccess.EntityFramework;
using HelenSposa.Core.Entities.Dtos;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Expense;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.DataAccess.Concrete.EntityFramework
{
    public class EfExpenseDal : EfEntityRepositoryBase<Expense, HelenSposaDbContext>, IExpenseDal
    {
        public override List<Expense> GetList(Expression<Func<Expense, bool>> filter = null)
        {
            using (var context = new HelenSposaDbContext())
            {
                return filter == null ? context.Set<Expense>().Include(et => et.Type).ToList() : context.Set<Expense>().Include(et => et.Type).Where(filter).ToList();
            }
        }

        public override Expense Get(Expression<Func<Expense, bool>> filter)
        {
            using (var context = new HelenSposaDbContext())
            {
                return context.Set<Expense>().Include(et => et.Type).SingleOrDefault(filter);
            }
        }

        public List<Expense> GetPagination(Expression<Func<Expense, bool>> filter = null, PaginationDto paginationDto = null)
        {
            using (var context = new HelenSposaDbContext())
            {
                var skip= (paginationDto.PageNumber - 1) * paginationDto.PageSize;

                return filter == null ? context.Set<Expense>().Include(et => et.Type).Skip(skip).Take(paginationDto.PageSize).ToList() 
                                      : context.Set<Expense>().Include(et => et.Type).Where(filter).Skip(skip).Take(paginationDto.PageSize).ToList();
            }
        }

    }
}
