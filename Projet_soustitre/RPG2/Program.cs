using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Projet_soustitre
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Nouveau.txt"; //Modifier avec le texte voulu
            sous_titre test = new sous_titre();

            test.ReadFile(mydocpath);

            Console.Read();
        }
    }
}