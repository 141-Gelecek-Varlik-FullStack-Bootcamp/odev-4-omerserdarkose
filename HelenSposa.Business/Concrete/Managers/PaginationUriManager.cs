using HelenSposa.Business.Abstract;
using HelenSposa.Business.Extensions;
using HelenSposa.Core.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Concrete.Managers
{
    /// <summary>
    /// sayfalama islemli sonuclarimizi donerken belirtecek oldugumuz 
    /// bir onceki sayfa, bir sonraki sayfa ve son sayfayi uri olarak olusturacak olan
    /// PaginationUriManager i tanimliyoruz
    /// </summary>
    public class PaginationUriManager:IPaginationUriService
    {
        //mevcut uri ogrenmek icin HttpContextAccessor sinifini kullaniyoruz 
        //Dependency Injection ile inject ediyoruz
        //startup.cs de gerekli atamayi yapmayi unutmamak gerekiyor eger IoC Container kullaniliyorsa orada da gerekli ayarlama yapilmali
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaginationUriManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// gonderilen sayfa numarasi ve sayfadaki element miktarina gore
        /// uri olusturur
        /// </summary>
        /// <param name="paginationDto">sayfa numarasi ve element miktari blgilerini icerir</param>
        /// <returns></returns>
        public Uri GetPageUri(PaginationDto paginationDto)
        {
            //"https://localhost:44323"
            var baseUri = _httpContextAccessor.GetRequestUri();

            //"/Expenses"
            var route = _httpContextAccessor.GetRoute();

            //{https://localhost:44323/Expenses}
            var endpoint = new Uri(string.Concat(baseUri, route));

            //"https://localhost:44323/Expenses?pageNumber=2"
            var queryUri = QueryHelpers.AddQueryString($"{endpoint}", "pageNumber", $"{paginationDto.PageNumber}");

            //"https://localhost:44323/Expenses?pageNumber=2&pageSize=10"
            queryUri = QueryHelpers.AddQueryString(queryUri, "pageSize", $"{paginationDto.PageSize}");
            return new Uri(queryUri);
        }
    }
}
