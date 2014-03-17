using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace TestCase
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager.DirectoryCopy(@"D:\test1",@"D:\test2");

        }
    }
}
