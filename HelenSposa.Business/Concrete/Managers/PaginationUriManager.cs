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
    public class PaginationUriManager:IPaginationUriService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaginationUriManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Uri GetPageUri(PaginationDto paginationDto)
        {
            var baseUri = _httpContextAccessor.GetRequestUri();
            var route = _httpContextAccessor.GetRoute();
            var endpoint = new Uri(string.Concat(baseUri, route));
            var queryUri = QueryHelpers.AddQueryString($"{endpoint}", "pageNumber", $"{paginationDto.PageNumber}");
            queryUri = QueryHelpers.AddQueryString(queryUri, "pageSize", $"{paginationDto.PageSize}");
            return new Uri(queryUri);
        }
    }
}
