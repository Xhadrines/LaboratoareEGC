using System;
using System.IO;

namespace Lab_3
{
    public class Raspunsurii
    {
        private string numeFisier;

        public Raspunsurii(string numeFisier)
        {
            this.numeFisier = numeFisier;
        }

        public string CitesteFisier()
        {
            try
            {
                string fisier = File.ReadAllText(numeFisier);

                Console.WriteLine(fisier);

                return fisier;
            }

            catch (Exception e)
            {
                Console.WriteLine("Eroare la citirea fisierului: " + e.Message);

                return null;
            }
        }
    }
}
