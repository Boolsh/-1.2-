using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace шарпы_1._2_лаба
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Console.WriteLine("Chmo");
            ArrayHeap<int> arr = new ArrayHeap<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(5);
            arr.Add(3);
            arr.Add(11);
            arr.Add(4);
            arr.Add(6);
            arr.print_to_console();
        }
    }
}
