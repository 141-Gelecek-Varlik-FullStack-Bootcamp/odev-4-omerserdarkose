using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Result
{
    public class PaginationDataResult<T> : DataResult<T>, IPaginationDataResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize {get; set; }
        public Uri FirstPage {get; set; }
        public Uri LastPage {get; set; }
        public int TotalPages {get; set; }
        public int TotalRecords {get; set; }
        public Uri NextPage {get; set; }
        public Uri PreviousPage {get; set; }

        public PaginationDataResult(T data,int pageNumber, int pageSize, bool success, string message) :base(data,success,message)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

        }

        public PaginationDataResult(T data, int pageNumber, int pageSize, bool success) : base(data, success)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

        }
    }
}
