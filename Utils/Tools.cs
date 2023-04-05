using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRPG_APP.Utils
{
    public class Tools
    {
        public void SleepFunc(double second)
        {
            //转换成毫秒，并通过Convert函数将计算结果转出Int类型，防止类型错误导致程序异常。
            Thread.Sleep(Convert.ToInt32(second * 1000));
        }
    }
}
