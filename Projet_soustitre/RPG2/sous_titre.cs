using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_soustitre
{
    public class sous_titre
    {
        public enum StatusLine { NumberLine, TimerLine, SubTitleLine, EmptyLine };
        public List<string> allLineOfFile;
        public List<srt> allSubTitle;
        public string path;

        public sous_titre()
        {
        }

        public void ReadFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                allLineOfFile = new List<string>();

                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    allLineOfFile.Add(line);
                }

                ParseFile();
            }
        }

        private void ParseFile()
        {
            int nbSub = 0;       //Numero de sous titre
            string Timer = "";   //Temps d'apparition sous titre
            string Subs = "";    //Contenu du sous titre
            StatusLine statusL = StatusLine.NumberLine;
            allSubTitle = new List<srt>();

            foreach (string line in allLineOfFile)
            {
                if (line == "")
                {
                    statusL = StatusLine.EmptyLine;
                }

                switch (statusL)
                {
                    case StatusLine.NumberLine:
                        nbSub = Int32.Parse(line);
                        statusL++;
                        break;
                    case StatusLine.TimerLine:
                        Timer = line;
                        statusL++;
                        break;
                    case StatusLine.SubTitleLine:
                        Subs += line + "\n";
                        break;
                    case StatusLine.EmptyLine:
                        srt sub = new srt(nbSub, Timer, Subs);
                        allSubTitle.Add(sub);
                        statusL = StatusLine.NumberLine;
                        Subs = "";
                        break;
                }
            }

            GetSubTitle();
        }

        public void GetSubTitle()
        {
            foreach (srt sub in allSubTitle)
            {
                Task r = sub.AddSubTitle();
            }
        }

    }
}
