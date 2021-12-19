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
        /// <summary>
        /// api ye donus tipi olacak olan sayfalama bilgilerini iceren Result nesnesini olusturan static method
        /// </summary>
        /// <typeparam name="T">gosterilecek datanin tipi</typeparam>
        /// <param name="pagedData">apiye donen ve gosterilecek olan araliktaki veri</param>
        /// <param name="paginationDto">onceki,sonraki ve son sayfa hesaplamalarinda kullanilacak sayfa numarasi ve her sayfadaki elemnet sayisini tutan nesne</param>
        /// <param name="totalRecords">gerekli sartlara uyan toplam data sayisi</param>
        /// <param name="PaginationUriManager">onceki,sonraki ve son sayfa uri ini olusturacak manager nesnesi</param>
        /// <param name="success">islem sonuc turu</param>
        /// <returns></returns>
        public static PaginationDataResult<T> CreatePaginationResult<T>(T pagedData, PaginationDto paginationDto, int totalRecords, IPaginationUriService PaginationUriManager, bool success)
        {
            var result = new PaginationDataResult<T>(pagedData,paginationDto.PageNumber, paginationDto.PageSize,success);
            var totalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / (double)paginationDto.PageSize));
            result.NextPage = paginationDto.PageNumber >= 1 && paginationDto.PageNumber < totalPages
                ? PaginationUriManager.GetPageUri(new PaginationDto(paginationDto.PageNumber + 1, paginationDto.PageSize))
                : null;
            result.PreviousPage = paginationDto.PageNumber - 1 >= 1 && paginationDto.PageNumber <= totalPages
                ? PaginationUriManager.GetPageUri(new PaginationDto(paginationDto.PageNumber - 1, paginationDto.PageSize))
                : null;
            result.FirstPage = PaginationUriManager.GetPageUri(new PaginationDto(1, paginationDto.PageSize));
            result.LastPage = PaginationUriManager.GetPageUri(new PaginationDto(totalPages, paginationDto.PageSize));
            result.TotalPages = totalPages;
            result.TotalRecords = totalRecords;

            return result;
        }
    }
}
