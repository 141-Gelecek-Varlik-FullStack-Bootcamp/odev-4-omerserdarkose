using HelenSposa.Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    public interface IPaginationUriService
    {
        Uri GetPageUri(PaginationDto paginationDto);
    }
}
