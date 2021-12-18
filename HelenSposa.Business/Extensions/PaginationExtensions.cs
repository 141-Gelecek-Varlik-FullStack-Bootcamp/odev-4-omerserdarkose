using HelenSposa.Business.Abstract;
using HelenSposa.Core.Entities.Dtos;
using HelenSposa.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Extensions
{
    public static class PaginationExtensions
    {
        public static PaginationDataResult<T> CreatePaginationResult<T>(T pagedData, PaginationDto paginationDto, int totalRecords, IPaginationUriService uriService, bool success)
        {
            var result = new PaginationDataResult<T>(pagedData,paginationDto.PageNumber, paginationDto.PageSize,success);
            var totalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / (double)paginationDto.PageSize));
            result.NextPage = paginationDto.PageNumber >= 1 && paginationDto.PageNumber < totalPages
                ? uriService.GetPageUri(new PaginationDto(paginationDto.PageNumber + 1, paginationDto.PageSize))
                : null;
            result.PreviousPage = paginationDto.PageNumber - 1 >= 1 && paginationDto.PageNumber <= totalPages
                ? uriService.GetPageUri(new PaginationDto(paginationDto.PageNumber - 1, paginationDto.PageSize))
                : null;
            result.FirstPage = uriService.GetPageUri(new PaginationDto(1, paginationDto.PageSize));
            result.LastPage = uriService.GetPageUri(new PaginationDto(totalPages, paginationDto.PageSize));
            result.TotalPages = totalPages;
            result.TotalRecords = totalRecords;

            return result;
        }
    }
}
