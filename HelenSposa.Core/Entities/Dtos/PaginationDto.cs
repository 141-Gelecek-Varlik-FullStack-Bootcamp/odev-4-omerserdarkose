﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Entities.Dtos
{
    public class PaginationDto:IDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PaginationDto()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PaginationDto(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}