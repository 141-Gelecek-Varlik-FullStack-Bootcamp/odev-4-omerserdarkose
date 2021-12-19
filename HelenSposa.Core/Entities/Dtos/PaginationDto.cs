using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Entities.Dtos
{
    /// <summary>
    /// sayfalama ile ilgili Dto nesnesini tanimliyoruz
    /// gercek bir model(entity) olmadigindan IDto ile imzaladik
    /// </summary>
    public class PaginationDto:IPaginationDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        //constructer ile ekranda gosterilecek sayfa numarasinin ve sayfadaki element miktarinin default degerleri belirleniyor
        public PaginationDto()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        //ui tarafindan gelen sayfa numarasi ve sayfadaki element miktari propertylere set ediliyor
        public PaginationDto(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
