using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAndSet
{
    class person
    {
        private int age;
        public int Age
        {
            get { return age; }
            
            //用与控制写入值的大小
            set { if (value > 100) age = value; }
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
             //string inPut = Console.ReadLine();
             person pro = new person();
             pro.Age = 50;
             Console.WriteLine("{0}", pro.Age);
        }
    }
}
