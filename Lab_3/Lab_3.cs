/************************************************
 * Autor: Sandru Alexandru
 * Data: 23.10.2023
 * Descriere: Lucrare 3 pentru laboratorul de EGC
 ************************************************/

using System;

namespace Lab_3
{
    internal class Lab_3
    {
        [STAThread]
        public static void Main()
        {
            using (var window = new Window())
            {
                Raspunsurii raspunsurii = new Raspunsurii("Raspunsuri.txt");

                raspunsurii.CitesteFisier();

                Console.WriteLine("\nOptiuni:\n\tR - Schimba culoarea in rosu\n\tG - Schimba culoarea in verde\n\tB - Schimba culoarea in albastru\n");

                window.Run(60.0);
            }
        }
    }
}
