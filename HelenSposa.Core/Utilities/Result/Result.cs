using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Result
{
    /// <summary>
    /// api ye sadece islemin basarili veya basarisiz oldugunu ve gerekirse bunu bir mesaj ile destekemek icin
    /// kullanacagimiz Result tipini tanimliyoruz
    /// 2 adet constructora sahip sadece islem sonucu veya sonuc+mesaj
    /// </summary>
    public class Result : IResult
    {
        public Result(bool success, string message):this (success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
