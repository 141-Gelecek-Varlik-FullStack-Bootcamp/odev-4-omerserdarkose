using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Result
{
    /// <summary>
    /// api ye sadece islemin basarili veya basarisiz oldugunu ve gerekirse bunu bir mesaj ile destekemek icin
    /// kullanacagimiz Result tipini soyutma yapmak amaciyla burada interfaci olusturuyoruz
    /// </summary>
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
