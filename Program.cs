using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
// Huffman koodaus sovellus
// Mika Mörsky 9.2.2020
// Esimerkkiä katsottu https://www.geeksforgeeks.org/huffman-coding-greedy-algo-3/
namespace Algoritmi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
