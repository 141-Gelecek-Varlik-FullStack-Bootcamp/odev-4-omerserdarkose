using HelenSposa.Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Abstract
{
    /// <summary>
    /// sayfalama islemli sonuclarimizi donerken belirtecek oldugumuz 
    /// bir onceki sayfa, bir sonraki sayfa ve son sayfayi uri olarak olusturacak olan
    /// PaginationUriManagerin soyutlamak icin kullanacagimiz interface tanimliyoruz
    /// </summary>
    public interface IPaginationUriService
    {
        Uri GetPageUri(PaginationDto paginationDto);
    }
}
