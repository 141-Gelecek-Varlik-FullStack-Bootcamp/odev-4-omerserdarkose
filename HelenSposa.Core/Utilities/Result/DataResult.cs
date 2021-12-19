using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Result
{
    /// <summary>
    /// api ye sadece islemin basarili veya basarisiz oldugu bilgisi ile birlikte birde data donusu oldugunda
    /// kullanmak icin tanimlayacagimiz DataResult sinifini olusturuyoruz
    /// zaten veri haricindeki donus yapan seklini Result olarak tanimladigimizdan burada kalitila aliyoruz
    /// </summary>
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data,bool success,string message):base (success,message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
