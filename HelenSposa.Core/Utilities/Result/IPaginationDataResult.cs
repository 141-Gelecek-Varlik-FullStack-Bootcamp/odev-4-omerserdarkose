using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Result
{
    public interface IPaginationDataResult<T>:IDataResult<T>
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        Uri FirstPage { get; set; }
        Uri LastPage { get; set; }
        int TotalPages { get; set; }
        int TotalRecords { get; set; }
        Uri NextPage { get; set; }
        Uri PreviousPage { get; set; }
    }
}
