/************************************************
 * Autor: Sandru Alexandru
 * Data: 23.10.2023
 * Descriere: Lucrare 2 pentru laboratorul de EGC
 ************************************************/

using System;

namespace Lab_2
{
    internal class Lab2
    {
        [STAThread]
        public static void Main()
        {
            FullScreen fullScreen = new FullScreen();

            fullScreen.GoFullScreen();

            using (Character start = new Character())
            {
                Raspunsurii raspunsurii = new Raspunsurii("Raspunsuri.txt");

                raspunsurii.CitesteFisier();

                Console.WriteLine("\nOptiuni Program:\n" + "\tESC - Inchidere program\n" + "\tA - Invartire la stanga\n" + "\tD - Invartire la dreapta\n" + "\tS - Activare/Dezactivare mouse\n");

                start.Run(60.0, 60.0);
            }
        }
    }
}
