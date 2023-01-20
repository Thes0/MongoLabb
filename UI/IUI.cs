using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONGOLABB3.UI
{
    internal interface IUI
    {
        public void Clear();

        public void Exit();

        public string GetInput();

        public void Print(string output);


    }
}
