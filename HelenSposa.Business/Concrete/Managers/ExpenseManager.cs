using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Constant;
using HelenSposa.Business.Extensions;
using HelenSposa.Core.Entities.Dtos;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Concrete.Managers
{
    public class ExpenseManager : IExpenseService
    {
        private IExpenseDal _expenseDal;
        private IMapper _mapper;
        private IPaginationUriService _paginationUriManager;

        public ExpenseManager(IExpenseDal expenseDal, IMapper mapper, IPaginationUriService paginationUriManager)
        {
            _expenseDal = expenseDal;
            _mapper = mapper;
            _paginationUriManager = paginationUriManager;
        }

        public IResult Add(ExpenseAddDto addedExpense)
        {
            var mapExpense = _mapper.Map<Expense>(addedExpense);
            _expenseDal.Add(mapExpense);
            return new SuccessResult(Messages.ExpenseAdded);
        }

        public IResult Delete(ExpenseDeleteDto deletedExpense)
        {
            var mapExpense = _mapper.Map<Expense>(deletedExpense);
            _expenseDal.Delete(mapExpense);
            return new SuccessResult(Messages.ExpenseDeleted);
        }

        public IPaginationDataResult<List<ExpenseShowDto>> GetAll(PaginationDto paginationDto = null)
        {
            var pagination = new PaginationDto(paginationDto.PageNumber, paginationDto.PageSize);

            var count = _expenseDal.GetList().Count();
            var expenseList = _expenseDal.GetPagination(null,pagination);
            var mapExpenseList = _mapper.Map<List<ExpenseShowDto>>(expenseList);
 
            return PaginationExtensions.CreatePaginationResult(mapExpenseList, pagination, count, _paginationUriManager,true);


            
            /*return new SuccessDataResult<List<ExpenseShowDto>>(mapExpenseList);*/
        }

        public IDataResult<ExpenseShowDto> GetById(int id)
        {
            var expense = _expenseDal.Get(e => e.Id == id);
            var mapExpense = _mapper.Map<ExpenseShowDto>(expense);
            return new SuccessDataResult<ExpenseShowDto>(mapExpense);
        }


        public IResult Update(ExpenseUpdateDto updatedExpense)
        {
            var mapExpense = _mapper.Map<Expense>(updatedExpense);
            _expenseDal.Update(mapExpense);
            return new SuccessResult(Messages.ExpenseUpdated);
        }
    }
}
