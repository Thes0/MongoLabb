using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONGOLABB3.UI
{
    internal class TextIO : IUI
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void Exit()
        {
            System.Environment.Exit(0);
        }
        public string GetInput()
        {
            return Console.ReadLine();
        }
        public void Print (string output)
        {
            Console.WriteLine(output);
        }
    }
}
