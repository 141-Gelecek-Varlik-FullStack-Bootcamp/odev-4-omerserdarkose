using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Result
{
    /// <summary>
    /// api ye sadece islemin basarili veya basarisiz oldugu bilgisi ile birlikte birde data donusu oldugunda
    /// kullanmak icin tanimlayacagimiz DataResult sinifini soyutlamak amaciyla burada interfacini olusturyoruz
    /// zaten veri haricindeki donus yapan seklini IResult olarak tanimladigimizdan burada onu inherit ediyoruz
    /// </summary>
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
