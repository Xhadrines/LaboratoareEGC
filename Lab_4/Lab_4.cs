/************************************************
 * Autor: Sandru Alexandru
 * Data: 03.11.2023
 * Descriere: Lucrare 4 pentru laboratorul de EGC
 ************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class Lab_4
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (Window start = new Window())
            {
                start.Run(30.0, 0.0);
            }
        }
    }
}
