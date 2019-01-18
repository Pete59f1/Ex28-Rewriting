using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_Rewriting
{
    class Program
    {
        Menu menu = new Menu();

        static void Main(string[] args)
        {
            Program pro = new Ex28_Rewriting.Program();
            pro.Run();
        }

        private void Run()
        {
            menu.RunMenu();
        }
    }
}
