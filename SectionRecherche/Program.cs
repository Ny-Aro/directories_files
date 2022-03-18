using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Configuration;

namespace SectionRecherche
{
    class Program
    {

        public static void Recherche()
        {

            CheminSection chemin = ConfigurationManager.GetSection("chemins") as CheminSection;
            string name = chemin.NameChemins;
            Console.WriteLine(name);

            #region Foreach_Recherche
            foreach (CheminElement item in chemin.Chemins)
            {
                Console.WriteLine("");

                //Affichage du chemin du fichier Source et le dossier de recherche 
                Console.WriteLine(item.Source + ", " + item.Recherche);

                //Recherche du dossier 
                DirectoryInfo dirSource = new DirectoryInfo(item.Source);
                DirectoryInfo[] childDirs = dirSource.GetDirectories(item.Recherche, SearchOption.AllDirectories);

                foreach (DirectoryInfo childDir in childDirs)
                {
                    //Recherche des fichiers
                    IEnumerable<FileInfo> l = childDir.GetFiles("*.*", SearchOption.AllDirectories);
                    IEnumerable<FileInfo> files =
                        from file in l
                        where file.Extension == ".pdf"
                        orderby file.Name
                        select file;
                    //Affichage des fichiers
                    if (files.Count() != 0)
                    {
                        foreach (FileInfo fi in files)
                            Console.WriteLine(fi.FullName);
                    }
                    else
                    {
                        Console.WriteLine("Les fichiers recherchés n'existent pas");
                    }
                }
            }
            #endregion

        }

        static void Main(string[] args)
        {
            Recherche();
            
            Console.ReadLine();
        }
    }
}
