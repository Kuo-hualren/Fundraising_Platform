using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTest1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            string s = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine(s);

            Program p = new Program();
            DateTime  sd =  Convert.ToDateTime("2023-7-12 1:39:45");
            var a = p.DateDiff(sd,DateTime.Now);
            Console.WriteLine(a);
        }
        public string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Hours.ToString() + "小時" + ts.Minutes.ToString() + "分鐘" + ts.Seconds.ToString() + "秒";
            return dateDiff;
        }

    }
    
}
