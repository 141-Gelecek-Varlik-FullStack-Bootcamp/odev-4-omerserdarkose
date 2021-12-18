using HelenSposa.Core.Entities.Dtos;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.Entities.Dtos.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface IExpenseService
    {
        IPaginationDataResult<List<ExpenseShowDto>> GetAll(string filter = null,PaginationDto paginationDto = null);

        IDataResult<ExpenseShowDto> GetById(int id);

        IResult Add(ExpenseAddDto addedExpense);

        IResult Delete(ExpenseDeleteDto deletedExpense);

        IResult Update(ExpenseUpdateDto updatedExpense);
    }
}
