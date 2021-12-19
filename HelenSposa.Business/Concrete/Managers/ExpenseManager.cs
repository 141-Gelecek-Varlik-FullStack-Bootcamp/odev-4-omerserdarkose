using AutoMapper;
using HelenSposa.Business.Abstract;
using HelenSposa.Business.Constant;
using HelenSposa.Business.Extensions;
using HelenSposa.Core.Entities;
using HelenSposa.Core.Entities.Dtos;
using HelenSposa.Core.Utilities.Result;
using HelenSposa.DataAccess.Abstract;
using HelenSposa.Entities.Concrete;
using HelenSposa.Entities.Dtos.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Concrete.Managers
{
    public class ExpenseManager : IExpenseService
    {
        private IExpenseDal _expenseDal;
        private IMapper _mapper;
        private IPaginationUriService _paginationUriManager;
        private IPaginationDto _paginationDto;

        public ExpenseManager(IExpenseDal expenseDal, IMapper mapper, IPaginationUriService paginationUriManager, IPaginationDto paginationDto)
        {
            _expenseDal = expenseDal;
            _mapper = mapper;
            _paginationUriManager = paginationUriManager;
            _paginationDto = paginationDto;
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

        public IPaginationDataResult<List<ExpenseShowDto>> GetAll(string filter = null,PaginationDto paginationDto = null)
        {
            var _paginationDto = paginationDto;

            //sartlara uyan toplam data sayisi bulunuyor, bu isem icin ayri bir sorgu yapmamam gerekiyor refactor edilecek
            var count = _expenseDal.GetList(filter!=null? x => x.Type.Name == filter:null).Count();

            //sayfa ve filtre kriterlerine gore dbden data cekiliyor
            var expenseList = _expenseDal.GetPagination(filter != null ? x => x.Type.Name == filter : null, _paginationDto);

            //cekilen data gosterim icin map ediliyor
            var mapExpenseList = _mapper.Map<List<ExpenseShowDto>>(expenseList);
 
            //sayfalama bilgilerini de iceren sonuc turu olusturulup apiye gonderiliyor
            return PaginationExtensions.CreatePaginationResult(mapExpenseList, _paginationDto, count, _paginationUriManager,true);

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
