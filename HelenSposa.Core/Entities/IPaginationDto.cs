using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Entities
{
    public class IPaginationDto:IDto
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}
